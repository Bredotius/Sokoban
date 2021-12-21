namespace Sokoban
{
    public class Magnet : Square
    {
        public Magnet()
        {
            this.Image = new ItemDisplay(Squares.Magnet).View;
        }
    }
}
