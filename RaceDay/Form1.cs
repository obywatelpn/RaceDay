using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceDay
{
    public partial class Form1 : Form
    {
        private List<Guy> guyList = new List<Guy>();
        private List<Greyhound> greyhoundList = new List<Greyhound>();

        public Form1()
        {
            InitializeComponent();

            guyList.Add(new Guy("Janek", 50, radioButton1, label1));
            guyList.Add(new Guy("Bartek", 75, radioButton2, label2));
            guyList.Add(new Guy("Arek", 45, radioButton3, label3));

            greyhoundList.Add(new Greyhound(pictureBox2));
            greyhoundList.Add(new Greyhound(pictureBox3));
            greyhoundList.Add(new Greyhound(pictureBox4));
            greyhoundList.Add(new Greyhound(pictureBox5));

            label5.Text = numericUpDown1.Minimum.ToString() + " zł";
            RegenetateForm();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void RegenetateForm()
        {
            foreach (Guy person in guyList)
            {
                person.UpdateLabels();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var guy in guyList)
            {
                if (guy.MyRadioButton.Checked)
                {
                    guy.PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                    guy.UpdateLabels();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var counter = 0;

            foreach (var guy in guyList)
            {
                if (guy.MyBet != null)
                {
                    counter++;
                }
            }
            if (counter == 3)
            {
                DisableButtonsAndRadio(true);
                var winner = false;
                int dogNumber = 0;
                while (winner == false)
                {
                    dogNumber = 0;
                    foreach (var dog in greyhoundList)
                    {
                        winner = dog.Run();
                        dogNumber++;
                        if (winner)
                        {
                            MessageBox.Show("Zwyciezca: Pies numer " + dogNumber);
                            foreach (var guy in guyList)
                            {
                                guy.Collect(dogNumber);
                                //guy.MyBet.Dog
                            }
                            DisableButtonsAndRadio(false);
                            RestartRace();
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(5);
                }
            }
            else
            {
                MessageBox.Show("Nie wszystkie zakłady zostały zawarte");
                DisableButtonsAndRadio(false);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = radioButton3.Text;
        }
        private void DisableButtonsAndRadio(bool disable)
        {
            switch (disable)
            {
                case (true):
                    button2.Enabled = false;
                    button1.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    break;
                case (false):
                    button2.Enabled = true;
                    button1.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton1.Checked = true;
                    break;
            }
        }
        private void RestartRace()
        {
            foreach (Greyhound dog in greyhoundList)
            {
                dog.TakeStartingPosition();
            }
            foreach (var guy in guyList)
            {
                guy.MyBet = null;
            }
            RegenetateForm();
        }
    }
}
