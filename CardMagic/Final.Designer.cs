namespace CardMagic
{
    partial class Final
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Final));
            this.PlayAgainB = new System.Windows.Forms.Button();
            this.AboutL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayAgainB
            // 
            this.PlayAgainB.Location = new System.Drawing.Point(152, 279);
            this.PlayAgainB.Name = "PlayAgainB";
            this.PlayAgainB.Size = new System.Drawing.Size(75, 23);
            this.PlayAgainB.TabIndex = 0;
            this.PlayAgainB.Text = "Play Again";
            this.PlayAgainB.UseVisualStyleBackColor = true;
            this.PlayAgainB.Click += new System.EventHandler(this.PlayAgainB_Click);
            // 
            // AboutL
            // 
            this.AboutL.AutoSize = true;
            this.AboutL.BackColor = System.Drawing.Color.Transparent;
            this.AboutL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AboutL.Location = new System.Drawing.Point(328, 339);
            this.AboutL.Name = "AboutL";
            this.AboutL.Size = new System.Drawing.Size(48, 16);
            this.AboutL.TabIndex = 1;
            this.AboutL.Text = "About";
            this.AboutL.Click += new System.EventHandler(this.AboutL_Click);
            // 
            // Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardMagic.Properties.Resources._4865;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.AboutL);
            this.Controls.Add(this.PlayAgainB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Final";
            this.Text = "Your Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayAgainB;
        private System.Windows.Forms.Label AboutL;
    }
}