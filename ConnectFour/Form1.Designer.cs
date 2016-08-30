namespace ConnectFour
{
    partial class frmGameboard
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
            this.pnlGameboard = new System.Windows.Forms.Panel();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.lblCurrentPlayerlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlGameboard
            // 
            this.pnlGameboard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGameboard.Location = new System.Drawing.Point(13, 22);
            this.pnlGameboard.Name = "pnlGameboard";
            this.pnlGameboard.Size = new System.Drawing.Size(702, 634);
            this.pnlGameboard.TabIndex = 0;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(726, 47);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(85, 24);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "Player 1";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.Location = new System.Drawing.Point(721, 273);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 25);
            this.lblWinner.TabIndex = 2;
            // 
            // lblCurrentPlayerlbl
            // 
            this.lblCurrentPlayerlbl.AutoSize = true;
            this.lblCurrentPlayerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlayerlbl.Location = new System.Drawing.Point(726, 22);
            this.lblCurrentPlayerlbl.Name = "lblCurrentPlayerlbl";
            this.lblCurrentPlayerlbl.Size = new System.Drawing.Size(153, 24);
            this.lblCurrentPlayerlbl.TabIndex = 3;
            this.lblCurrentPlayerlbl.Text = "Who\'s turn is it:";
            // 
            // frmGameboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 668);
            this.Controls.Add(this.lblCurrentPlayerlbl);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.pnlGameboard);
            this.Name = "frmGameboard";
            this.Text = "Connect4";
            this.Load += new System.EventHandler(this.frmGameboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameboard;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label lblCurrentPlayerlbl;
    }
}

