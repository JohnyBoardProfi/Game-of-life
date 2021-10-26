namespace GameOfLife
{
    public struct Cell
    {
        public int X, Y;

        public override bool Equals(object obj)
        {
            Cell c = (Cell)obj;
            return X == c.X && Y == c.Y;
        }

        public override int GetHashCode() => string.Format("{0}_{1}", X, Y).GetHashCode();
    }
}