using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class GameField
    {
        public Square First { get; set; }

        public Player Player { get; set; }

        public List<Box> Boxes { get; } = new List<Box>();

        public GameField(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");

            var result = new Square[rows.Length, rows[0].Length];

            Portal enter = null;

            for (var x = 0; x < rows.Length; x++)
                for (var y = 0; y < rows[0].Length; y++)
                {
                    Square square = null;
                    switch (rows[x][y])
                    {
                        case '+':
                            square = new Storage();
                            break;
                        case ' ':
                            square = new Floor();
                            break;
                        case 'o':
                            square = new Floor();
                            square.Entity = new Box(square);
                            Boxes.Add((Box)square.Entity);
                            break;
                        case 'p':
                            square = new Floor();
                            Player = new Player(square);
                            square.Entity = Player;
                            break;
                        case '#':
                            square = new Wall();
                            break;
                        case 'O':
                            square = new Storage();
                            square.Entity = new Box(square);
                            Boxes.Add((Box)square.Entity);
                            break;
                        case 'P':
                            square = new Storage();
                            Player = new Player(square);
                            square.Entity = Player;
                            break;
                        case '*':
                            square = new Spike();
                            break;
                        case '@':
                            if (enter == null)
                            {
                                enter = new Portal();
                                square = enter;
                            }
                            else
                            {
                                var exit = new Portal();
                                enter.Exit = exit;
                                exit.Exit = enter;
                                square = exit;
                            }
                            break;
                    }
                    result[x, y] = square;
                }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Square square = result[i, j];

                    if (square == null) continue;

                    square.Up = getSquare(result, i - 1, j);
                    square.Down = getSquare(result, i + 1, j);
                    square.Left = getSquare(result, i, j - 1);
                    square.Right = getSquare(result, i, j + 1);

                    if (i == 0 && j == 0)
                    {
                        First = square;
                    }
                }
            }
        }
        private Square getSquare(Square[,] squares, int x, int y)
        {
            Square square;

            if (x >= squares.GetLength(0) || x < 0 
                || y >= squares.GetLength(1) || y < 0)
            {
                return null;
            }

            square = squares[x, y];

            return square;
        }

        public void PrintField()
        {   
            Square current = First;
            Square firstSquareLine = current;

            while(current != null)
            {
                if (current.Entity != null)
                {
                    Console.Write(current.Entity.Character);
                }
                else
                {
                    Console.Write(current.Character);
                }

                if (current.Right == null)
                {
                    Console.WriteLine("");
                    current = firstSquareLine.Down;
                    firstSquareLine = current;
                }
                else
                {
                    current = current.Right;
                }
            }
        }
    }
}