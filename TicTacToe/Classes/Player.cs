using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    abstract class Player : IPlayer
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
                if (value == "o" || value == "x")
                    sign = value;
                else throw new Exception("sign value should be 'o' or 'x'");
            }
        }

        internal string Name { get => name; set => name = value; }

        public abstract int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex);
        public abstract void Reset(string s, bool a, string n);



    }
}
