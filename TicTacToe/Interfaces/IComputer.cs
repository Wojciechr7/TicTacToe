using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IComputer
    {
        int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex);
        void Reset(string s, bool a, string n);
    }
}