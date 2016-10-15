﻿using System;
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

            greyhoundList.Add(new Greyhound(pictureBox1));
            greyhoundList.Add(new Greyhound(pictureBox2));
            greyhoundList.Add(new Greyhound(pictureBox3));
            greyhoundList.Add(new Greyhound(pictureBox4));

            label5.Text = numericUpDown1.Minimum.ToString();
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
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var counter = 0;
            foreach (var guy in guyList)
            {
                if (guy.MyBet!=null)
                {
                    counter++;
                }
            }
            if (counter==3)
            {

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
    }
}
