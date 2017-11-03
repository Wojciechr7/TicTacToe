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
    }
}
