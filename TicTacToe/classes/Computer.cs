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

        public override void reset(string s, bool a, string n)
        {
            this.Sign = s;
            this.name = n;

        }
        public override int drawImage(List<PictureBox> picList, List<List<Tile>> tileList, int[] actualIndex)
        {
            this.lastRandom = chooseRandom(tileList, actualIndex);

            if (this.lastRandom != -1) picList[lastRandom].Image = Properties.Resources.x50;

            return this.lastRandom;
        }


        public int chooseRandom(List<List<Tile>> tileList, int[] actual)
        {

            bool emptyTile = false;
            int[] array = new int[9];
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

                    //  Console.WriteLine(array[index]);
                    index++;


                }

            int rand()
            {
                if (emptyTile)
                {

                    int nr = rnd.Next(0, 9);
                    if (array[nr] == 1) return nr;
                    else return rand();

                }
                else return -1;

            }

            return rand();
        }
    }
}
