using System;

namespace Sokoban
{
    public class GameView
    {
        private GameField GameField;

        public GameView(GameField gameField)
        {
            GameField = gameField;
        }

        public ConsoleKeyInfo Display(GameStates state)
        {
            Console.Clear();

            GameField.PrintField();

            switch (state)
            {
                case GameStates.Game:
                    Console.Write("Game is on, enter direction(Use arrows) to move or press 'Backspace' to quit: ");
                    break;
                case GameStates.Lose:
                    Console.Write("You lose! The box cannot be moved anymore.");
                    break;
                case GameStates.Win:
                    Console.Write("You win! All boxes in storage");
                    break;
                case GameStates.Dead:
                    Console.Write("You dead! Beware of spikes next time");
                    break;
            }

            return Console.ReadKey();
        }
    }
}
