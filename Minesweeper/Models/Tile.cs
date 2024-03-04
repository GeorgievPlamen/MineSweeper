using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Models
{
    public class Tile
    {
        public const int SizePx = 30;
        public int? Value { get; set; } = null;
        public bool Clicked { get; set; } = false;
        public bool Flagged { get; set; } = false;
        public bool IsMine { get; set; } = false;
        public Button Button { get; set; }
        public Tile UpLeft { get; set; }
        public Tile Up { get; set; }
        public Tile UpRight { get; set; }
        public Tile Right { get; set; }
        public Tile DownRight { get; set; }
        public Tile Down { get; set; }
        public Tile DownLeft { get; set; }
        public Tile Left { get; set; }
        public List<Tile> Neighbours { get; set; } = new List<Tile>();

        public Tile(Control parent,int x, int y)
        {
            Button = new Button
            {
                Size = new Size(SizePx, SizePx),
                Parent = parent,
                Tag = this,
                Location = new Point(x, y),
            };
            Button.Click += Button_Click;
        }

        public Tile(Control parent, int x, int y, Tile upLeft, Tile up, Tile upRight, Tile right,
               Tile downRight, Tile down, Tile downLeft, Tile left)
       : this(parent, x, y)
        {
            UpLeft = upLeft;
            Up = up;
            UpRight = upRight;
            Right = right;
            DownRight = downRight;
            Down = down;
            DownLeft = downLeft;
            Left = left;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Tile correspondingTile = (Tile)clickedButton.Tag;

            clickedButton.BackColor = Color.Green;
            foreach(Tile t in correspondingTile.Neighbours)
            {
                t.Button.BackColor = Color.Yellow;
            }
        }

        public void AddNeighbours()
        {
            if (UpLeft != null) Neighbours.Add(UpLeft);
            if (Up != null) Neighbours.Add(Up);
            if (UpRight != null) Neighbours.Add(UpRight);
            if (Right != null) Neighbours.Add(Right);
            if (DownRight != null) Neighbours.Add(DownRight);
            if (Down != null) Neighbours.Add(Down);
            if (DownLeft != null) Neighbours.Add(DownLeft);
            if (Left != null) Neighbours.Add(Left);
        }
    }
}
