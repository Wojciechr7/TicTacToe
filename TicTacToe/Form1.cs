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
        private Human player1;
        private Human player2;
        private Board game;
        private Computer SI;
        private bool started;

        public Form1()
        {
            InitializeComponent();
            this.createList();
            this.label2.Text = "";
            this.started = false;
            this.SI = new Computer("x", false, this.textBox2.Text, false);

        }

        // start game button event
        private void button1_Click(object sender, EventArgs e)
        {          
            // game start field
            this.game = new Board(9);
            this.game.startGame(this.picList);
            this.started = true;

            // create Player instances
            this.player1 = this.textBox1.Text == "" ? new Human("o", true) : new Human("o", true, this.textBox1.Text);
            this.player2 = this.textBox2.Text == "" ? new Human("x", false) : new Human("x", false, this.textBox2.Text);


            this.game.updateState(this.player1, this.player2, this.label2);


            this.checkBox1.Visible = true;

        }

        // event for clicking a tile
        private void TileClickEvent(object sender, EventArgs e)
        {
            if (this.started)
            {
                int actualNr = (int)Char.GetNumericValue((sender as PictureBox).Name[10]) - 1;
                int randomNumber;

                if (this.game.isTileSigned(actualNr))
                {
                    // update list
                    this.game.updateList(actualNr);

                    // draw new image on a tile
                    this.game.drawImage(sender as PictureBox);

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
                        this.game.updateState(this.player1, this.player2, this.label2);
                    }

                    if (this.label2.Text == "Computer")
                    {
                        randomNumber = this.SI.chooseRandom(this.game.tileList, actualNr);
                        if (randomNumber != -1) this.TileClickEvent(this.picList[randomNumber], null);
                    }
                }
            }
            

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
