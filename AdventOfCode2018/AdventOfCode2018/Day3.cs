using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2018
{
    public partial class Day3
    {
        [Fact]
        public void Part1()
        {
            #region // Arrange

            string exampleInput1 = @"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2";

            #endregion

            // Act
            int actual1 = CalculateSquareInchesOfOverlappedFabric(exampleInput1);

            // Assert
            Assert.Equal(4, actual1);
        }

        [Fact]
        public void Part2()
        {
            #region // Arrange

            string exampleInput1 = "";

            #endregion

            // Act

            // Assert
        }

        private int CalculateSquareInchesOfOverlappedFabric(string input)
        {
            int result = 0;



            return result;
        }

    }


}
