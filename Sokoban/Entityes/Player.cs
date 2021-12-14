using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Player : IMoveable
    {
        public char Character => Square is Storage ? 'P' : 'p';

        public Square Square { get; set; }

        public Player(Square square)
        {
            Square = square;
        }
        public void Move(Directions direction)
        {
            Square square = Square.RelocateEntity(direction);

            if (square != null) Square = square;
        }
    }
}
