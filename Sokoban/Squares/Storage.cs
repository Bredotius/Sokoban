using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Storage : Square
    {
        public Storage()
        {
            this.Image = new ItemDisplay(Squares.Storage).View;
        }
    }
}
