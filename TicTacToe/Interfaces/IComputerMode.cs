using System.Collections.Generic;

namespace TicTacToe.classes
{
    interface IComputerMode
    {
        int ChooseTile(List<List<Tile>> tileList);
    }
}