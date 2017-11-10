﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.classes
{
    class Computer : Player
    {
        public bool activated;
        private Random rnd = new Random();

        public Computer(string s = "o", bool a = true, string n = "NO PLAYER NAME", bool act = false) : base(s, a, n)
        {
            
            this.activated = act;
        }

        public int chooseRandom(List<Tile> tileList,int actual)
        {
           
            bool emptyTile = false;
            int[] array = new int[9];
            int index = 0;
            foreach (var item in tileList)
            {
                
                if (item.Signed == false)
                {
                    array[index] = 1;
                    emptyTile = true;
                }else array[index] = 0;
                index++;
            }
            
            int rand()
            {
                if (emptyTile)
                {
                    
                    int nr = rnd.Next(0, 9);
                    if (array[nr] == 1) return nr;
                    else return rand();

                }else return -1;
                
            }

            return rand();
        }
    }
}