using AdventOfCode2018.Helpers;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int actual = CalculateSquareInchesOfOverlappedFabric(_puzzleInput);

            // Assert
            Assert.Equal(4, actual1);
            Assert.Equal(105231, actual);
        }

        [Fact]
        public void Part2()
        {
            #region // Arrange

            string exampleInput1 = "";

            #endregion

            // Act

            // Assert
            Assert.True(false);
        }

        private int CalculateSquareInchesOfOverlappedFabric(string input)
        {
            var coordinateMap = new Dictionary<Coordinate, int>();

            string[] elfFabricClaims = Parsing.SplitOnNewLine(input);

            foreach (string claim in elfFabricClaims)
            {
                List<Coordinate> claimCoordinates = ConvertElfsFabricClaimToCoordinates(claim);

                foreach (Coordinate coordinate in claimCoordinates)
                {
                    if (coordinateMap.ContainsKey(coordinate))
                        coordinateMap[coordinate]++;
                    else
                        coordinateMap.Add(coordinate, 1);
                }
            }

            return coordinateMap.Where(kvp => kvp.Value > 1).Count(); ;
        }

        private List<Coordinate> ConvertElfsFabricClaimToCoordinates(string claim)
        {
            var coordinates = new List<Coordinate>();

            string[] delimitedValues = claim.Split(new[] { " @ ", ": " }, StringSplitOptions.None);

            string claimId = delimitedValues[0];
            string[] positionInfo = delimitedValues[1].Split(',');
            string[] sizeInfo = delimitedValues[2].Split('x');

            int cornerCoordinateX = int.Parse(positionInfo[0]) + 1;
            int cornerCoordinateY = int.Parse(positionInfo[1]) + 1;

            int width = int.Parse(sizeInfo[0]);
            int height = int.Parse(sizeInfo[1]);

            for (int i = cornerCoordinateX; i < cornerCoordinateX + width; i++)
            {
                for (int j = cornerCoordinateY; j < cornerCoordinateY + height; j++)
                {
                    coordinates.Add(new Coordinate { X = i, Y = j });
                }
            }

            return coordinates;
        }

    }


}
