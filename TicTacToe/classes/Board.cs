using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.classes
{
    class Board
    {
        public bool gameStarted;
        public string actualSign;
        public List<Tile> tileList;

        public Board()
        {
            this.gameStarted = false;
            
        }
        public void switchSign()
        {
            this.actualSign = this.actualSign == "o" ? "x" : "o";
        }

    
        public void createList(List<System.Windows.Forms.PictureBox> picList)
        {
            this.tileList = new List<Tile>();
            for (int i = 0; i < 9; i++) 
            {
                this.tileList.Add(new Tile() { Sign = "", Name = picList[i].Name, Signed = false });
            }
            
        }

        public bool checkWinner()
        {
            // horizontal
            if (this.tileList[0].Signed == true && this.tileList[0].Sign == this.tileList[1].Sign && this.tileList[0].Sign == this.tileList[2].Sign) return true;
            if (this.tileList[3].Signed == true && this.tileList[3].Sign == this.tileList[4].Sign && this.tileList[3].Sign == this.tileList[5].Sign) return true;
            if (this.tileList[6].Signed == true && this.tileList[6].Sign == this.tileList[7].Sign && this.tileList[6].Sign == this.tileList[8].Sign) return true;

            // vertical
            if (this.tileList[0].Signed == true && this.tileList[0].Sign == this.tileList[3].Sign && this.tileList[0].Sign == this.tileList[6].Sign) return true;
            if (this.tileList[1].Signed == true && this.tileList[1].Sign == this.tileList[4].Sign && this.tileList[1].Sign == this.tileList[7].Sign) return true;
            if (this.tileList[2].Signed == true && this.tileList[2].Sign == this.tileList[5].Sign && this.tileList[2].Sign == this.tileList[8].Sign) return true;

            // diagonal
            if (this.tileList[6].Signed == true && this.tileList[6].Sign == this.tileList[4].Sign && this.tileList[6].Sign == this.tileList[2].Sign) return true;
            if (this.tileList[0].Signed == true && this.tileList[0].Sign == this.tileList[4].Sign && this.tileList[0].Sign == this.tileList[8].Sign) return true;
            return false;
        }

    }
}
