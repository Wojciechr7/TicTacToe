using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    interface IBoard
    {
        int ActualPlayer { get; set; }

        bool checkWinner();
        bool isTileSigned(int actualNr);
        void resetPlayers(List<Human> humans, List<Computer> computers, string n1, string n2);
        void startGame(List<PictureBox> picList);
        void updateList(int actualNr);
        void updateState(Label label, string actualName, string sign);
    }
}