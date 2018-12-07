using System;

namespace AdventOfCode2018.Helpers
{
    internal static class Parsing
    {
        public static string[] SplitOnNewLine(string input)
        {
            return input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int[] SplitOnNewLineOrCommaAndCovertToInt(string input)
        {
            string[] splitInputString = input
                .Split(new[] { Environment.NewLine, ", " }, StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[splitInputString.Length];

            for (int i = 0; i < splitInputString.Length; i++)
            {
                numbers[i] = int.Parse(splitInputString[i]);
            }

            return numbers;
        }
    }
}
