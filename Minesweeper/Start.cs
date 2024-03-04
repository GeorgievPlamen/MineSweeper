using Minesweeper.Setup;
using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Difficulty difficulty;
            if(easy.Checked)
            {
                difficulty = Difficulty.Easy;
            } 
            else if(medium.Checked)
            { 
                difficulty = Difficulty.Medium;
            }
            else 
            {
                difficulty = Difficulty.Hard;
            }

            int lives = Convert.ToInt32(numberOfLives.Value);
            var gameConfig = new GameConfig(difficulty, lives, this);

            Game game = new Game(gameConfig);
            int height = (gameConfig.yDim * 30) + 100;
            int width = (gameConfig.xDim * 30) + 20;
            game.Height = height; 
            game.Width = width;
            game.Show();
        }
    }
}
