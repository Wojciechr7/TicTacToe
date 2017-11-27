using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Board
    {
        private bool gameStarted;
        private string actualSign;
        private int boardSize;
        private List<List<Tile>> tileList;


        //actualPlayer: 0 - player 1 / 1 - player 2
        private int actualPlayer;

        internal List<List<Tile>> TileList { get => tileList; }

        public int ActualPlayer { get => actualPlayer; set => actualPlayer = value; }


        public Board(int bs = 9)
        {
            this.gameStarted = false;
            this.boardSize = bs;
        }


        public void StartGame(List<PictureBox> picList)
        {
            this.gameStarted = true;

            // set white background for all tiles
            foreach (var c in picList)
                c.Image = Properties.Resources.blank50;

            this.CreateList(picList);
        }


        public bool IsTileSigned(int[] actualIndex)
        {

            if (this.gameStarted && this.tileList[actualIndex[0]][actualIndex[1]].Signed == false)
            {
                return true;
            }
            else return false;


        }

        public void UpdateState(Form label, string actualName, string sign)
        {
            this.actualSign = sign;
            label.Text = "TicTacToe (actual player: " + actualName + ")";
        }



        private void CreateList(List<PictureBox> picList)
        {
            this.tileList = new List<List<Tile>>();
            int index = 0;
            for (int i = 0; i < Math.Sqrt(this.boardSize); i++)
            {
                this.tileList.Add(new List<Tile>());
                for (int j = 0; j < Math.Sqrt(this.boardSize); j++)
                {
                    picList[index].Tag = new int[2] { i, j };
                    this.tileList[i].Add(new Tile() { Sign = "", Name = picList[index].Name, Signed = false, Nr = index++ });

                }
            }



            for (int i = 0; i < Math.Sqrt(this.boardSize); i++)
            {
                for (int j = 0; j < Math.Sqrt(this.boardSize); j++)
                {
                    //  Console.WriteLine(this.tileList[i][j].Name);

                }
            }
        }


        public void UpdateList(int[] actualIndex)
        {
            this.tileList[actualIndex[0]][actualIndex[1]].Signed = true;
            this.tileList[actualIndex[0]][actualIndex[1]].Sign = this.actualSign;
        }


        public bool CheckWinner(int[] index)
        {
            // win checker idea inspired by:
            // https://stackoverflow.com/questions/1056316/algorithm-for-determining-tic-tac-toe-game-over

            // n - number of squares in a row to check
            int n = (int)Math.Sqrt(boardSize);

            for (int i = 0; i < n; i++)
            {
                // break when one of the squares in a row is actually marked by the opponents Sign
                if (!this.tileList[index[0]][i].Signed || this.tileList[index[0]][i].Sign != this.actualSign)
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
                if (!this.tileList[i][index[1]].Signed || this.tileList[i][index[1]].Sign != this.actualSign)
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
                    if (!this.tileList[i][i].Signed || this.tileList[i][i].Sign != this.actualSign)
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
                    if (!this.tileList[i][(n - 1) - i].Signed || this.tileList[i][(n - 1) - i].Sign != this.actualSign)
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
