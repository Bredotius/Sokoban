using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Box : Entity
    {
        private EntityState state;

        public Box(Square square, EntityState state) : base(square) 
        {
            State = state;
        }

        public override EntityState State
        {
            get => Square is Storage ? EntityState.InStorage : EntityState.Free;
            set
            {
                state = value;
            }
        } 

        public override string Image => new ItemDisplay(Entityes.Box, state).View;

        public override bool InConflict(Square square)
        {
            if (square.Entity is Box || square is Wall) return true;

            if (square is Storage) State = EntityState.InStorage;
            else if (State != EntityState.Free) State = EntityState.Free;

            return false;
        }
    }
}
