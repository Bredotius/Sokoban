using System;

namespace Sokoban
{
    public class Square
    {
        public Position Position { get; set; }
        public char Character { get; set; }
        public IEntity Entity { get; set; }
    }
}