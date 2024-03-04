using System;
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
        public Button[,] Tiles { get;}
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
                    Mines = 99;
                    break;
            }
            Lives = lives;
            Tiles = new Button[yDim, xDim];
        }


        public void GenerateButtons(Control parent)
        {
            int celNr = 1;

            for (int y = 0; y < yDim; y++)
            {
                for (int x = 0; x < xDim; x++)
                {
                    Tiles[y, x] = new Button()
                    {
                        Size = new Size(20, 20),
                        Location = new Point(y * 20 + 10,
                                              x * 20 + 10),
                        Parent = parent
                    };
                    Tiles[y, x].Tag = celNr++;
                }
            }
        }

    }
}
