using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IComputer
    {
        bool Activated { get; set; }

        int chooseRandom(List<Tile> tileList, int actual);
        void drawImage(PictureBox element);
        void reset(string s, string n);
    }
}