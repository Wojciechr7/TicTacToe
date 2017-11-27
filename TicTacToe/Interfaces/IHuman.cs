using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IHuman
    {
        string choosePlayerSign();
        void drawImage(PictureBox element);
        void reset(string s, bool a, string n);
    }
}