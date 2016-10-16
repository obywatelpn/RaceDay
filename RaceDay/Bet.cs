using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public Bet(int amount, int Dog, Guy guy)
        {
            this.Amount = amount;
            this.Dog = Dog;
            this.Bettor = guy;
        }

        public string GetDescription()
        {
            if (Amount>0)
            {
                return Bettor.Name + " postawił " + Amount + " na psa numer " + Dog;
            }
            return Bettor.Name+" nie postawił zakładu";
        }
        public int PayOut(int Winner)
        {
            if (Winner==Dog)
            {
                return Amount; 
            }
            return Amount * -1;
        }
    }
}
