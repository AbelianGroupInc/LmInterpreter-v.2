using System.Text.RegularExpressions;

namespace LearningMachineLib
{
    public static class Cleaner
    {
        public static string Clean(string program)
        {
            string cleanProgram = program.Replace('\t', ' ');
            cleanProgram = Regex.Replace(cleanProgram, @" +", " ");
            cleanProgram = Regex.Replace(cleanProgram, @";.*?\r\n", "\r\n");

            return cleanProgram;
        }
    }
}
