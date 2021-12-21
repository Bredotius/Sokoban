using System;
using System.Linq;

namespace Sokoban
{
    public class MenuView
    {
        private string Map;
        private string Separator = "\r\n";

        public MenuView(string map)
        {
            Map = map;
        }

        public ConsoleKeyInfo Display()
        {
            Console.Clear();

            PrintMap();

            Console.Write("Choose game field (Arrows to switch. To choose: Enter): ");

            return Console.ReadKey();
        }

        public void PrintMap()
        {
            var rows = Map.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong map size");

            for (var i = 0; i < rows.Length; i++)
            {
                Console.WriteLine(rows[i]);
            }
        }
    }
}
