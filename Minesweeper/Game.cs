using Minesweeper.Models;
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
    public partial class Game : Form
    {
        private const int TileSizePx = 30;
        private int Rows;
        private int Cols;
        public GameConfig Config { get; set; }
        private Tile[,] gameBoard;
        public Game(GameConfig config)
        {
            InitializeComponent();
            Config = config;
            Cols = config.xDim;
            Rows = config.yDim;
            gameBoard = new Tile[Rows, Cols];
        }

        private void Game_Load(object sender, EventArgs e)
        {
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            // Create tiles and link them with neighbors
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    // Calculate the position of the tile
                    int x = j * TileSizePx;
                    int y = i * TileSizePx;

                    // Create a new Tile object
                    gameBoard[i, j] = new Tile(this, x, y);
                }
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    // Link the tile with its neighbors
                    if (i > 0)
                    {
                        gameBoard[i, j].Up = gameBoard[i - 1, j];
                        if (j > 0)
                            gameBoard[i, j].UpLeft = gameBoard[i - 1, j - 1];
                        if (j < Cols - 1)
                            gameBoard[i, j].UpRight = gameBoard[i - 1, j + 1];
                    }
                    if (i < Rows - 1)
                    {
                        gameBoard[i, j].Down = gameBoard[i + 1, j];
                        if (j > 0)
                            gameBoard[i, j].DownLeft = gameBoard[i + 1, j - 1];
                        if (j < Cols - 1)
                            gameBoard[i, j].DownRight = gameBoard[i + 1, j + 1];
                    }
                    if (j > 0)
                        gameBoard[i, j].Left = gameBoard[i, j - 1];
                    if (j < Cols - 1)
                        gameBoard[i, j].Right = gameBoard[i, j + 1];
                    gameBoard[i, j].AddNeighbours();
                }
            }
        }
    }
}
