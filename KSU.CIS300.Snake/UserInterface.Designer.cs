namespace KSU.CIS300.Snake
{
    partial class UserInterface
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
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolStripMenuItem_NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEasyGame = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNormalGame = new System.Windows.Forms.ToolStripMenuItem();
            this.uxHardGame = new System.Windows.Forms.ToolStripMenuItem();
            this.uxIsAI = new System.Windows.Forms.CheckBox();
            this.uxAISpeedNumUD = new System.Windows.Forms.NumericUpDown();
            this.uxAISpeedLabel = new System.Windows.Forms.Label();
            this.uxlabelScore = new System.Windows.Forms.Label();
            this.uxScore = new System.Windows.Forms.Label();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAISpeedNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxToolStripMenuItem_File});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(600, 24);
            this.uxMenuStrip.TabIndex = 0;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // uxToolStripMenuItem_File
            // 
            this.uxToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxToolStripMenuItem_NewGame});
            this.uxToolStripMenuItem_File.Name = "uxToolStripMenuItem_File";
            this.uxToolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.uxToolStripMenuItem_File.Text = "File";
            // 
            // uxToolStripMenuItem_NewGame
            // 
            this.uxToolStripMenuItem_NewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxEasyGame,
            this.uxNormalGame,
            this.uxHardGame});
            this.uxToolStripMenuItem_NewGame.Name = "uxToolStripMenuItem_NewGame";
            this.uxToolStripMenuItem_NewGame.Size = new System.Drawing.Size(132, 22);
            this.uxToolStripMenuItem_NewGame.Text = "New Game";
            // 
            // uxEasyGame
            // 
            this.uxEasyGame.Name = "uxEasyGame";
            this.uxEasyGame.Size = new System.Drawing.Size(114, 22);
            this.uxEasyGame.Text = "Easy";
            this.uxEasyGame.Click += new System.EventHandler(this.uxEasyGame_Click);
            // 
            // uxNormalGame
            // 
            this.uxNormalGame.Name = "uxNormalGame";
            this.uxNormalGame.Size = new System.Drawing.Size(114, 22);
            this.uxNormalGame.Text = "Normal";
            this.uxNormalGame.Click += new System.EventHandler(this.uxNormalGame_Click);
            // 
            // uxHardGame
            // 
            this.uxHardGame.Name = "uxHardGame";
            this.uxHardGame.Size = new System.Drawing.Size(114, 22);
            this.uxHardGame.Text = "Hard";
            this.uxHardGame.Click += new System.EventHandler(this.uxHardGame_Click);
            // 
            // uxIsAI
            // 
            this.uxIsAI.AutoSize = true;
            this.uxIsAI.BackColor = System.Drawing.Color.White;
            this.uxIsAI.Location = new System.Drawing.Point(47, 3);
            this.uxIsAI.Name = "uxIsAI";
            this.uxIsAI.Size = new System.Drawing.Size(68, 17);
            this.uxIsAI.TabIndex = 1;
            this.uxIsAI.Text = "AI Player";
            this.uxIsAI.UseVisualStyleBackColor = false;
            this.uxIsAI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInterface_KeyDown);
            this.uxIsAI.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserInterface_PreviewKeyDown);
            // 
            // uxAISpeedNumUD
            // 
            this.uxAISpeedNumUD.Location = new System.Drawing.Point(178, 2);
            this.uxAISpeedNumUD.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uxAISpeedNumUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxAISpeedNumUD.Name = "uxAISpeedNumUD";
            this.uxAISpeedNumUD.Size = new System.Drawing.Size(80, 20);
            this.uxAISpeedNumUD.TabIndex = 2;
            this.uxAISpeedNumUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxAISpeedLabel
            // 
            this.uxAISpeedLabel.AutoSize = true;
            this.uxAISpeedLabel.BackColor = System.Drawing.Color.White;
            this.uxAISpeedLabel.Location = new System.Drawing.Point(121, 4);
            this.uxAISpeedLabel.Name = "uxAISpeedLabel";
            this.uxAISpeedLabel.Size = new System.Drawing.Size(51, 13);
            this.uxAISpeedLabel.TabIndex = 3;
            this.uxAISpeedLabel.Text = "AI Speed";
            // 
            // uxlabelScore
            // 
            this.uxlabelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxlabelScore.BackColor = System.Drawing.Color.White;
            this.uxlabelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxlabelScore.Location = new System.Drawing.Point(489, 4);
            this.uxlabelScore.Name = "uxlabelScore";
            this.uxlabelScore.Size = new System.Drawing.Size(47, 17);
            this.uxlabelScore.TabIndex = 4;
            this.uxlabelScore.Text = "Score:";
            // 
            // uxScore
            // 
            this.uxScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxScore.BackColor = System.Drawing.Color.White;
            this.uxScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScore.Location = new System.Drawing.Point(542, 4);
            this.uxScore.Name = "uxScore";
            this.uxScore.Size = new System.Drawing.Size(46, 17);
            this.uxScore.TabIndex = 5;
            this.uxScore.Text = "0";
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Location = new System.Drawing.Point(0, 24);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(600, 600);
            this.uxPictureBox.TabIndex = 6;
            this.uxPictureBox.TabStop = false;
            this.uxPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.uxPictureBox_Paint);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(600, 624);
            this.Controls.Add(this.uxPictureBox);
            this.Controls.Add(this.uxScore);
            this.Controls.Add(this.uxlabelScore);
            this.Controls.Add(this.uxAISpeedLabel);
            this.Controls.Add(this.uxAISpeedNumUD);
            this.Controls.Add(this.uxIsAI);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.uxMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "UserInterface";
            this.Text = "Classic Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserInterface_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserInterface_PreviewKeyDown);
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAISpeedNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem uxToolStripMenuItem_NewGame;
        private System.Windows.Forms.ToolStripMenuItem uxEasyGame;
        private System.Windows.Forms.ToolStripMenuItem uxNormalGame;
        private System.Windows.Forms.ToolStripMenuItem uxHardGame;
        private System.Windows.Forms.CheckBox uxIsAI;
        private System.Windows.Forms.NumericUpDown uxAISpeedNumUD;
        private System.Windows.Forms.Label uxAISpeedLabel;
        private System.Windows.Forms.Label uxlabelScore;
        private System.Windows.Forms.Label uxScore;
        private System.Windows.Forms.PictureBox uxPictureBox;
    }
}

