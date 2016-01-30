using System.Collections.Generic;
using System.Xml.Linq;

namespace LearningMachineLib.LearningMachine3
{
    public class LM3ProgramXMLCreator : IProgramCreator
    {
        #region constants

        private static readonly char сSeparator = ' ';

        private static readonly int cVariableLength = 1;
        private static readonly int cValueNumber = 0;
        private static readonly int cCmdNumber = 0;
        private static readonly int cRegA1Number = 1;
        private static readonly int cRegA2Number = 2;
        private static readonly int cRegA3Number = 3;

        #endregion

        protected List<string> mAddressList = new List<string>();
        protected Dictionary<string, CommandPosition> mRows = new Dictionary<string, CommandPosition>();
        protected Dictionary<string, string> mNames = new Dictionary<string, string>();
        protected Dictionary<string, string> mValues = new Dictionary<string, string>();

        public LM3ProgramXMLCreator(List<string> addressList, Dictionary<string, CommandPosition> rowsTable,
            Dictionary<string, string> namesTable, Dictionary<string, string> valuesTable)
        {
            mAddressList = addressList;
            mRows = rowsTable;
            mNames = namesTable;
            mValues = valuesTable;
        }

        public void Create(string path)
        {
            XElement mainElemnt = new XElement(LM3ProgramXMLCreatorTags.Program);

            foreach (var address in mAddressList)
            {
                XElement addressElement = new XElement(LM3ProgramXMLCreatorTags.Address,
                    new XAttribute(LM3ProgramXMLCreatorTags.Value, address));

                AddRow(addressElement, address);
                AddName(addressElement, address);
                AddValue(addressElement, address);

                mainElemnt.Add(addressElement);
            }

            XDocument OutputXmlFile = new XDocument(mainElemnt);
            OutputXmlFile.Save(path);
        }

        #region Ancillary methods
        private void AddRow(XElement addressElement, string address)
        {
            if (!mRows.ContainsKey(address))
                return;

            XElement rowElement = new XElement(LM3ProgramXMLCreatorTags.Position,
                new XAttribute(LM3ProgramXMLCreatorTags.Line, mRows[address].Line),
                new XAttribute(LM3ProgramXMLCreatorTags.StartColumn, mRows[address].StartColumn),
                new XAttribute(LM3ProgramXMLCreatorTags.EndColumn, mRows[address].EndColumn));

            addressElement.Add(rowElement);
        }

        private void AddName(XElement addressElement, string address)
        {
            if (!mNames.ContainsKey(address))
                return;

            XElement nameElement = new XElement(LM3ProgramXMLCreatorTags.Name,
                new XAttribute(LM3ProgramXMLCreatorTags.Value, mNames[address]));

            addressElement.Add(nameElement);
        }

        private void AddValue(XElement addressElement, string address)
        {
            if (!mValues.ContainsKey(address))
                return;

            string[] temp = mValues[address].Split(сSeparator);

            if (temp.Length == cVariableLength)
                AddVariable(addressElement, temp);
            else
                AddCommand(addressElement, temp); 
        }

        private void AddVariable(XElement addressElement, string[] value)
        {
            XElement variableElement = new XElement(LM3ProgramXMLCreatorTags.Variable,
                new XAttribute(LM3ProgramXMLCreatorTags.Value, value[cValueNumber]));

            addressElement.Add(variableElement);
        }

        private void AddCommand(XElement addressElement, string[] value)
        {
            XElement commandElement = new XElement(LM3ProgramXMLCreatorTags.Command,
                new XAttribute(LM3ProgramXMLCreatorTags.CMD, value[cCmdNumber]),
                new XAttribute(LM3ProgramXMLCreatorTags.RegA1, value[cRegA1Number]),
                new XAttribute(LM3ProgramXMLCreatorTags.RegA2, value[cRegA2Number]),
                new XAttribute(LM3ProgramXMLCreatorTags.RegA3, value[cRegA3Number]));

            addressElement.Add(commandElement);
        }

        #endregion
    }
}
