using System;
using System.Xml.Linq;

namespace LearningMachineLib.LearningMachine3
{
    public class LM3ProgramXMLLoader : IProgramLoader
    {
        LM3MemoryFiller mMemoryFiller;

        public LM3ProgramXMLLoader(LM3MemoryFiller memoryFiller)
        {
            mMemoryFiller = memoryFiller;
        }

        public void Load(string path)
        {
            XDocument programDocument = XDocument.Load(path);
            XElement program = programDocument.Element(LM3ProgramXMLCreatorTags.Program);

            foreach (var address in program.Elements(LM3ProgramXMLCreatorTags.Address))
            {
                SendName(address);
                SendPosition(address);
                SendValue(address);
            }
        }

        public void SendName(XElement address)
        {
            XElement name = address.Element(LM3ProgramXMLCreatorTags.Name);

            if (!(name == null))
                mMemoryFiller.AddName(address.Attribute(LM3ProgramXMLCreatorTags.Value).Value,
                    name.Attribute(LM3ProgramXMLCreatorTags.Value).Value);
        }

        public void SendPosition(XElement address)
        {
            XElement position = address.Element(LM3ProgramXMLCreatorTags.Position);

            if (!(position == null))
            {
                int line = Convert.ToInt32(position.Attribute(LM3ProgramXMLCreatorTags.Line).Value);
                int startColumn = Convert.ToInt32(position.Attribute(LM3ProgramXMLCreatorTags.StartColumn).Value);
                int endColumn = Convert.ToInt32(position.Attribute(LM3ProgramXMLCreatorTags.EndColumn).Value);

                mMemoryFiller.AddCommandPosition(address.Attribute(LM3ProgramXMLCreatorTags.Value).Value,
                    new CommandPosition(line, startColumn, endColumn));
            }
        }

        public void SendValue(XElement address)
        {
            XElement var = address.Element(LM3ProgramXMLCreatorTags.Variable);

            if (!(var == null))
                SendVariable(address, var);
            else
            {
                var = address.Element(LM3ProgramXMLCreatorTags.Command);

                if (!(var == null)) 
                    SendCommand(address, var);
            }
        }

        public void SendVariable(XElement address, XElement var)
        {
            mMemoryFiller.AddVariable(address.Attribute(LM3ProgramXMLCreatorTags.Value).Value, 
                var.Attribute(LM3ProgramXMLCreatorTags.Value).Value);
        }

        public void SendCommand(XElement address, XElement var)
        {
            string addressValue = address.Attribute(LM3ProgramXMLCreatorTags.Value).Value;
            string cmd = var.Attribute(LM3ProgramXMLCreatorTags.CMD).Value;
            string reg1 = var.Attribute(LM3ProgramXMLCreatorTags.RegA1).Value;
            string reg2 = var.Attribute(LM3ProgramXMLCreatorTags.RegA2).Value;
            string reg3 = var.Attribute(LM3ProgramXMLCreatorTags.RegA3).Value;

            mMemoryFiller.AddCommand(addressValue, cmd, reg1, reg2, reg3);
        }
    }
}
