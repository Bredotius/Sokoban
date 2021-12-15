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

        public Box(Square square)
        {
            Square = square;
        }

        public void Update(Square square)
        {
            if (square is Portal)
            {
                Portal portal = (Portal)square;
                Square = portal.Exit;
            }
            else Square = square;
        }
    }
}
