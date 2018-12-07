using System.Collections.Generic;

namespace AdventOfCode2018.Models
{
    internal class FabricClaim
    {
        public List<Coordinate> Coordinates;
        public int Height;
        public int Id;
        public int Width;

        public FabricClaim()
        {
            Coordinates = new List<Coordinate>();
        }
    }
}
