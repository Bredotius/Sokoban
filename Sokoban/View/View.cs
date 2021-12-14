using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class View
    {
        private GameField GameField;

        public View(GameField gameField)
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
                    Console.Write("Enter direction (Use arrows): ");
                    break;
                case GameStates.Menu:
                    Console.Write("Choose game field (Arrows to switch. To choose: Enter): ");
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
