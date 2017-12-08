using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardMagic
{
    public partial class Final : Form
    {
        int n;
        public Final(int n)
        {
            this.n = n;
            InitializeComponent();
        }
        public void AnswerCard(PictureBox myCard)
        {
            
            this.Controls.Add(myCard);
            myCard.Left = 150;
            myCard.Top = 120;
        }

        private void AboutL_Click(object sender, EventArgs e)
        {
            int b = 3;
            About a = new About(b);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }
        private void PlayAgainB_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                Trick1 again = new Trick1();
                this.Hide();
                again.ShowDialog();
                this.Close();
            }
            if (n == 2)
            {
                Trick2F again = new Trick2F();
                this.Hide();
                again.ShowDialog();
                this.Close();
            }
        }

        public void MyAns(PictureBox p1, PictureBox p2)
        {
            this.Controls.Add(p1);
            this.Controls.Add(p2);
            p1.Left = 160;
            p2.Left = 130;
            p1.Top = 120;
            p2.Top = 120;

        }
        
    }
}
