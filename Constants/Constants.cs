namespace Constants
{
    public class Coorinates
    {
        public Coorinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public enum Directions
    {
        North = 1,
        South,
        East,
        West
    }
}
