using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    abstract class Computer : Player, IComputer
    {
        private Random rnd;
        private int lastRandom;


        public Computer(string s, string n, bool act = false) : base(s, n)
        {
            this.rnd = new Random();
        }

        public override int DrawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex)
        {
            this.lastRandom = ChooseTile(tileList);

            if (this.lastRandom != -1) picList[lastRandom].Image = Properties.Resources.x50;

            return this.lastRandom;
        }

        public virtual int ChooseTile(List<List<Tile>> tileList)
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

            if (emptyTile)
            {
                // find random empty tile
                int nr = rnd.Next(0, (int)Math.Pow(tileList.Count(), 2));
                if (array[nr] == 1) return nr;
                else return ChooseTile(tileList);

            }
            else return -1;
        }


        protected int CanWin(List<List<Tile>> tileList)
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
    }
}
