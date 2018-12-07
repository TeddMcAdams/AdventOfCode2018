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

            string exampleInput1 = @"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2";

            #endregion

            // Act
            int actual1 = FindIdOfClaimWithNoOverlap(exampleInput1);
            int actual = FindIdOfClaimWithNoOverlap(_puzzleInput);

            // Assert
            Assert.Equal(3, actual1);
            Assert.Equal(164, actual);
        }

        private int FindIdOfClaimWithNoOverlap(string input)
        {
            var fabricClaims = new List<FabricClaim>();
            var coordinateMap = new Dictionary<Coordinate, int>();

            string[] elfFabricClaims = Parsing.SplitOnNewLine(input);

            foreach (string claimString in elfFabricClaims)
            {
                FabricClaim fabricClaim = ConvertFabricClaimString(claimString);

                fabricClaims.Add(fabricClaim);

                foreach (Coordinate coordinate in fabricClaim.Coordinates)
                {
                    if (coordinateMap.ContainsKey(coordinate))
                        coordinateMap[coordinate]++;
                    else
                        coordinateMap.Add(coordinate, 1);
                }
            }

            return fabricClaims
                .Single(c => c.Coordinates.All(coor => coordinateMap[coor] == 1))
                .Id;
        }

        private int CalculateSquareInchesOfOverlappedFabric(string input)
        {
            var coordinateMap = new Dictionary<Coordinate, int>();

            string[] elfFabricClaims = Parsing.SplitOnNewLine(input);

            foreach (string claimString in elfFabricClaims)
            {
                FabricClaim fabricClaim = ConvertFabricClaimString(claimString);

                foreach (Coordinate coordinate in fabricClaim.Coordinates)
                {
                    if (coordinateMap.ContainsKey(coordinate))
                        coordinateMap[coordinate]++;
                    else
                        coordinateMap.Add(coordinate, 1);
                }
            }

            return coordinateMap.Where(kvp => kvp.Value > 1).Count(); ;
        }

        private FabricClaim ConvertFabricClaimString(string claimString)
        {
            var fabricClaim = new FabricClaim();

            string[] delimitedValues = claimString.Split(new[] { " @ ", ": " }, StringSplitOptions.None);

            fabricClaim.Id = int.Parse(delimitedValues[0].Substring(1));

            string[] positionInfo = delimitedValues[1].Split(',');
            string[] sizeInfo = delimitedValues[2].Split('x');

            int cornerCoordinateX = int.Parse(positionInfo[0]) + 1;
            int cornerCoordinateY = int.Parse(positionInfo[1]) + 1;

            fabricClaim.Width = int.Parse(sizeInfo[0]);
            fabricClaim.Height = int.Parse(sizeInfo[1]);

            for (int i = cornerCoordinateX; i < cornerCoordinateX + fabricClaim.Width; i++)
            {
                for (int j = cornerCoordinateY; j < cornerCoordinateY + fabricClaim.Height; j++)
                {
                    fabricClaim.Coordinates.Add(new Coordinate { X = i, Y = j });
                }
            }

            return fabricClaim;
        }

    }
}
