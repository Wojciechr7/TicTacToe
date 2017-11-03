using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.classes
{
    class Player
    {
        public string name;
        private string _sign;
        private bool active;


        public Player(string s = "o", bool a = true, string n = "NO PLAYER NAME")
        {         
            this.Sign = s;
            this.active = a;
            this.name = n;
        }

        public string Sign
        {
            get
            {
                return _sign;
            }
            set
            {
                // allow only "o" and "x" property to set Sign
                if (value == "o" || value == "x")
                    _sign = value;
            }
        }

        public string Turn()
        {
            if (this.active) return this.name;
            return "";
        }


    }
}
