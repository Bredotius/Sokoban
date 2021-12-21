namespace Sokoban
{
    public interface IEntity
    {
        EntityState State { get; set; }
        string Image { get; }
        Square Square { get; set; }
        bool InConflict(Square square);
    }
}
