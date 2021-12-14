using System;

namespace Sokoban
{
    public class Game
    {
        private static string[] maps = { @"
#####
#p*O#
# o+#
#####", @"
  ##### 
###   # 
#+po  # 
### o+# 
#+##o # 
# # + ##
#o Ooo+#
#   +  #
########" };

        private View view;

        public int Scores;
        public GameStates State;
        public GameField GameField;
        public int Map = 0;

        public void Menu()
        {
            State = GameStates.Menu;
            GameField = null;

            while (State == GameStates.Menu)
            {
                GameField = new GameField(maps[Map]);

                view = new View(GameField);
                CheckInput(view.Display(State));
            }

            Play();
        }

        public void Play()
        {
            State = GameStates.Playing;

            GameField = new GameField(maps[Map]);

            view = new View(GameField);

            while (State == GameStates.Playing)
            {
                CheckInput(view.Display(State));
                CheckGameState();
            }

            GameResult();
        }

        public void GameResult()
        {
            view.Display(State);

            Menu();
        }

        private void CheckInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    if (State == GameStates.Menu) State = GameStates.Playing;
                    break;
                case ConsoleKey.UpArrow:
                    if (State == GameStates.Playing) GameField.Player.Move(Directions.UP);
                    break;
                case ConsoleKey.DownArrow:
                    if (State == GameStates.Playing) GameField.Player.Move(Directions.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    if (State == GameStates.Playing) GameField.Player.Move(Directions.LEFT);
                    if (State == GameStates.Menu) Map = (Map - 1 > -1) ? Map - 1 : Map;
                    break;
                case ConsoleKey.RightArrow:
                    if (State == GameStates.Playing) GameField.Player.Move(Directions.RIGHT);
                    if (State == GameStates.Menu) Map = (Map + 1 < maps.Length) ? Map + 1 : Map;
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
                if (box.Square is Storage) boxInStorage++;
            }

            if (boxInStorage == GameField.Boxes.Count) State = GameStates.Win;
        }

        private void IsLose()
        {
            foreach (var box in GameField.Boxes)
            {
                if (box.InDeadEnd)
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
    }
}