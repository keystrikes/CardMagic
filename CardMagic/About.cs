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
    public partial class About : Form
    {

        int a;
        public About(int a)
        {
            this.a = a;
            InitializeComponent();
        }

        private void BackB_Click(object sender, EventArgs e)
        {

            if (a == 1 || a == 3)
            {
                First f = new First();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else if (a == 2)
            {
                Trick1 c = new Trick1();
                this.Hide();
                c.ShowDialog();
                this.Close();
            }
            else if (a == 4)
            {
                Trick2F c = new Trick2F();
                this.Hide();
                c.ShowDialog();
                this.Close();
            }
        }
    }
}
