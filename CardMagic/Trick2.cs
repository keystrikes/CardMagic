using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace CardMagic
{
    public partial class Trick2F : Form
    {
        private static PictureBox[] pictures;  //Array to store Pictures after shuffel
        private static PictureBox[][] pairs;   // Jagged array for Card Pairs
        
   

        public Trick2F()
        {
           
            InitializeComponent();
          
            pictures = new PictureBox[53];
            
            pairs = new PictureBox[10][];
            for(int i = 0; i < 10; i++)
            {
                pairs[i] = new PictureBox[2];    //creating  10 Pairs
            }
            lblStatus.Text = "Keep one Pair in mind and click on Shuffel button to shuffel cards.";  //Display instruction
            ShowCards();
            checkAll();
        }
       
        public  void ShowCards()
        {
            CreateControls();
            PickDeck();
            DistributeCards();
            DisplayCards();

        }
        private  void CreateControls()
        {
            // assign cards to picture box
            for (var i = 0; i < 53; i++)
            {
                var newPicBox = new PictureBox();
                newPicBox.Width = 75;
                newPicBox.Height = 90;
                newPicBox.BorderStyle = BorderStyle.Fixed3D;

                pictures[i] = SizeImage(newPicBox, i + 1);
            }
        }
            private  PictureBox SizeImage(PictureBox Pb, int i)
        {
            //Add images from resources

            ResourceManager rm = Properties.Resources.ResourceManager;

            Image img = (Bitmap)rm.GetObject(string.Format("{0}", i));
            Pb.Image = img;
            Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            return Pb;
            
        }
        public static void PickDeck()
        {
            Random rnd = new Random();
            for (var i = 0; i < 100; i++)
            {
                int firstCard = rnd.Next(0, 53);
                int secondCard = rnd.Next(0, 53);
                if (firstCard != secondCard)
                {
                    var t = pictures[firstCard];
                    pictures[firstCard] = pictures[secondCard];
                    pictures[secondCard] = t;
                }
            }

        }
        private  void DistributeCards()
        {
            // Adding cards to Pairs
            var k = 0;
            for (var i = 0; i < 10;i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    pairs[i][j] = pictures[k++];
                }
            }
        }
        private  void DisplayCards()// dsiplay pairs
        {
            int k;
            int x;

            for (var i = 0; i < 5; i++)
            {
                 k = 2;
                for (var j = 0; j < 2; j++)
                {
                    pairs[i][j].Left = (i * 100) + 100;
                    pairs[i][j].Top = (k-- * 25);
                    this.Controls.Add(pairs[i][j]);
                    
                }
            }

            x = 0;
            for (var i = 5; i < 10; i++)
            {
                k = 5;
                for (var j = 0; j < 2; j++)
                {
                    pairs[i][j].Left = (x * 100) + 100;
                    pairs[i][j].Top = (k-- * 25) + 100;
                    this.Controls.Add(pairs[i][j]);

                }
                x++;

            }

        }
        private void ShuffelC() //assigning cards in special manner
        {

            //B                               //I                          //B                            //L                            //E   
            pictures[0] = pairs[3][0];   pictures[1] = pairs[1][0];   pictures[2] = pairs[3][1];    pictures[3] = pairs[5][0];   pictures[4] = pairs[2][0];
            //T                               //H                          //I                            //G                           //H   
            pictures[5] = pairs[0][0];   pictures[6] = pairs[6][0];   pictures[7] = pairs[1][1];    pictures[8] = pairs[9][0];   pictures[9] = pairs[6][1];
            //G                               //O                           //O                            //S                           //E   
            pictures[10] = pairs[9][1];  pictures[11] = pairs[8][0];  pictures[12] = pairs[8][1];   pictures[13] = pairs[7][0];  pictures[14] = pairs[2][1];
            //A                               //T                          //L                            //A                            //S   
            pictures[15] = pairs[4][0];  pictures[16] = pairs[0][1];  pictures[17] = pairs[5][1];   pictures[18] = pairs[4][1];  pictures[19] = pairs[7][1];

            DisplayCards2();

           
        }
        private void HidePair() 
        {

            for (var i = 0; i < 10; i++)
            {
               
                for (var j = 0; j < 2; j++)
                {
                    pairs[i][j].Hide();

                }
            }
        }

        private void DisplayCards2()// display shuffeled cards
        {
            HidePair();

            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                pictures[i].Left = (j++ * 80) + 100;
                pictures[i].Top = 20;
                pictures[i].Show();

            }
            j = 0;
            for (int i = 5; i < 10; i++)
            {
                pictures[i].Left = (j++ * 80) + 100;
                pictures[i].Top = 120;
                pictures[i].Show();

            }
            j = 0;
            for (int i = 10; i < 15; i++)
            {
                pictures[i].Left = (j++ * 80) + 100;
                pictures[i].Top = 220;
                pictures[i].Show();

            }
            j = 0;
            for (int i = 15; i < 20; i++)
            {
                pictures[i].Left = (j++ * 80) + 100;
                pictures[i].Top = 320;
                pictures[i].Show();

            }
           
        }

        private void ShowB_Click(object sender, EventArgs e)
        {
            ShuffelC();
            ShowB.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            lblStatus.Text = "Select Row number of each card of your pair and I will tell you your cards";
        }
       
        private void checkAll()   // Checking Radiobuttons are checked
        {
            Final f = new Final(2);

            if ((rbtnRow1_1.Checked == true && rbtnRow1_2.Checked == true))
            {
                f.MyAns(pictures[0], pictures[2]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

            if ((rbtnRow1_1.Checked == true && rbtnRow2_2.Checked == true)||(rbtnRow2_1.Checked == true && rbtnRow1_2.Checked == true))
            {
                f.MyAns(pictures[1], pictures[7]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow1_1.Checked == true && rbtnRow3_2.Checked == true) || (rbtnRow3_1.Checked == true && rbtnRow1_2.Checked == true))
            {
                f.MyAns(pictures[4], pictures[14]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow1_1.Checked == true && rbtnRow4_2.Checked == true) || (rbtnRow4_1.Checked == true && rbtnRow1_2.Checked == true))
            {
                f.MyAns(pictures[3], pictures[17]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

            if ((rbtnRow2_1.Checked == true && rbtnRow2_2.Checked == true))
            {
                f.MyAns(pictures[6], pictures[9]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow2_1.Checked == true && rbtnRow3_2.Checked == true) || (rbtnRow3_1.Checked == true && rbtnRow2_2.Checked == true))
            {
                f.MyAns(pictures[8], pictures[10]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow2_1.Checked == true && rbtnRow4_2.Checked == true) || (rbtnRow4_1.Checked == true && rbtnRow2_2.Checked == true))
            {
                f.MyAns(pictures[5], pictures[16]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow3_1.Checked == true && rbtnRow3_2.Checked == true))
            {
                f.MyAns(pictures[11], pictures[12]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow3_1.Checked == true && rbtnRow4_2.Checked == true) || (rbtnRow4_1.Checked == true && rbtnRow3_2.Checked == true))
            {
                f.MyAns(pictures[13], pictures[19]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            if ((rbtnRow4_1.Checked == true && rbtnRow4_2.Checked == true))
            {
                f.MyAns(pictures[15], pictures[18]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

        }

       

        private void About_Click(object sender, EventArgs e)
        {
            int b = 4;
            About a = new About(b);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void rbtnRow1_1_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow1_2_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow2_1_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow2_2_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow3_1_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow3_2_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow4_1_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }

        private void rbtnRow4_2_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
        }
    }
}
