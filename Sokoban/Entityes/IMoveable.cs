using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public interface IMoveable : IEntity
    {
        void Update(Square square);
    }
}
