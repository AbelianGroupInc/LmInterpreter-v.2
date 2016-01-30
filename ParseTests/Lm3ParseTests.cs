using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LearningMachineLib;
using LearningMachineLib.LearningMachine3;

namespace ParseTests
{
    [TestClass]
    public class Lm3ParseTests
    {
        [TestMethod]
        public void ParseTest1()
        {
            string input = new StreamReader(@"../../../ParseTests\TextFiles\input.txt").ReadToEnd();
            string output = new StreamReader(@"../../../ParseTests\TextFiles\output.txt").ReadToEnd();

            LmParser parser = new LM3Parser(@"../../../ParseTests\TextFiles\testOutput.txt");
            parser.Parse(input);

            string testOutput = new StreamReader(@"../../../ParseTests\TextFiles\testOutput.txt").ReadToEnd();
            Assert.AreEqual(output, testOutput);
        }
    }
}
