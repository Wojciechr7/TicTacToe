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


                for (int i = 0; i < tileList.Count; i++)
                {
                    int counter = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        if (tileList[i][j].Signed && tileList[i][j].Sign == "o")
                            counter++;

                        if (tileList[i][j].Sign == "x") break;

                        if (counter == 2)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (!tileList[i][k].Signed)
                                {
                                    return tileList[i][k].Nr;
                                }
                            }
                            break;
                        }

                    }
                }


                for (int i = 0; i < tileList.Count; i++)
                {
                    int counter = 0;
                    for (int j = 0; j < tileList.Count; j++)
                    {
                        if (tileList[j][i].Signed && tileList[j][i].Sign == "o")
                            counter++;

                        if (tileList[j][i].Sign == "x") break;

                        if (counter == 2)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (!tileList[k][i].Signed)
                                {
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
                                return tileList[k][(tileList.Count - 1) - k].Nr;
                            }
                        }
                        break;
                    }
                }





                return rand();

            }

            int rand()
            {
                if (emptyTile)
                {

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
