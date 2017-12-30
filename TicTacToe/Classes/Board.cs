using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe.classes
{
    class Board : IBoard
    {
        private string actualSign;
        private int rowSize;
        private List<List<Tile>> tileList;



        internal List<List<Tile>> TileList { get => tileList; }
        public int ActualPlayer
        {
            get => actualPlayer;
            set
            {
                if (value == 0 || value == 1)
                    actualPlayer = value;
                else throw new ArgumentOutOfRangeException("actualPlayer value should be 0 or 1");
            }
        }
        public string ActualSign { get => actualSign; set => actualSign = value; }



        //actualPlayer: 0 - player 1 / 1 - player 2
        private int actualPlayer;

        public Board(int rs = 3)
        {
            this.rowSize = rs;
        }

        public bool IsTileSigned(int[] actualIndex)
        {

            if (this.tileList[actualIndex[0]][actualIndex[1]].Signed == false)
            {
                return true;
            }
            else return false;


        }

        public void UpdateState(Form label, string actualName, string sign)
        {
            this.actualSign = sign;
            label.Text = "TicTacToe (actual player: " + actualName + ")";
        }

        public void CreateList(List<PictureBox> picList)
        {
            this.tileList = new List<List<Tile>>();
            int index = 0;
            for (int i = 0; i < this.rowSize; i++)
            {
                this.tileList.Add(new List<Tile>());
                for (int j = 0; j < this.rowSize; j++)
                {
                    picList[index].Tag = new int[2] { i, j };
                    this.tileList[i].Add(new Tile() { Sign = "", Name = picList[index].Name, Signed = false, Nr = index++ });

                }
            }
        }



        public bool IsBoardFull()
        {
            foreach (var row in this.tileList)
                foreach (var item in row)
                    if (!item.Signed) return false;
            return true;
        }
    }
}
