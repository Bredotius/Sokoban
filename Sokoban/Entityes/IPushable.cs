using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public interface IPushable : IEntity
    {
        void Update(Square square);
    }
}
