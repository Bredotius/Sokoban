using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class View
    {
        private GameField GameField;

        public View(GameField gameField)
        {
            GameField = gameField;
        }

        public ConsoleKeyInfo Display(Views view)
        {
            Console.Clear();

            GameField.PrintField();

            switch (view)
            {
                case Views.Game:
                    Console.Write("Enter direction (Use arrows): ");
                    break;
                case Views.Menu:
                    Console.Write("Choose game field (Arrows to switch. To choose: Enter): ");
                    break;
                case Views.Lose:
                    Console.Write("You lose! The box cannot be moved anymore.");
                    break;
                case Views.Win:
                    Console.Write("You win! All boxes in storage");
                    break;
            }

            return Console.ReadKey();
        }
    }
}
