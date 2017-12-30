using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Human : Player, IHuman
    {
        public Human(string s, string n) : base(s, n)
        {

        }

        public override int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex)
        {
            int actualPicNumber = tileList[actualIndex[0]][actualIndex[1]].Nr;
            picList[actualPicNumber].Image = this.Sign == "x" ? Properties.Resources.x50 : Properties.Resources.o50;


            return actualPicNumber;
        }




    }
}
