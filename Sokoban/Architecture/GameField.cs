using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class GameField
    {
        private Square[,] Squares { get; set; }

        public Player Player { get; set; }

        public List<Box> Boxes { get; } = new List<Box>();

        public GameField(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");

            Squares = new Square[rows.Length, rows[0].Length];

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
                            square.Entity = new Box(square, EntityState.Free);
                            Boxes.Add((Box)square.Entity);
                            break;
                        case 'p':
                            square = new Floor();
                            Player = new Player(square, EntityState.Free);
                            square.Entity = Player;
                            break;
                        case '#':
                            square = new Wall();
                            break;
                        case 'O':
                            square = new Storage();
                            square.Entity = new Box(square, EntityState.InStorage);
                            Boxes.Add((Box)square.Entity);
                            break;
                        case 'P':
                            square = new Storage();
                            Player = new Player(square, EntityState.InStorage);
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
                    Squares[x, y] = square;
                    Squares[x, y].Position = new Position(x, y);
                }
        }
        public void PrintField()
        {
            for (var x = 0; x < Squares.GetLength(0); x++)
                for (var y = 0; y < Squares.GetLength(1); y++)
                {
                    var current = Squares[x, y];

                    if (current.Entity != null)
                        Console.Write(current.Entity.Image);

                    else Console.Write(current.Image);

                    if (y == Squares.GetLength(1) - 1)
                        Console.WriteLine();
                }
        }

        public Square RelocateEntity(Square square,  Directions direction)
        {
            Square neighborSquare = GetSquareInDirection(square, direction);

            if (neighborSquare != null)
            {
                if (square.Entity.InConflict(neighborSquare)) return square.Entity is Player ? square : null;

                if (neighborSquare.Entity is Box)
                {
                    Box neighborEntity = (Box)neighborSquare.Entity;

                    if (square.Entity is Box) return null;
                    if (RelocateEntity(neighborSquare, direction) == null) return square;

                    neighborEntity.Square = GetSquareInDirection(neighborEntity.Square, direction);
                }

                if (square.Entity is Player)
                {
                    if (neighborSquare is Portal)
                    {
                        Portal portal = (Portal)neighborSquare;
                        neighborSquare = portal.Exit;
                    }
                    ((Player)square.Entity).Square = GetSquareInDirection(square, direction);
                }

                neighborSquare.Entity = square.Entity;
                square.Entity = null;

                return neighborSquare;
            }

            return square;
        }

        public Square GetSquareInDirection(Square square, Directions direction)
        {
            switch (direction)
            {
                case Directions.UP:
                    return getSquare(square.Position.X - 1, square.Position.Y);
                case Directions.DOWN:
                    return getSquare(square.Position.X + 1, square.Position.Y);
                case Directions.LEFT:
                    return getSquare(square.Position.X, square.Position.Y - 1);
                case Directions.RIGHT:
                    return getSquare(square.Position.X, square.Position.Y + 1);
                default:
                    return null;
            }
        }
        public Square getSquare(int x, int y)
        {
            Square square;

            if (x >= Squares.GetLength(0) || x < 0
                || y >= Squares.GetLength(1) || y < 0)
            {
                return null;
            }

            square = Squares[x, y];

            return square;
        }
    }
}