﻿using System;
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

        public string GetDescription() { return "string"; }
        public int PayOut(int Winner) { return 0; }
    }
}
