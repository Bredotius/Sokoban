using System;

namespace Sokoban
{
    public class Square
    {
        public Square Up { get; set; }
        public Square Down { get; set; }
        public Square Left { get; set; }
        public Square Right { get; set; }
        public char Character { get; set; }
        public IEntity Entity { get; set; }

        public Square RelocateEntity(Directions direction)
        {
            Square square = GetSquareInDirection(direction);

            if (square != null)
            {
                if (square is Wall) return null;

                if (square.Entity is IPushable)
                {
                    IPushable entity = (IPushable)square.Entity;

                    if (Entity is IPushable) return null;
                    if (square.RelocateEntity(direction) == null) return null;

                    entity.Update(square.GetSquareInDirection(direction));
                }

                square.Entity = Entity;
                Entity = null;
                return square;
            }

            return null;
        }

        public Square GetSquareInDirection(Directions direction)
        {
            switch (direction)
            {
                case Directions.UP:
                    return Up;
                case Directions.DOWN:
                    return Down;
                case Directions.LEFT:
                    return Left;
                case Directions.RIGHT:
                    return Right;
                default:
                    return null;
            }
        }
    }
}