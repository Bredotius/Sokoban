using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class Entity : IEntity
    {
        public abstract EntityState State { get; set; }

        public abstract string Image { get; }

        public Square Square { get; set; }

        public Entity(Square square)
        {
            Square = square;
        }

        public abstract bool InConflict(Square square);
    }
}
