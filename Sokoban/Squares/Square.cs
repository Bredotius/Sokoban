using System.Collections.Generic;

namespace Sokoban
{
    public class Square
    {
        public Position Position { get; set; }
        public string Image { get; set; }
        public IEntity Entity { get; set; }
        public Dictionary<SquareEffects, Square> Effects { get; set; } = new Dictionary<SquareEffects, Square>();
    }
}