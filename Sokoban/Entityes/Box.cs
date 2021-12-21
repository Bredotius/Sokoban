namespace Sokoban
{
    public class Box : IEntity
    {
        private EntityState state;
        private Square square;
        public Square Square 
        { 
            get => square; 
            set 
            {
                square = value;
                State = this.State;
            } 
        }

        public Box(Square square, EntityState state)
        {
            Square = square;
            State = state;
        }
        public Box(Square square)
        {
            Square = square;
            State = EntityState.Free;
        }

        public EntityState State
        {
            get => Square is Storage ? EntityState.InStorage : EntityState.Free;
            set
            {
                state = value;
            }
        }

        public string Image => new ItemDisplay(Entityes.Box, state).View;

        public bool InConflict(Square square)
        {
            if (square.Entity is Box || square is Wall || square is Magnet) return true;

            return false;
        }
    }
}
