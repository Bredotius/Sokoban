namespace Sokoban
{
    public class Spike : Square
    {
        public Spike()
        {
            this.Image = new ItemDisplay(Squares.Spike).View;
        }
    }
}
