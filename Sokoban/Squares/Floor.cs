namespace Sokoban
{
    public class Floor : Square
    {
        public Floor()
        {
            this.Image = new ItemDisplay(Squares.Floor).View;
        }
    }
}
