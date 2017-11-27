using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Game
    {
        private int rowSize;




        public Game(int rs)
        {
            this.rowSize = rs;
        }



        public void StartGame(List<PictureBox> picList, Board board)
        {

            // set white background for all tiles
            foreach (var c in picList)
                c.Image = Properties.Resources.blank50;

            board.CreateList(picList);
        }

        public void UpdateList(int[] actualIndex, List<List<Tile>> tileList, string actualSign)
        {
            tileList[actualIndex[0]][actualIndex[1]].Signed = true;
            tileList[actualIndex[0]][actualIndex[1]].Sign = actualSign;
        }



        public bool CheckWinner(int[] index, List<List<Tile>> tileList, string actualSign)
        {
            // win checker idea inspired by:
            // https://stackoverflow.com/questions/1056316/algorithm-for-determining-tic-tac-toe-game-over

            // n - number of squares in a row to check
            int n = this.rowSize;

            for (int i = 0; i < n; i++)
            {
                // break when one of the squares in a row is actually marked by the opponents Sign
                if (!tileList[index[0]][i].Signed || tileList[index[0]][i].Sign != actualSign)
                    break;
                // return true if loop was not broken
                if (i == n - 1)
                {
                    // winner found: horizontal
                    return true;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!tileList[i][index[1]].Signed || tileList[i][index[1]].Sign != actualSign)
                    break;
                if (i == n - 1)
                {
                    // winner found: vertical
                    return true;
                }
            }

            if (index[0] == index[1])
            {
                for (int i = 0; i < n; i++)
                {
                    if (!tileList[i][i].Signed || tileList[i][i].Sign != actualSign)
                        break;
                    if (i == n - 1)
                    {
                        // winner found: diagonal
                        return true;
                    }
                }
            }

            if (index[0] + index[1] == n - 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!tileList[i][(n - 1) - i].Signed || tileList[i][(n - 1) - i].Sign != actualSign)
                        break;
                    if (i == n - 1)
                    {
                        // // winner found: anti-diagonal
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
