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
        private List<Tile> tileList;

        //actualPlayer represents active name from TextBox: 0 - box1, 1 - box2
        private int actualPlayer;

        internal List<Tile> TileList { get => tileList; }
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


        public bool isTileSigned(int actualNr)
        {
            if (this.gameStarted && this.tileList[actualNr].Signed == false) return true;
            else return false;

        }
        public void resetPlayers(List<Player> players, string n1, string n2)
        {
            this.actualPlayer = 0;
            
            // TODO
            players[0].reset("o", true, n1);
            if(n2 != "Computer") players[1].reset("x", false, n2);
            else players[1].reset("x", false, "Player 2");
            players[2].reset("x", false, "Computer");
            
        }


        public void updateState(Label label, string actualName, string sign)
        {

            this.actualSign = sign;

            label.Text = actualName;

        }



        private void createList(List<PictureBox> picList)
        {
            this.tileList = new List<Tile>();
            for (int i = 0; i < this.boardSize; i++) 
            {
                this.tileList.Add(new Tile() { Sign = "", Name = picList[i].Name, Signed = false });
            }
            
        }


        public void updateList(int actualNr)
        {
            this.tileList[actualNr].Signed = true;
            this.tileList[actualNr].Sign = this.actualSign;
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
