using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IBoard
    {
        int ActualPlayer { get; set; }
        string ActualSign { get; set; }

        void CreateList(List<PictureBox> picList);
        bool IsBoardFull();
        bool IsTileSigned(int[] actualIndex);
        void UpdateState(Form label, string actualName, string sign);
    }
}