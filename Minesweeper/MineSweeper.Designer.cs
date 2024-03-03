namespace Minesweeper
{
    partial class MineSweeper
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
            this.easy = new System.Windows.Forms.RadioButton();
            this.medium = new System.Windows.Forms.RadioButton();
            this.hard = new System.Windows.Forms.RadioButton();
            this.Play = new System.Windows.Forms.Button();
            this.numberOfLives = new System.Windows.Forms.NumericUpDown();
            this.Lives = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLives)).BeginInit();
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Location = new System.Drawing.Point(89, 136);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(81, 29);
            this.easy.TabIndex = 1;
            this.easy.TabStop = true;
            this.easy.Text = "Easy";
            this.easy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.easy.UseVisualStyleBackColor = true;
            // 
            // medium
            // 
            this.medium.AutoSize = true;
            this.medium.Location = new System.Drawing.Point(293, 136);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(107, 29);
            this.medium.TabIndex = 2;
            this.medium.Text = "Medium";
            this.medium.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medium.UseVisualStyleBackColor = true;
            // 
            // hard
            // 
            this.hard.AutoSize = true;
            this.hard.Location = new System.Drawing.Point(509, 136);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(79, 29);
            this.hard.TabIndex = 3;
            this.hard.TabStop = true;
            this.hard.Text = "Hard";
            this.hard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hard.UseVisualStyleBackColor = true;
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(281, 327);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(87, 48);
            this.Play.TabIndex = 4;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // numberOfLives
            // 
            this.numberOfLives.Location = new System.Drawing.Point(322, 234);
            this.numberOfLives.Name = "numberOfLives";
            this.numberOfLives.Size = new System.Drawing.Size(120, 29);
            this.numberOfLives.TabIndex = 5;
            this.numberOfLives.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lives
            // 
            this.Lives.AutoSize = true;
            this.Lives.Location = new System.Drawing.Point(228, 236);
            this.Lives.Name = "Lives";
            this.Lives.Size = new System.Drawing.Size(58, 25);
            this.Lives.TabIndex = 6;
            this.Lives.Text = "Lives";
            // 
            // MineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 478);
            this.Controls.Add(this.Lives);
            this.Controls.Add(this.numberOfLives);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Name = "MineSweeper";
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton easy;
        private System.Windows.Forms.RadioButton medium;
        private System.Windows.Forms.RadioButton hard;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.NumericUpDown numberOfLives;
        private System.Windows.Forms.Label Lives;
    }
}

