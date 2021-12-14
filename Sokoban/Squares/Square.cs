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
            Square square = getSquareInDirection(direction);

            if (square is Wall) return null;

            if (square.Entity is null)
            {
                if (Entity is Player)
                {
                    Player player = (Player)Entity;
                    if (square is Storage)
                        player.InStorage = true;
                    else player.InStorage = false;
                }
                square.Entity = Entity;
                Entity = null;
                return square;
            }
            else if (square.Entity is Box)
            {
                var box = (Box)square.Entity;

                if (Entity is Box) return null;

                if (square.RelocateEntity(direction) == null) return null;

                if(square.getSquareInDirection(direction) is Storage)
                    box.InStorage = true;
                else box.InStorage = false;

                square.Entity = Entity;
                Entity = null;
                return square;
            }

            return null;
        }

        private Square getSquareInDirection(Directions direction)
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