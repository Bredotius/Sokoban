using System;

namespace Sokoban
{
    public class Game
    {
        private const string map = @"
#####
#p#O#
# o+#
#####";

        private const string mapBigger = @"
  ##### 
###   # 
#+po  # 
### o+# 
#+##o #
# # + ##
#o Ooo+#
#   +  #
########";

        private View view;

        public int Scores;
        public Player Player;
        public GameStates State;

        public void Play()
        {
            State = GameStates.Playing;

            var gameField = new GameField(map);

            Player = gameField.Player;

            view = new View(gameField);

            while (State == GameStates.Playing)
            {
                CheckInput(view.Display());
            }
        }

        private void CheckInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
            }
        }
    }
}