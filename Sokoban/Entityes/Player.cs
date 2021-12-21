namespace Sokoban
{
    public class Player : Entity
    {
        private EntityState state;

        public Player(Square square, EntityState state) : base(square)
        {
            State = state;
        }

        public override EntityState State
        {
            get => Square is Storage ? EntityState.InStorage : Square is Spike ? EntityState.OnSpike : EntityState.Free;
            set
            {
                state = value;
            }
        }

        public override string Image => new ItemDisplay(Entityes.Player, state).View;

        public int HealthPoints { get; set; } = 3;

        public override bool InConflict(Square square)
        {
            if (square is Wall) return true;

            if (square is Spike)
            {
                State = EntityState.OnSpike;
                HealthPoints--;
            }
            else if (square is Storage)
            {
                State = EntityState.InStorage;
            }
            else if (State != EntityState.Free) State = EntityState.Free;

            return false;
        }
    }
}
