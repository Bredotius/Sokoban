using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Player : IMoveable
    {
        public char Character => Square is Storage ? 'P' : Square is Spike ? '@' : 'p';

        public Square Square { get; set; }

        public int HealthPoints { get; set; } = 3;

        public Player(Square square)
        {
            Square = square;
        }
        public void Move(Directions direction)
        {
            Square square = Square.RelocateEntity(direction);

            if (square != null)
            {
                if (square is Spike) HealthPoints--;
                Square = square;
            }
        }
    }
}
