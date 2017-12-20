using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Computer : Player
    {
        private bool activated;
        private Random rnd = new Random();
        private int lastRandom;

        public bool Activated { get => activated; set => activated = value; }

        public Computer(string s = "o", bool a = true, string n = "NO PLAYER NAME", bool act = false) : base(s, a, n)
        {

            this.activated = act;
        }

        public override void Reset(string s, bool a, string n)
        {
            this.Sign = s;
            this.name = n;

        }
        public override int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex)
        {
            this.lastRandom = ChooseRandom(tileList, actualIndex);

            if (this.lastRandom != -1) picList[lastRandom].Image = Properties.Resources.x50;

            return this.lastRandom;
        }


        public int ChooseRandom(List<List<Tile>> tileList, int[] actual)
        {
           
            bool emptyTile = false;
            int[] array = new int[(int)Math.Pow(tileList.Count(), 2)];
            int index = 0;
            foreach (var row in tileList)
                foreach (var item in row)
                {

                    if (item.Signed == false)
                    {
                        array[index] = 1;
                        emptyTile = true;
                    }
                    else array[index] = 0;
                    index++;
                }
            int hard()
            {
                int winningTile = canWin();

                if (winningTile != -1) return winningTile;

                for (int i = 0; i < tileList.Count; i++)
                {
                    int counterHorizontal = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        // increase counter when human sign found in one line
                        if (tileList[i][j].Signed && tileList[i][j].Sign == "o")
                            counterHorizontal++;

                        // break when line is marked by computer
                        if (tileList[i][j].Sign == "x") break;

                        // 2 human signs found in one line
                        if (counterHorizontal == 2)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                // find first empty tile
                                if (!tileList[i][k].Signed)
                                {
                                    // return number of tile to block horizontal line
                                    return tileList[i][k].Nr;
                                }
                            }
                            break;
                        }
                    }
                }


                for (int i = 0; i < tileList.Count; i++)
                {
                    int counterVertical = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        if (tileList[j][i].Signed && tileList[j][i].Sign == "o")
                            counterVertical++;

                        if (tileList[j][i].Sign == "x") break;

                        if (counterVertical == 2)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (!tileList[k][i].Signed)
                                {
                                    // block vertical line
                                    return tileList[k][i].Nr;
                                }
                            }
                            break;
                        }
                    }
                }

                int counterDiag = 0;
                for (int i = 0; i < tileList.Count; i++)
                {
                    if (tileList[i][i].Signed && tileList[i][i].Sign == "o")
                        counterDiag++;

                    if (tileList[i][i].Sign == "x") break;

                    if (counterDiag == 2)
                    {

                        for (int k = 0; k < 3; k++)
                        {
                            if (!tileList[k][k].Signed)
                            {
                                // block diagonal line
                                return tileList[k][k].Nr;
                            }
                        }
                        break;
                    }
                }


                int counterAntiDiag = 0;
                for (int i = 0; i < tileList.Count; i++)
                {
                    if (tileList[i][(tileList.Count - 1) - i].Signed && tileList[i][(tileList.Count - 1) - i].Sign == "o")
                        counterAntiDiag++;

                    if (tileList[i][(tileList.Count - 1) - i].Sign == "x") break;

                    if (counterAntiDiag == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (!tileList[k][(tileList.Count - 1) - k].Signed)
                            {
                                // block anti-diagonal line
                                return tileList[k][(tileList.Count - 1) - k].Nr;
                            }
                        }
                        break;
                    }
                }


                return rand();
            }
            int canWin()
            {
                
                 for (int i = 0; i < tileList.Count; i++)
                  {
                    int horizontalCounter = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        if (tileList[i][j].Signed && tileList[i][j].Sign == "x")
                            horizontalCounter++;

                        if (tileList[i][j].Sign == "o") break;

                        if (horizontalCounter == tileList.Count - 1)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (!tileList[i][k].Signed)
                                {
                                    // horizontal winning tile
                                    return tileList[i][k].Nr;
                                }
                            }
                            break;
                        }
                    }
                }


                for (int i = 0; i < tileList.Count; i++)
                {
                    int verticalCounter = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        if (tileList[j][i].Signed && tileList[j][i].Sign == "x")
                            verticalCounter++;

                        if (tileList[j][i].Sign == "o") break;

                        if (verticalCounter == tileList.Count - 1)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (!tileList[k][i].Signed)
                                {
                                    // vertical winning tile
                                    return tileList[k][i].Nr;
                                }
                            }
                            break;
                        }
                    }
                }
                

                int diagonalCounter = 0;
                for (int j = 0; j < tileList.Count; j++)
                {
                    if (tileList[j][j].Signed && tileList[j][j].Sign == "x")
                        diagonalCounter++;

                    if (tileList[j][j].Sign == "o") break;

                    if (diagonalCounter == tileList.Count - 1)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (!tileList[k][k].Signed)
                            {
                                // diagonal winning tile
                                return tileList[k][k].Nr;
                            }
                        }
                        break;
                    }
                }
                
                int antiDiagonalCounter = 0;
                for (int j = 0; j < tileList.Count; j++)
                {
                    if (tileList[j][(tileList.Count - 1) - j].Signed && tileList[j][(tileList.Count - 1) - j].Sign == "x")
                        antiDiagonalCounter++;

                    if (tileList[j][(tileList.Count - 1) - j].Sign == "o") break;

                    if (antiDiagonalCounter == tileList.Count - 1)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (!tileList[k][(tileList.Count - 1) - k].Signed)
                            {
                                // anti-diagonal winning tile
                                return tileList[k][(tileList.Count - 1) - k].Nr;
                            }
                        }
                        break;
                    }
                }

                return -1;
            }

            int rand()
            {
                if (emptyTile)
                {
                    // find random empty tile
                    int nr = rnd.Next(0, (int)Math.Pow(tileList.Count(), 2));
                    if (array[nr] == 1) return nr;
                    else return rand();

                }
                else return -1;

            }

            return hard();
        }



    }
}
