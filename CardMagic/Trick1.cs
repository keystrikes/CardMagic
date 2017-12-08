using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace CardMagic
{
    public partial class Trick1 : Form
    {
        
        private PictureBox[] pictures;  //to store random cards images
        private PictureBox[] pictures1;  //1st row card images
        private PictureBox[] pictures2;  //2nd row card images
        private PictureBox[] pictures3;  //3rd row card images
        public static int shuffelCount = 0;
        public Trick1()
        {
            InitializeComponent();
            pictures = new PictureBox[53];
            pictures1 = new PictureBox[7];
            pictures2 = new PictureBox[7];
            pictures3 = new PictureBox[7];
            ShowCards();

        }
        public void PickDeck()
        {
            //using Random class generate random numbers and shuffeing cards in picturebox so every time cards will not be same
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
        public void ShowCards()
        {
            shuffelCount = 0;
           DisplayInstruction();
            CreateControls();
            PickDeck();
            DistributeCards();
            DisplayCards();
        }


        private void CreateControls()
        {
            //assign images to picturebox

            for (var i = 0; i < 53; i++)
            {
                var newPicBox = new PictureBox();
                newPicBox.Width = 75;
                newPicBox.Height = 90;
                newPicBox.BorderStyle = BorderStyle.Fixed3D;

                pictures[i] = SizeImage(newPicBox, i + 1);
            }

        }
        private void DistributeCards()
        {
            shuffelCount++;
            int i;
            int j = 0;
            for (i = 0; i < 21;) //distribute cards in 3 rows
            {
                pictures1[j] = pictures[i];
                pictures2[j] = pictures[++i];
                pictures3[j] = pictures[++i];
                i++;
                j++;
            }
        }

        private PictureBox SizeImage(PictureBox Pb, int i)
        {
            //assign image from Resources

            ResourceManager rm = Properties.Resources.ResourceManager;

            Image img = (Bitmap)rm.GetObject(string.Format("{0}", i));
           
            Pb.Image = img;
            Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            return Pb;
        }


        public void DisplayInstruction()
        {
            //Show instruction for every step
            if (shuffelCount == 0)
            {
                MainInstru.Text = "Keep one Card in your mind and Click Row Button in which your card is";
            }
            else if (shuffelCount == 1)
            {
                MainInstru.Text = "Click Row button of your Card again ";
            }
            else if (shuffelCount == 2)
            {
                MainInstru.Text = "Dont Worry this is Last time Click row button of your card ";
            }
        }
        private void DisplayCards()
        {
            //Show cards on Form

            for (var i = 0; i < 7; i++)
            {
                pictures1[i].Left = (i * 80) + 100;
                pictures1[i].Top = 20;

                this.Controls.Add(pictures1[i]);

            }
            for (var i = 0; i < 7; i++)
            {
                pictures2[i].Left = (i * 80) + 100;
                pictures2[i].Top = 120;
                this.Controls.Add(pictures2[i]);

            }

            for (var i = 0; i < 7; i++)
            {
                pictures3[i].Left = (i * 80) + 100;
                pictures3[i].Top = 220;
                this.Controls.Add(pictures3[i]);
            }
        }
       

        private void Row1Selected()   //storing cards in sequence Row 2, row 1, row 3
        {

            int j;
            for (int i = 0; i < 7; i++)
            {
                pictures[i] = pictures2[i];

            }
            j = 0;
            for (int i = 7; i < 14; i++)
            {
                pictures[i] = pictures1[j++];

            }
            j = 0;
            for (int i = 14; i < 21; i++)
            {
                pictures[i] = pictures3[j++];

            }


        }

        private void Row2Selected()    //storing cards in sequence Row 3, row 2, row 1
        {

            int j;
            for (int i = 0; i < 7; i++)
            {
                pictures[i] = pictures3[i];

            }
            j = 0;
            for (int i = 7; i < 14; i++)
            {
                pictures[i] = pictures2[j++];

            }
            j = 0;
            for (int i = 14; i < 21; i++)
            {
                pictures[i] = pictures1[j++];

            }

        }
        private void Row3Selected()   //storing cards in sequence Row 1, row 3, row 2
        {

            int j;
            for (int i = 0; i < 7; i++)
            {
                pictures[i] = pictures1[i];

            }
            j = 0;
            for (int i = 7; i < 14; i++)
            {
                pictures[i] = pictures3[j++];

            }
            j = 0;
            for (int i = 14; i < 21; i++)
            {
                pictures[i] = pictures2[j++];

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (shuffelCount != 3)
            {
                DisplayInstruction();
                Row1Selected();
                DistributeCards();
                DisplayCards();
            }
            else
            {
                Final f = new Final(1);
                f.AnswerCard(pictures1[3]);
                this.Hide();
                f.ShowDialog();
                this.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (shuffelCount != 3)
            {
                DisplayInstruction();
                Row2Selected();
                DistributeCards();
                DisplayCards();
            }
            else
            {
                Final f = new Final(1);
                f.AnswerCard(pictures2[3]);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (shuffelCount != 3)
            {
                DisplayInstruction();
                Row3Selected();
                DistributeCards();
                DisplayCards();
            }
            else
            {
                Final f = new Final(1);
                f.AnswerCard(pictures3[3]);
                this.Hide();
                f.ShowDialog();
                this.Close();

            }


        }

        private void RestartB_Click(object sender, EventArgs e)
        {
            Trick1 again = new Trick1();
            this.Hide();
            again.ShowDialog();
            Close();
            again.ShowCards();
        }

        private void AboutLM_Click(object sender, EventArgs e)
        {

            int b = 2;
            About a = new About(b);
            this.Hide();
            a.ShowDialog();
            this.Close();

        }

    }
}
