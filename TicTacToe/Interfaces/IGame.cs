using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IGame
    {
        bool CheckWinner(int[] index, List<List<Tile>> tileList, string actualSign);
        void CreatePlayersList(TextBox tb1, TextBox tb2);
        void StartGame(List<PictureBox> picList, Board board, TextBox tb1, TextBox tb2);
        void UpdateList(int[] actualIndex, List<List<Tile>> tileList, string actualSign);
    }
}