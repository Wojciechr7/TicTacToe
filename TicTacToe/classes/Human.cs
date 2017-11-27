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

        public string ChoosePlayerSign()
        {
            if (this.active == true) return "o";
            else return "x";
        }
        public override void Reset(string s, bool a, string n)
        {
            this.Sign = s;
            this.active = a;
            this.name = n;

        }
        public override int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex)
        {
            int actualPicNumber = tileList[actualIndex[0]][actualIndex[1]].Nr;
            picList[actualPicNumber].Image = this.Sign == "x" ? Properties.Resources.x50 : Properties.Resources.o50;


            return actualPicNumber;
        }




    }
}
