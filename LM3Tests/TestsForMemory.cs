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
        [ExpectedException(typeof(MemoryException),
            "Выход за пределы памяти")]
        public void TestForAddressCorrectness1()
        {
            LM3 aLM3 = new LM3();

            aLM3.GetMemorySection().GetCellByAddress("-9");
        }

        [TestMethod]
        [ExpectedException(typeof(MemoryException),
            "Выход за пределы памяти")]
        public void TestForAddressCorrectness2()
        {
            LM3 aLM3 = new LM3();

            aLM3.GetMemorySection().GetCellByAddress("70000");
        }

        [TestMethod]
        [ExpectedException(typeof(MemoryException),
            "Обращение по неинициализированному адресу")]
        public void TestForAppealingByAddress()
        {
            LM3 aLM3 = new LM3();

            aLM3.GetMemorySection().GetCellByAddress("213");
        }

        [TestMethod]
        public void TestForAppealingByAddress2()
        {
            LM3 aLM3 = new LM3();
            Variable aVariable = new Variable();

            aLM3.SetCellByAddress("213", aVariable);

            Assert.AreSame(aVariable, aLM3.GetMemorySection().GetCellByAddress("213"));
        }
    }
}
