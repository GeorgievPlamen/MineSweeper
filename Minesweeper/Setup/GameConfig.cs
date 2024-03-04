using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.Setup
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public class GameConfig
    {
        public int Lives { get; }
        public int xDim { get; }
        public int yDim { get; }
        public int Mines { get; set; }
        public GameConfig(Difficulty difficulty, int lives, Control parent)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    xDim = 8;
                    yDim = 8;
                    Mines = 10;
                    break;
                case Difficulty.Medium:
                    xDim = 16;
                    yDim = 16;
                    Mines = 40;
                    break;
                case Difficulty.Hard:
                    xDim = 30;
                    yDim = 16;
                    Mines = 75;
                    break;
            }
            Lives = lives;
        }
    }
}
