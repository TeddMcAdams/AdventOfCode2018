namespace AdventOfCode2018.Models
{
    internal class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Reference material used while learning about Equals/GetHashCode: 
        // http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/
        // http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
        // http://www.loganfranken.com/blog/698/overriding-equals-in-c-part-3/

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (!GetType().Equals(obj.GetType()))
                return false;

            return IsEqual((Coordinate)obj);
        }

        public bool Equals(Coordinate coordinate)
        {
            if (coordinate is null)
                return false;

            if (ReferenceEquals(this, coordinate))
                return true;

            return IsEqual(coordinate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = 514229;
                const int HashingMultiplier = 7151;

                int hash = HashingBase;

                hash = (hash * HashingMultiplier) ^ X.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Y.GetHashCode();

                return hash;
            }
        }

        public static bool operator ==(Coordinate coordinateA, Coordinate coordinateB)
        {
            if (ReferenceEquals(coordinateA, coordinateB))
                return true;

            if (coordinateA is null)
                return false;

            return coordinateA.Equals(coordinateB);
        }

        public static bool operator !=(Coordinate coordinateA, Coordinate coordinateB)
        {
            return !(coordinateA == coordinateB);
        }

        private bool IsEqual(Coordinate coordinate)
        {
            return X.Equals(coordinate.X)
                && Y.Equals(coordinate.Y);
        }
    }
}
