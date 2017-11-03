using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.classes;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Player player1;
        Player player2;
        Board game;


        public Form1()
        {
            InitializeComponent();
            this.createList();
            this.label2.Text = "";
            this.game = new Board();
            this.game.createList(this.picList);

        }

        // start game button event
        private void button1_Click(object sender, EventArgs e)
        {
            // game start field
            this.game.gameStarted = true;

            // create Player instances
            this.player1 = this.textBox1.Text == "" ? new Player("o", true) : new Player("o", true, this.textBox1.Text);
            this.player2 = this.textBox2.Text == "" ? new Player("x", false) : new Player("x", false, this.textBox2.Text);


            // set white background for all tiles
            foreach (var c in this.picList)
                c.Image = Properties.Resources.blank50;

            this.updateState();

        }

        private void TileClickEvent(object sender, EventArgs e)
        {
            int actualNr = (int)Char.GetNumericValue((sender as PictureBox).Name[10]) - 1;
            if (this.game.gameStarted && this.game.tileList[actualNr].Signed == false)
            {
                

                this.game.tileList[actualNr].Signed = true;
                this.game.tileList[actualNr].Sign = this.game.actualSign;



                (sender as PictureBox).Image = this.game.actualSign == "o" ? Properties.Resources.o50 : Properties.Resources.x50;
                this.player1.switchTurn();
                this.player2.switchTurn();
                this.updateState();
                

            }
        }
        private void updateState()
        {
            this.game.actualSign = this.player1.active == true ? this.player1.Sign : this.player2.Sign;
            this.label2.Text = this.player1.Turn() != "" ? this.player1.Turn() : this.player2.Turn();
        }
    }
}
