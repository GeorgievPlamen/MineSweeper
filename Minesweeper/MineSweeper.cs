using Minesweeper.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MineSweeper : Form
    {
        public MineSweeper()
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
            var game = new GameConfig(difficulty, lives, this);
        }
    }
}
