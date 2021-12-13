namespace Sokoban
{
    public interface IEntity
    {
        char Character { get; }
        Square Square { get; set; }
    }
}
