/*
 * Coded by : Akshay Shekade
 * Programming Language: C#
 * Date: 09-Oct-2017
 * 
 */


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
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
        }
        private void about_Click(object sender, EventArgs e)
        {
            int b = 1;
            About a = new About(b);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Trick1 card = new Trick1();
            this.Hide();
            card.ShowDialog();
            this.Close();


        }

        private void CloseB_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Play2_Click(object sender, EventArgs e)
        {
            Trick2F t = new Trick2F();
            this.Hide();
            t.ShowDialog();
            this.Close();
        }
    }
}
