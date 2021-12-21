namespace Sokoban
{
    public class Wall : Square
    {
        public Wall()
        {
            this.Image = new ItemDisplay(Squares.Wall).View;
        }
    }
}
