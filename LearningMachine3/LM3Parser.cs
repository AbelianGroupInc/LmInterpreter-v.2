using System;

namespace LearningMachineLib.LearningMachine3
{
    public class LM3Parser : LmParser
    {
        public LM3Parser(string path) : base(path) { }

        protected override void CreateProgram(string path)
        {
            LM3ProgramXMLCreator programCreator = new LM3ProgramXMLCreator(mAddressList, mRows, mNames, mValues);
            programCreator.Create(path);
        }

        protected override void Scanning(string program)
        {
            LM3LexicalScanner.Scanner scanner = new LM3LexicalScanner.Scanner();
            scanner.SetSource(program, 0);

            LM3SyntaxScanner.Parser parser = new LM3SyntaxScanner.Parser(scanner);

            if (!parser.Parse())
                throw new Exception();

            Initialization(parser.names, parser.values, parser.rows);
        } 
    }
}
