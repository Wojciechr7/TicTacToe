﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.classes
{
    // this class is used by Board method CreateList()
    class Tile
    {
        public string Sign { get; set; }
        public string Name { get; set; }
        public bool Signed { get; set; }
        public int Nr { get; set; }
    }
}
