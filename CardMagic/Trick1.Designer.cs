namespace CardMagic
{
    partial class Trick1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trick1));
            this.Row1B = new System.Windows.Forms.Button();
            this.Row2B = new System.Windows.Forms.Button();
            this.Row3B = new System.Windows.Forms.Button();
            this.MainInstru = new System.Windows.Forms.Label();
            this.RestartB = new System.Windows.Forms.Button();
            this.AboutLM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Row1B
            // 
            this.Row1B.Location = new System.Drawing.Point(787, 52);
            this.Row1B.Name = "Row1B";
            this.Row1B.Size = new System.Drawing.Size(75, 23);
            this.Row1B.TabIndex = 1;
            this.Row1B.Text = "Row 1";
            this.Row1B.UseVisualStyleBackColor = true;
            this.Row1B.Click += new System.EventHandler(this.button1_Click);
            // 
            // Row2B
            // 
            this.Row2B.Location = new System.Drawing.Point(787, 139);
            this.Row2B.Name = "Row2B";
            this.Row2B.Size = new System.Drawing.Size(75, 23);
            this.Row2B.TabIndex = 2;
            this.Row2B.Text = "Row 2";
            this.Row2B.UseVisualStyleBackColor = true;
            this.Row2B.Click += new System.EventHandler(this.button2_Click);
            // 
            // Row3B
            // 
            this.Row3B.Location = new System.Drawing.Point(787, 240);
            this.Row3B.Name = "Row3B";
            this.Row3B.Size = new System.Drawing.Size(75, 23);
            this.Row3B.TabIndex = 3;
            this.Row3B.Text = "Row 3";
            this.Row3B.UseVisualStyleBackColor = true;
            this.Row3B.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainInstru
            // 
            this.MainInstru.BackColor = System.Drawing.Color.Transparent;
            this.MainInstru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainInstru.ForeColor = System.Drawing.Color.Crimson;
            this.MainInstru.Location = new System.Drawing.Point(12, 370);
            this.MainInstru.Name = "MainInstru";
            this.MainInstru.Size = new System.Drawing.Size(590, 65);
            this.MainInstru.TabIndex = 4;
            // 
            // RestartB
            // 
            this.RestartB.Location = new System.Drawing.Point(666, 397);
            this.RestartB.Name = "RestartB";
            this.RestartB.Size = new System.Drawing.Size(75, 23);
            this.RestartB.TabIndex = 5;
            this.RestartB.Text = "Restart";
            this.RestartB.UseVisualStyleBackColor = true;
            this.RestartB.Click += new System.EventHandler(this.RestartB_Click);
            // 
            // AboutLM
            // 
            this.AboutLM.AutoSize = true;
            this.AboutLM.BackColor = System.Drawing.Color.Transparent;
            this.AboutLM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AboutLM.Location = new System.Drawing.Point(842, 422);
            this.AboutLM.Name = "AboutLM";
            this.AboutLM.Size = new System.Drawing.Size(40, 13);
            this.AboutLM.TabIndex = 6;
            this.AboutLM.Text = "About";
            this.AboutLM.Click += new System.EventHandler(this.AboutLM_Click);
            // 
            // Trick1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardMagic.Properties.Resources.q02th;
            this.ClientSize = new System.Drawing.Size(902, 444);
            this.Controls.Add(this.AboutLM);
            this.Controls.Add(this.RestartB);
            this.Controls.Add(this.MainInstru);
            this.Controls.Add(this.Row3B);
            this.Controls.Add(this.Row2B);
            this.Controls.Add(this.Row1B);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Trick1";
            this.Text = "CardMagic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Row1B;
        private System.Windows.Forms.Button Row2B;
        private System.Windows.Forms.Button Row3B;
        private System.Windows.Forms.Label MainInstru;
        private System.Windows.Forms.Button RestartB;
        private System.Windows.Forms.Label AboutLM;
    }
}