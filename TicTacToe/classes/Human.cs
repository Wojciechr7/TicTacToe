using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Human : Player
    {
        public Human(string s = "o", bool a = true, string n = "NO PLAYER NAME") : base(s, a, n)
        {
            
        }

        public string choosePlayerSign()
        {
            if (this.active == true) return "o";
            else return "x";
        }
        public void reset(string s, bool a, string n)
        {
            this.Sign = s;
            this.active = a;
            this.name = n;

        }
        public void drawImage(PictureBox element)
        {
            element.Image = this.Sign != "x" ? Properties.Resources.x50 : Properties.Resources.o50;
        }


    }
}
