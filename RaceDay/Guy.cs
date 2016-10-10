using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceDay
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guy(string name, int cash, RadioButton myRadioButton, Label myLabel) {
            this.Name = name;
            this.Cash = cash;
            MyBet = null;
            this.MyRadioButton = myRadioButton;
            this.MyLabel = myLabel;
        }

        public void UpdateLabels() { }
        public void ClearBet() { }
        public bool PlaceBet(int Amount, int Dog) { }

        public void Collect(int Winner) { }
    }
}
