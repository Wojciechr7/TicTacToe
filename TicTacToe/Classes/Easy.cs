using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Easy : Computer, IEasy
    {

        public Easy(string s = "o", bool a = true, string n = "NO PLAYER NAME", bool act = false) : base(s, a, n)
        {

        }



        public override int ChooseTile(List<List<Tile>> tileList)
        {

            int winningTile = base.CanWin(tileList);

            if (winningTile != -1) return winningTile;

            return Rand(tileList);
        }



    }
}
