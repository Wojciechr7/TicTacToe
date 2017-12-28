using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IPlayer
    {
        string Sign { get; set; }

        int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex);
        void Reset(string s, bool a, string n);
    }
}