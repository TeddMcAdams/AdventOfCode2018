using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2018
{
    public partial class Day1
    {
        [Fact]
        public void Part1()
        {
            // Arrange
            string exampleInput1 = "+1, -2, +3, +1";
            string exampleInput2 = "+1, +1, +1";
            string exampleInput3 = "+1, +1, -2";
            string exampleInput4 = "-1, -2, -3";

            // Act
            int actual1 = CalculateResultingFrequency(exampleInput1);
            int actual2 = CalculateResultingFrequency(exampleInput2);
            int actual3 = CalculateResultingFrequency(exampleInput3);
            int actual4 = CalculateResultingFrequency(exampleInput4);
            int actual = CalculateResultingFrequency(_puzzleInput);

            // Assert
            Assert.Equal(3, actual1);
            Assert.Equal(3, actual2);
            Assert.Equal(0, actual3);
            Assert.Equal(-6, actual4);
            Assert.Equal(454, actual);
        }

        [Fact]
        public void Part2()
        {
            // Arrange
            string exampleInput1 = "+1, -2, +3, +1";
            string exampleInput2 = "+1, -1";
            string exampleInput3 = "+3, +3, +4, -2, -4";
            string exampleInput4 = "-6, +3, +8, +5, -6";
            string exampleInput5 = "+7, +7, -2, -7, -4";

            // Act
            int actual1 = FindDuplicateFrequency(exampleInput1);
            int actual2 = FindDuplicateFrequency(exampleInput2);
            int actual3 = FindDuplicateFrequency(exampleInput3);
            int actual4 = FindDuplicateFrequency(exampleInput4);
            int actual5 = FindDuplicateFrequency(exampleInput5);
            int actual = FindDuplicateFrequency(_puzzleInput);

            // Assert
            Assert.Equal(2, actual1);
            Assert.Equal(1, actual2);
            Assert.Equal(10, actual3);
            Assert.Equal(5, actual4);
            Assert.Equal(14, actual5);
            Assert.Equal(566, actual);

        }

        private int CalculateResultingFrequency(string input)
        {
            int result = 0;

            int[] parsedNumbers = ParseInput(input);

            for (int i = 0; i < parsedNumbers.Length; i++)
            {
                result += parsedNumbers[i];
            }

            return result;
        }

        private int FindDuplicateFrequency(string input)
        {
            List<int> frequencies = new List<int>();

            int[] parsedNumbers = ParseInput(input);

            int currentFrequency = 0;

            for (int i = 0; i < parsedNumbers.Length; i++)
            {
                currentFrequency += parsedNumbers[i];

                if (!frequencies.Contains(currentFrequency))
                    frequencies.Add(currentFrequency);
                else
                    break;

                if (i + 1 == parsedNumbers.Length)
                    i = -1;
            }

            return currentFrequency;
        }

        private int[] ParseInput(string input)
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
