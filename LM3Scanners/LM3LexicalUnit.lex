%namespace LM3LexicalScanner
%using QUT.Gppg;
%using System.Linq;

Symbol  [a-zA-Z]
UnsignedHexNumber [0-9A-Fa-f]{1,14}
Sign \-
Name \"{Symbol}+\"
KeyInit #init
KeyCode #code
KeyEnd #end
LeftBracket \(
RightBracket \)
Equal \=
Quotes \"
EOS \n

%%
{UnsignedHexNumber} {
  yylval.sVal = yytext.ToUpper();
  return (int)Tokens.UnsignedHexNumber;
}

{Sign} {
  yylval.sVal = yytext;
  return (int)Tokens.Sign;
}

{Name} {
  yylval.sVal = yytext.Substring(1, yytext.Length - 2); ;
  return (int)Tokens.Name;
}

{KeyInit} {
  return (int)Tokens.KeyInit;
}

{KeyCode} {
  return (int)Tokens.KeyCode;
}

{KeyEnd} {
  return (int)Tokens.KeyEnd;
}

{LeftBracket} { 
  return (int)Tokens.LeftBracket; 
}

{RightBracket} { 
  return (int)Tokens.RightBracket;
}

{Equal} { 
  return (int)Tokens.Equal;
}

{Quotes} {
  return (int)Tokens.Quotes;
}

{EOS} {
  return (int)Tokens.EOS;
}

%{
  yylloc = new LexLocation(tokLin, tokCol, tokELin, tokECol);
%}

%%

public override void yyerror(string format, params object[] args)
{
  var ww = args.Skip(1).Cast<string>().ToArray();
  string errorMsg = string.Format("({0},{1}): Detect {2},  expected {3}", yyline, yycol, args[0], string.Join(" or ", ww));
  throw new SyntaxException(errorMsg);
}

public void LexError()
{
  string errorMsg = string.Format("({0},{1}): Unknown character {2}", yyline, yycol, yytext);
    throw new LexException(errorMsg);
}