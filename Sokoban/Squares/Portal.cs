using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Portal : Square
    {
        public Square Exit { get; set; }
        public Portal()
        {
            this.Image = new ItemDisplay(Squares.Portal).View;
        }
    }
}
