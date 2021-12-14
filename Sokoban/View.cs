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

        public ConsoleKeyInfo Display()
        {
            Console.Clear();

            GameField.PrintField();

            Console.Write("Enter direction ((U)p, (D)own, (L)eft, (R)ight): ");
            return Console.ReadKey();
        }
    }
}
