using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Player : IEntity
    {
        public char Character => InStorage ? 'P' : 'p';

        public bool InStorage { get; set; } = false;

        public Square Square { get; set; }

        public Player(Square square)
        {
            Square = square;
        }
    }
}
