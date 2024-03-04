using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Control Parent { get; }

        public event EventHandler ButtonClickedMine;
        public event EventHandler TileRevealed;

        public Tile(Control parent,int x, int y,bool isMine = false)
        {
            Button = new Button
            {
                Size = new Size(SizePx, SizePx),
                Parent = parent,
                Tag = this,
                Location = new Point(x, y),
            };
            Parent = parent;
            IsMine = isMine;
            Button.MouseUp += Button_MouseClick;
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Tile correspondingTile = (Tile)clickedButton.Tag;

            if (e.Button == MouseButtons.Left)
            {
                if (correspondingTile.Flagged || correspondingTile.Clicked) return;

                clickedButton.Text = correspondingTile.Value.ToString();

                if (correspondingTile.IsMine)
                {
                    clickedButton.BackColor = Color.Red;
                    clickedButton.Text = "M";
                    ButtonClickedMine?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    RevealTile(correspondingTile);
                    if (correspondingTile.Value == null)
                    {
                        ShowNeighbours(correspondingTile);
                    }
                    else
                    {
                        clickedButton.Text = correspondingTile.Value.ToString();
                        RevealValues(clickedButton, correspondingTile);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if(correspondingTile.Flagged == false)
                {
                    clickedButton.Text = "F";
                    correspondingTile.Flagged = true;
                }
                else
                {
                    clickedButton.Text = null;
                    correspondingTile.Flagged = false;
                }
            }
        }

        private static void RevealValues(Button button, Tile tile)
        {
            switch (tile.Value)
            {
                case 1: button.ForeColor = Color.Blue; break;
                case 2: button.ForeColor = Color.Green; break;
                case 3: button.ForeColor = Color.Red; break;
                case 4: button.ForeColor = Color.DarkBlue; break;
                case 5: button.ForeColor = Color.Brown; break;
                case 6: button.ForeColor = Color.OrangeRed; break;
                case 7: button.ForeColor = Color.Purple; break;
            }
        }

        private void RevealTile(Tile tile)
        {
            tile.Clicked = true;
            TileRevealed?.Invoke(this, EventArgs.Empty);
        }

        public void ShowNeighbours(Tile tile)
        {
            foreach (Tile t in tile.Neighbours)
            {
                if(t.Value == null && t.Clicked == false)
                {
                    RevealTile(t);
                    ShowNeighbours(t);
                }
                else
                {
                    t.Button.Text = t.Value.ToString();
                    RevealValues(t.Button, t);
                } 
            }
        }

        public void AddValues()
        {
            foreach (Tile t in Neighbours)
            {
                if (t.IsMine)
                {
                    if (Value == null) Value = 0;
                    Value++;
                }
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
