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
            guyList.Add(new Guy());
            greyhoundList.Add(new Greyhound());

            InitializeComponent();
        }
    }
}
