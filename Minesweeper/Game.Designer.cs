namespace Minesweeper
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLives = new System.Windows.Forms.Label();
            this.labelClearedTiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLives.Location = new System.Drawing.Point(344, 9);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(137, 32);
            this.labelLives.TabIndex = 0;
            this.labelLives.Text = "Lives: 99";
            // 
            // labelClearedTiles
            // 
            this.labelClearedTiles.AutoSize = true;
            this.labelClearedTiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClearedTiles.Location = new System.Drawing.Point(162, 9);
            this.labelClearedTiles.Name = "labelClearedTiles";
            this.labelClearedTiles.Size = new System.Drawing.Size(191, 32);
            this.labelClearedTiles.TabIndex = 0;
            this.labelClearedTiles.Text = "Tiles Left: 99";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelClearedTiles);
            this.Controls.Add(this.labelLives);
            this.Name = "Game";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.Label labelClearedTiles;
    }
}