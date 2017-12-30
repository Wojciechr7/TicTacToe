using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    abstract class Player : IPlayer
    {
        protected string name;
        private string sign;
        


        public Player(string s, string n)
        {         
            this.Sign = s;
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

        public string Name { get => name; set => name = value; }

        public abstract int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex);



    }
}
