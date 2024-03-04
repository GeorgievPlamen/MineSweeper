using Minesweeper.Models;
using Minesweeper.Setup;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {
        private const int TileSizePx = 30;
        private const int mineTileRatio = 16; //15.8% Of all tiles are mines.
        public int Rows { get; }
        public int Cols { get; }
        public int ClearTiles { get; private set; }
        public int Lives { get; private set; }
        public int TotalMines { get; private set; }
        private Tile[,] gameBoard;
        public Game(GameConfig config)
        {
            InitializeComponent();
            Cols = config.xDim;
            Rows = config.yDim;
            Lives = config.Lives;
            TotalMines = config.Mines;
            ClearTiles = (Rows * Cols) - TotalMines;
            labelLives.Text = $"Lives: {Lives}";
            labelClearedTiles.Text = $"Tiles Left: {ClearTiles}";
        }

        private void Game_Load(object sender, EventArgs e)
        {
            InitializeGameBoard();
            labelLives.Location = new Point((this.Width / 2) + 40, 15);
            labelClearedTiles.Location = new Point((this.Width / 2) - 120, 15);
        }

        private void InitializeGameBoard()
        {
            gameBoard = new Tile[Rows, Cols];
            var random = new Random();
            // Create tiles and link them with neighbors
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    // Calculate the position of the tile
                    int x = j * TileSizePx;
                    int y = i * TileSizePx + 50;

                    // Is it a mine?
                    bool isMine = false;
                    if(TotalMines > 0)
                    {
                        isMine = random.Next(1, 100) < mineTileRatio;
                    } 
                    if(isMine)
                    {
                        TotalMines--;
                    }

                    // Create a new Tile object
                    if (gameBoard[i,j] == null)
                    {
                        gameBoard[i, j] = new Tile(this, x, y,isMine);
                    }
                }
            }

            //Sometimes not all mines are generated
            //This ensures generation
            while(TotalMines > 0)
            {
                foreach(var tile in gameBoard)
                {
                    bool isMine = random.Next(1, 100) < mineTileRatio;
                    if (isMine && tile.IsMine == false)
                    {
                        tile.IsMine = true;
                        TotalMines--;
                    }
                    if (TotalMines == 0) break;
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
                    gameBoard[i, j].AddValues();
                    gameBoard[i, j].ButtonClickedMine += Tile_ButtonClickedIsMine;
                    gameBoard[i, j].TileRevealed += Tile_Revealed;
                }
            }
        }

        private void Tile_Revealed(object sender, EventArgs e)
        {
            ClearTiles--;
            labelClearedTiles.Text = $"Tiles Left: {ClearTiles}";
            if (ClearTiles < 1)
            {
                MessageBox.Show("You Win!!!");
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.Enabled = false;
                    }
                }
            }
        }
        private void Tile_ButtonClickedIsMine(object sender, EventArgs e)
        {
            Lives = RemoveLife(Lives);
            labelLives.Text = $"Lives: {Lives}";
            if (Lives < 1)
            {
                MessageBox.Show("Game Over :(");
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        private int RemoveLife(int currentLives)
        {
            return currentLives - 1;
        }
    }
}
