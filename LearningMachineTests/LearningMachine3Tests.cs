using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningMachineLib.LearningMachine3;
using LearningMachineLib;

namespace LearningMachineTests
{
    [TestClass]
    public class LearningMachine3Tests
    {
        [TestMethod]
        public void SetAndGetCellMethods()
        {
            LM3Memory memory = new LM3Memory();
            //EmptyCell cell = new EmptyCell();
            Variable var = new Variable("10");

            memory.SetCellByAddress("0100", var);

            Assert.AreEqual(var, memory.GetCellByAddress("0100"));
        }
        [TestMethod]
        public void SetAndGetCellNameMethods()
        {
            LM3Memory memory = new LM3Memory();
            Variable var = new Variable("10");

            memory.SetCellByAddress("0100", var);
            memory.SetCellNameByAddress("0100", "X");

            Assert.AreEqual("X", memory.GetCellNameByAddress("0100"));
        }
        [TestMethod]
        public void SetAndGetCellPositionMethods()
        {
            LM3Memory memory = new LM3Memory();
            Variable var = new Variable("10");
            CommandPosition position = new CommandPosition(10, 2, 5);

            memory.SetCellByAddress("0100", var);
            memory.SetCellNameByAddress("0100", "X");
            memory.SetCellPositionByAddress("0100", position);

            Assert.AreEqual(position, memory.GetCellPositionByAddress("0100"));
        }
        [TestMethod]
        public void LM3MemoryFillerTestOne()
        {
            LM3Memory memory = new LM3Memory();
            LM3MemoryFiller filler = new LM3MemoryFiller(memory);
            LM3Command command = new LM3Command("86", 1001, 1001, 1001);

            filler.AddCommand("0101", "86", "1001", "1001", "1001");

            Assert.AreEqual(command, memory.GetCellByAddress("0100"));
        }

        [TestMethod]
        public void LM3MemoryFillerTestTwo()
        {
            LM3Memory memory = new LM3Memory();
            LM3MemoryFiller filler = new LM3MemoryFiller(memory);
            LM3Command command = new LM3Command("86", 1001, 1001, 1001);
            CommandPosition position = new CommandPosition(10, 2, 5);

            filler.AddCommand("0101", "86", "1001", "1001", "1001");
            filler.AddCommandPosition("0101", position);

            Assert.AreEqual(position, memory.GetCellPositionByAddress("0100"));
        }

        [TestMethod]
        public void LM3MemoryFillerTestThree()
        {
            LM3Memory memory = new LM3Memory();
            LM3MemoryFiller filler = new LM3MemoryFiller(memory);
            LM3Command command = new LM3Command("86", 1001, 1001, 1001);
            CommandPosition position = new CommandPosition(10, 2, 5);

            filler.AddCommand("0101", "86", "1001", "1001", "1001");
            filler.AddCommandPosition("0101", position);
            filler.AddName("0101", "X");

            Assert.AreEqual("X", memory.GetCellNameByAddress("0100"));
        }
    }
}
