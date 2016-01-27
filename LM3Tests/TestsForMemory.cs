using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningMachineLib;
using LearningMachine3;

namespace LM3Tests
{
    [TestClass]
    public class TestsForMemory
    {
        [TestMethod]
        [ExpectedException(typeof(MemoryException))]
        public void TestForAppealingByAddress()
        {
        }
    }
}
