using System;
using System.Collections.Generic;

namespace Sokoban
{
    public class Game
    {
        private GameView GameView;
        private MenuView MenuView;

        private GameStates State;
        private GameField GameField;
        private Player Player;
        private int Map = 0;
        private List<string> Maps;

        public void Menu()
        {
            State = GameStates.Menu;
            GameField = null;
            Maps = new Levels().Maps;

            while (State == GameStates.Menu)
            {
                MenuView = new MenuView(Maps[Map]);
                CheckInput(MenuView.Display());
            }

            Play();
        }

        private void Play()
        {
            State = GameStates.Game;

            GameField = new GameField(Maps[Map]);
            Player = GameField.Player;

            GameView = new GameView(GameField);

            while (State == GameStates.Game)
            {
                CheckInput(GameView.Display(State));
                CheckGameState();
            }

            GameResult();
        }

        private void GameResult()
        {
            GameView.Display(State);

            Menu();
        }

        private void CheckInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    if (State == GameStates.Menu) State = GameStates.Game;
                    break;
                case ConsoleKey.Backspace:
                    if (State == GameStates.Game) Menu();
                    break;
                case ConsoleKey.UpArrow:
                    if (State == GameStates.Game) Player.Square = GameField.RelocateEntity(Player.Square, Directions.UP);
                    break;
                case ConsoleKey.DownArrow:
                    if (State == GameStates.Game) Player.Square = GameField.RelocateEntity(Player.Square, Directions.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    if (State == GameStates.Game) Player.Square = GameField.RelocateEntity(Player.Square, Directions.LEFT);
                    if (State == GameStates.Menu) Map = (Map - 1 > -1) ? Map - 1 : Map = Maps.Count - 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (State == GameStates.Game) Player.Square = GameField.RelocateEntity(Player.Square, Directions.RIGHT);
                    if (State == GameStates.Menu) Map = (Map + 1 < Maps.Count) ? Map + 1 : Map = 0;
                    break;
            }
        }

        private void CheckGameState()
        {
            IsWin();
            IsLose();
            IsPlayerDead();
        }

        private void IsWin()
        {
            int boxInStorage = 0;

            foreach (var box in GameField.Boxes)
            {
                if (box.State == EntityState.InStorage) boxInStorage++;
            }

            if (boxInStorage == GameField.Boxes.Count) State = GameStates.Win;
        }

        private void IsLose()
        {
            foreach (var box in GameField.Boxes)
            {
                if (InDeadEnd(box))
                {
                    State = GameStates.Lose;
                    break;
                }
            }
        }

        private void IsPlayerDead()
        {
            if(GameField.Player.HealthPoints == 0) State = GameStates.Dead;
        }

        private bool InDeadEnd(Box box)
        {
            if (((GameField.GetSquareInDirection(box.Square, Directions.UP) is Wall && GameField.GetSquareInDirection(box.Square, Directions.RIGHT) is Wall) ||
                (GameField.GetSquareInDirection(box.Square, Directions.RIGHT) is Wall && GameField.GetSquareInDirection(box.Square, Directions.DOWN) is Wall) ||
                (GameField.GetSquareInDirection(box.Square, Directions.DOWN) is Wall && GameField.GetSquareInDirection(box.Square, Directions.LEFT) is Wall) ||
                (GameField.GetSquareInDirection(box.Square, Directions.LEFT) is Wall && GameField.GetSquareInDirection(box.Square, Directions.UP) is Wall)) && box.State != EntityState.InStorage)
                return true;
            return false;
        }
    }
}