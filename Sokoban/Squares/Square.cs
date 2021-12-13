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



        private Square getSquare(Directions direction)
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