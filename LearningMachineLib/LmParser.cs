using LmInterpreterLib;
using System.Collections;
using System;
using System.Collections.Generic;

namespace LearningMachineLib
{
    public abstract class LmParser : IParser
    {
        protected string mPath;
        protected List<string> mAddressList = new List<string>();
        protected Dictionary<string, CommandPosition> mRows = new Dictionary<string, CommandPosition>();
        protected Dictionary<string, string> mNames = new Dictionary<string, string>();
        protected Dictionary<string, string> mValues = new Dictionary<string, string>();

        public LmParser(string path)
        {
            mPath = path;
        }

        public virtual void Parse(string program)
        {
            program = Cleaner.Clean(program);
            Scanning(program);
            CreateProgram(mPath);
        }
        protected abstract void CreateProgram(string path);

        protected abstract void Scanning(string program);

        protected virtual void SetRowsTable(Dictionary<string, QUT.Gppg.LexLocation> rowsTable)
        {
            foreach (var position in rowsTable)
                mRows.Add(position.Key, new CommandPosition(position.Value.StartLine,
                    position.Value.StartColumn, position.Value.EndColumn));
        }

        protected void Initialization(Dictionary<string, string> namesTable,  Dictionary<string, string> valuesTable, Dictionary<string, QUT.Gppg.LexLocation> rowsTable)
        {
            foreach(var item in namesTable)
                AddingAddress(item.Key);

            foreach (var item in valuesTable)
                AddingAddress(item.Key);

            foreach (var item in rowsTable)
                AddingAddress(item.Key);

            mNames = namesTable;
            mValues = valuesTable;
            SetRowsTable(rowsTable);
        }

        private void AddingAddress(string address)
        {
            if (!mAddressList.Contains(address))
                mAddressList.Add(address);
        }
    }
}