using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Box : IEntity
    {
        public char Character => InStorage? 'O' : 'o';

        public bool InStorage { get; set; } = false;

        public Square Square { get; set; }

        public Box(Square square)
        {
            Square = square;
        }
    }
}
