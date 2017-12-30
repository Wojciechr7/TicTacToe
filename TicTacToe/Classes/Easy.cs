using System.Collections.Generic;

namespace TicTacToe.classes
{
    class Easy : Computer, IComputerMode
    {

        public Easy(string s, string n) : base(s, n)
        {

        }



        public override int ChooseTile(List<List<Tile>> tileList)
        {

            int winningTile = base.CanWin(tileList);

            if (winningTile != -1) return winningTile;

            return base.ChooseTile(tileList);
        }
    }
}
