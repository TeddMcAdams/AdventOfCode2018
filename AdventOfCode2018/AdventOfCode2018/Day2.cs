using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCode2018
{
    public partial class Day2
    {
        [Fact]
        public void Part1()
        {
            #region // Arrange

            string exampleInput1 = @"abcdef
bababc
abbcde
abcccd
aabcdd
abcdee
ababab";
            #endregion

            // Act
            int actual1 = CalculateChecksum(exampleInput1);
            int actual = CalculateChecksum(_puzzleInput);

            // Assert
            Assert.Equal(12, actual1);
            Assert.Equal(7134, actual);
        }

        [Fact]
        public void Part2()
        {
            #region // Arrange

            string exampleInput1 = @"abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz";

            #endregion

            // Act
            string actual1 = FindCommonLetters(exampleInput1);
            string actual = FindCommonLetters(_puzzleInput);

            // Assert
            Assert.Equal("fgij", actual1);
            Assert.Equal("kbqwtcvzhmhpoelrnaxydifyb", actual);
        }

        private string[] ParseInput(string input)
        {
            return input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string FindCommonLetters(string input)
        {
            string boxId1 = string.Empty;
            string boxId2 = string.Empty;
            bool matchFound = false;

            List<string> boxIds = ParseInput(input).ToList();

            do
            {
                boxId1 = boxIds[0];
                boxIds.RemoveAt(0);
                boxId2 = boxIds.FirstOrDefault(id2 => DoTwoBoxIdsDifferByOnlyOneChar(boxId1, id2) == true);

                if (boxId2 != null)
                    matchFound = true;

            } while (!matchFound);

            return RemoveUncommonLetterFromTwoBoxIds(boxId1, boxId2);
        }

        private string RemoveUncommonLetterFromTwoBoxIds(string boxId1, string boxId2)
        {
            int badIndex = -1;

            for (int i = 0; i < boxId1.Length; i++)
            {
                if (boxId1[i] != boxId2[i])
                {
                    badIndex = i;
                    break;
                }
            }

            return boxId1.Remove(badIndex, 1);
        }

        private bool DoTwoBoxIdsDifferByOnlyOneChar(string boxId1, string boxId2)
        {
            bool result = true;

            if (boxId1.Length == boxId2.Length)
            {
                int differences = 0;

                for (int i = 0; i < boxId1.Length; i++)
                {
                    if (boxId1[i] != boxId2[i])
                        differences++;

                    if (differences > 1)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
                result = false;

            return result;
        }

        private int CalculateChecksum(string input)
        {
            int countOfExactlyTwo = 0;
            int countOfExactlyThree = 0;

            string[] boxIds = ParseInput(input);

            foreach (string id in boxIds)
            {
                IEnumerable<char> uniqueCharacters = id.Distinct();

                char exactlyTwo = uniqueCharacters.FirstOrDefault(c => Regex.Matches(id, $"[{c}]").Count == 2);
                char exactlyThree = uniqueCharacters.FirstOrDefault(c => Regex.Matches(id, $"[{c}]").Count == 3);

                if (exactlyTwo != default(char))
                    countOfExactlyTwo++;

                if (exactlyThree != default(char))
                    countOfExactlyThree++;
            }

            return countOfExactlyTwo * countOfExactlyThree;
        }
    }
}
