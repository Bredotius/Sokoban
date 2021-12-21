using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Wall : Square
    {
        public Wall()
        {
            this.Image = new ItemDisplay(Squares.Wall).View;
        }
    }
}
