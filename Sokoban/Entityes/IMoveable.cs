using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public interface IMoveable : IEntity
    {
        int HealthPoints { get; set; }
        void Move(Directions direction);
    }
}
