using System.Collections.Generic;

namespace Sokoban
{
    public class ItemDisplay
    {
        private Dictionary<EntityState, string> Box = new Dictionary<EntityState, string> { 
            { EntityState.Free, "o" },
            { EntityState.InStorage, "O" }
        };
        private Dictionary<EntityState, string> Player = new Dictionary<EntityState, string> {
            { EntityState.Free, "p" },
            { EntityState.InStorage, "P" },
            { EntityState.OnSpike, "☺" }
        };

        private string Floor = " ";
        private string Storage = "+";
        private string Wall = "#";
        private string Spike = "*";
        private string Portal = "@";

        public string View { get; }

        public ItemDisplay(Entityes entity, EntityState state)
        {
            switch (entity)
            {
                case Entityes.Box:
                    View = Box[state];
                    break;
                case Entityes.Player:
                    View = Player[state];
                    break;
            }
        }

        public ItemDisplay(Squares square)
        {
            switch (square)
            {
                case Squares.Floor:
                    View = Floor;
                    break;
                case Squares.Portal:
                    View = Portal;
                    break;
                case Squares.Spike:
                    View = Spike;
                    break;
                case Squares.Storage:
                    View = Storage;
                    break;
                case Squares.Wall:
                    View = Wall;
                    break;
            }
        }
    }
}
