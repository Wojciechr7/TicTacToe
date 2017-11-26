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


        public void startGame(List<PictureBox> picList)
        {
            this.gameStarted = true;

            // set white background for all tiles
            foreach (var c in picList)
                c.Image = Properties.Resources.blank50;

            this.createList(picList);
        }


        public bool isTileSigned(int[] actualIndex)
        {

            if (this.gameStarted && this.tileList[actualIndex[0]][actualIndex[1]].Signed == false)
            {
                return true;
            }
            else return false;


        }

        public void updateState(Form label, string actualName, string sign)
        {
            this.actualSign = sign;
            label.Text = "TicTacToe (actual player: " + actualName + ")";
        }



        private void createList(List<PictureBox> picList)
        {
            this.tileList = new List<List<Tile>>();

            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                this.tileList.Add(new List<Tile>());
                for (int j = 0; j < 3; j++)
                {
                    picList[index].Tag = new int[2] { i, j };
                    this.tileList[i].Add(new Tile() { Sign = "", Name = picList[index].Name, Signed = false, Nr = index++ });

                }
            }



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //  Console.WriteLine(this.tileList[i][j].Signed);

                }
            }
        }


        public void updateList(int[] actualIndex)
        {
            this.tileList[actualIndex[0]][actualIndex[1]].Signed = true;
            this.tileList[actualIndex[0]][actualIndex[1]].Sign = this.actualSign;
        }


        public bool checkWinner(int[] index)
        {
            // win checker idea inspired by:
            // https://stackoverflow.com/questions/1056316/algorithm-for-determining-tic-tac-toe-game-over

            int n = 3;

            for (int i = 0; i < n; i++)
            {
                if (!this.tileList[index[0]][i].Signed || this.tileList[index[0]][i].Sign != this.actualSign)
                    break;
                if (i == n - 1)
                {
                    // horizontal win
                    return true;
                }
            }


            for (int i = 0; i < n; i++)
            {
                if (!this.tileList[i][index[1]].Signed || this.tileList[i][index[1]].Sign != this.actualSign)
                    break;
                if (i == n - 1)
                {
                    // vertical win
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
                        // diagonal win
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
                        // anti-daigonal win
                        return true;
                    }
                }
            }



            return false;


        }
    }
}
