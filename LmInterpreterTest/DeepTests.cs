using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LearningMachineLib;

namespace LmInterpreterTest
{
    [TestClass]
    public class DeepTests
    {
        [TestMethod]
        public void ClearTest()
        {
            //Arrange
            StreamReader input = new StreamReader(@"../../../LmInterpreterTest\TextFile\input.txt");
            StreamReader output = new StreamReader(@"../../../LmInterpreterTest\TextFile\output.txt");
            string inputFile = input.ReadToEnd();
            string outputFile = output.ReadToEnd();
            
            //Act
            inputFile = Cleaner.Clean(inputFile);

            //Assert
            Assert.AreEqual(outputFile, inputFile);
        }
    }
}
