using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        Computer SI;

        public Form1()
        {
            InitializeComponent();
            this.createList();
            this.label2.Text = "";
            this.SI = new Computer("x", false, this.textBox2.Text, false);


        }

        // start game button event
        private void button1_Click(object sender, EventArgs e)
        {
          
            // game start field
            this.game = new Board();
            this.game.createList(this.picList);
            this.game.gameStarted = true;

            // create Player instances
            this.player1 = this.textBox1.Text == "" ? new Player("o", true) : new Player("o", true, this.textBox1.Text);
            this.player2 = this.textBox2.Text == "" ? new Player("x", false) : new Player("x", false, this.textBox2.Text);


            // set white background for all tiles
            foreach (var c in this.picList)
                c.Image = Properties.Resources.blank50;

            this.updateState();

            this.checkBox1.Visible = true;

        }

        // event for clicking a tile
        private void TileClickEvent(object sender, EventArgs e)
        {
            int actualNr = (int)Char.GetNumericValue((sender as PictureBox).Name[10]) - 1;
            int randomNumber;
            if (this.game.gameStarted && this.game.tileList[actualNr].Signed == false)
            {
                // update list
                this.game.tileList[actualNr].Signed = true;
                this.game.tileList[actualNr].Sign = this.game.actualSign;


                // draw new image on a tile
                (sender as PictureBox).Image = this.game.actualSign == "o" ? Properties.Resources.o50 : Properties.Resources.x50;

                // check if somebody win
                if (this.game.checkWinner())
                {
                    MessageBox.Show(this.label2.Text + " won game!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    button1.PerformClick();
                }
                else
                {
                    // switches
                    this.player1.switchTurn();
                    this.player2.switchTurn();
                    this.updateState();
                }
               
                if (this.label2.Text == "Computer")
                {
                    randomNumber = this.SI.chooseRandom(this.game.tileList, actualNr);
                    if (randomNumber != -1) this.TileClickEvent(this.picList[randomNumber], null);                     
                }
            }           
        }

        // update actual player
        private void updateState()
        {
            this.game.actualSign = this.player1.active == true ? this.player1.Sign : this.player2.Sign;
            this.label2.Text = this.player1.Turn() != "" ? this.player1.Turn() : this.player2.Turn();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.SI.activated == false)
            {
                this.textBox2.Text = "Computer";
                this.SI.activated = true;
                button1.PerformClick();

            }
            else
            {
                this.textBox2.Text = "Player 2";
                this.SI.activated = false;
                button1.PerformClick();

            }
        }
    }
}
