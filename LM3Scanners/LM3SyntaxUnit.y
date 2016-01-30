%output=LM3SyntaxUnit.cs 

%{
	public Parser(LexScanner.Scanner scanner) : base(scanner) { }
	public Dictionary<string, string> names = new Dictionary<string, string>();
	public Dictionary<string, LexLocation> rows = new Dictionary<string, LexLocation>();
	public Dictionary<string, string> values = new Dictionary<string, string>();
%}

%union { 
	public string sVal;
}

%using System.IO

%namespace LM3SyntaxScanner

%start program

%token <sVal> UnsignedHexNumber Name Sign
%token KeyInit KeyCode KeyEnd LeftBracket RightBracket Equal Quotes EOS
%type <sVal> title assignment value hexNumber command

%%

program		: initPart pass codePart pass{ }
			| codePart { }
			;

codePart	: KeyCode pass codeList KeyEnd { }
			;

codeList	: codeString pass {}
			| codeList codeString pass { }
			;

codeString	: UnsignedHexNumber command {
					rows.Add($1, @$);
					values.Add($1, $2);
				}
			;

initPart	: KeyInit pass initList KeyEnd { }
			;

initList    : initString pass {}
			| initList initString pass {}
			;

initString	: UnsignedHexNumber title assignment { 
					names.Add($1, $2);
					values.Add($1, $3);
				}
			| UnsignedHexNumber title { 
					names.Add($1, $2);
				}
			| UnsignedHexNumber assignment { 
					values.Add($1, $2);
				}
			;

title		: LeftBracket Name RightBracket {
					$$ = $2;
				}
			;

assignment	: Equal value { 
					$$ = $2;
				}
			;

value		: hexNumber { 
					$$ = $1;
				}
			| Quotes command Quotes {
					$$ = $2;
				}
			;

command		: UnsignedHexNumber UnsignedHexNumber UnsignedHexNumber UnsignedHexNumber {
					$$ = String.Format("{0} {1} {2} {3}", $1, $2, $3, $4);
				}
			;

hexNumber 	: UnsignedHexNumber {
					$$ = $1;
				}
			| Sign UnsignedHexNumber {
					$$ = $1 + $2;
				}
			;

pass		: EOS { }
			| pass EOS { }
			;
%%

