using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Box : IPushable
    {
        public char Character => InStorage ? 'O' : 'o';

        public Square Square { get; set; }

        public bool InStorage => Square is Storage ? true : false;

        public bool InDeadEnd { get; set; } = false;

        public Box(Square square)
        {
            Square = square;
        }

        public void Update(Square square)
        {
            Square = square;
            InDeadEnd = CheckDeadEnd();
        }

        private bool CheckDeadEnd()
        {
            if (((Square.Up is Wall && Square.Right is Wall) ||
                (Square.Right is Wall && Square.Down is Wall) ||
                (Square.Down is Wall && Square.Left is Wall) ||
                (Square.Left is Wall && Square.Up is Wall)) && !InStorage)
                return true;
            return false;
        }
    }
}
