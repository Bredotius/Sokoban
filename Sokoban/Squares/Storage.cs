namespace Sokoban
{
    public class Storage : Square
    {
        public Storage()
        {
            this.Image = new ItemDisplay(Squares.Storage).View;
        }
    }
}
