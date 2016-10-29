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
        private readonly List<Greyhound> _greyhoundList = new List<Greyhound>();
        private static DialogResult _dialogResult;
        private const string DogWinns = "Zwyciezca: Pies numer ";

        internal List<Guy> GuyList { get; } = new List<Guy>();

        public Form1()
        {
            InitializeComponent();

            GuyList.Add(new Guy("Janek", 50, radioButton1, label1));
            GuyList.Add(new Guy("Bartek", 75, radioButton2, label2));
            GuyList.Add(new Guy("Arek", 45, radioButton3, label3));

            _greyhoundList.Add(new Greyhound(pictureBox2));
            _greyhoundList.Add(new Greyhound(pictureBox3));
            _greyhoundList.Add(new Greyhound(pictureBox4));
            _greyhoundList.Add(new Greyhound(pictureBox5));

            label5.Text = numericUpDown1.Minimum.ToString() + " zł";
            RegenetateForm();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void RegenetateForm()
        {
            foreach (var person in GuyList)
            {
                person.UpdateLabels();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var guy in GuyList)
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

            foreach (var guy in GuyList)
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
                while (winner == false)
                {
                    var dogNumber = 0;
                    foreach (var dog in _greyhoundList)
                    {
                        winner = dog.Run();
                        dogNumber++;
                        if (winner)
                        {
                            _dialogResult = MessageBox.Show(DogWinns + dogNumber);
                            foreach (var guy in GuyList)
                            {
                                guy.Collect(dogNumber);
                            }
                            DisableButtonsAndRadio(false);
                            RestartRace();
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(3);
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
            foreach (Greyhound dog in _greyhoundList)
            {
                dog.TakeStartingPosition();
            }
            foreach (var guy in GuyList)
            {
                guy.MyBet = null;
            }
            RegenetateForm();
        }
    }
}
