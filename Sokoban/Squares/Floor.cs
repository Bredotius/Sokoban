﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Floor : Square
    {
        public Floor()
        {
            this.Image = new ItemDisplay(Squares.Floor).View;
        }
    }
}
