using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Player : IPlayer
    {
        protected string name;
        private string sign;
        protected bool active;
        


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
                return sign;
            }
            set
            {
                // allow only "o" and "x" property to set Sign
                if (value == "o" || value == "x")
                    sign = value;
            }
        }

        internal string Name { get => name; set => name = value; }

       


    }
}
