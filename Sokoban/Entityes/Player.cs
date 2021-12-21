namespace Sokoban
{
    public class Player : IEntity
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

        public Player(Square square, EntityState state)
        {
            Square = square;
            State = state;
        }
        public Player(Square square)
        {
            Square = square;
            State = EntityState.Free;
        }

        public EntityState State
        {
            get
            {
                if (Square is Storage) state = EntityState.InStorage;
                else if (Square is Spike)
                {
                    state = EntityState.OnSpike;
                    HealthPoints--;
                }
                else state = EntityState.Free;

                return state;
            }
            set
            {
                state = value;
            }
        }

        public string Image => new ItemDisplay(Entityes.Player, state).View;

        public int HealthPoints { get; set; } = 3;

        public bool InConflict(Square square)
        {
            if (square is Wall || square is Magnet) return true;

            return false;
        }
    }
}
