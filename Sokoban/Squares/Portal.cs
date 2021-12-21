namespace Sokoban
{
    public class Portal : Square
    {
        public Square Exit { get; set; }
        public Portal()
        {
            this.Image = new ItemDisplay(Squares.Portal).View;
        }
    }
}
