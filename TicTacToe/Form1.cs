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
        private Computer easyMode;
        private bool started;
        private List<Player> players;
        private string actualName;
        // gameMode 0 - human vs human  // 1 - human vs computer
        private int gameMode;



        public Form1()
        {
            InitializeComponent();
            this.label2.Text = "";
            this.started = false;
            this.gameMode = 0;
            this.createList();

            this.players = new List<Player>();

            this.player1 = this.textBox1.Text == "" ? new Human("o", true) : new Human("o", true, this.textBox1.Text);
            this.player2 = this.textBox2.Text == "" ? new Human("x", false) : new Human("x", false, this.textBox2.Text);
            this.easyMode = new Computer("x", false, "Computer", false);

            this.createPlayersList();

        }

        // start game button event
        private void startGame(object sender, EventArgs e)
        {
            if (validateNames())
            {
                // game start field
                this.game = new Board(9);
                this.game.startGame(this.picList);
                this.started = true;

                this.game.ActualPlayer = 0;
                this.actualName = this.players[0].Name;

                // TODO
                this.game.resetPlayers(this.players, this.textBox1.Text, this.textBox2.Text);

                Console.WriteLine(this.game.ActualPlayer);
                Console.WriteLine(this.actualName);
                // it updates game sign and label in a bottom
                this.game.updateState(this.label2, this.actualName, this.players[0].Sign);


                this.checkBox1.Visible = true;
            }

        }

        // event for clicking a tile
        private void tileClickEvent(object sender, EventArgs e)
        {
            if (this.started && validateNames())
            {
                int actualNr = (int)Char.GetNumericValue((sender as PictureBox).Name[10]) - 1;


                if (this.game.isTileSigned(actualNr))
                {
                    this.players[0].Name = this.textBox1.Text;
                    this.players[1].Name = this.textBox2.Text;


                    this.players[this.game.ActualPlayer].drawImage(this.picList, this.game.TileList, actualNr);
                    this.game.updateList(actualNr);

                    if (this.game.checkWinner())
                    {
                        this.finishGame(this.players[this.game.ActualPlayer].Name);
                    }
                    else if (this.gameMode == 1)
                    {
                        this.computerTurn(actualNr);
                    }

                    if (this.gameMode == 0) this.game.ActualPlayer = this.game.ActualPlayer == 0 ? 1 : 0;
                    this.actualName = this.players[this.game.ActualPlayer].Name;
                    this.game.updateState(this.label2, this.actualName, this.players[this.game.ActualPlayer].Sign);


                    

                  
                }
            }
        }

        private void computerTurn(int actualNr)
        {
            this.players[2].Name = this.textBox2.Text;

            this.actualName = this.players[0].Name;

            actualNr = this.players[2].drawImage(this.picList, this.game.TileList, actualNr);

            if (actualNr == -1) finishGame("Nobody");
            else
            {

                this.game.updateState(this.label2, this.actualName, this.players[2].Sign);
                this.game.updateList(actualNr);


                this.game.ActualPlayer = 0;


                if (this.game.checkWinner())
                {
                    this.finishGame(this.players[2].Name);
                }
            }
        }
        private bool validateNames()
        {
            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("Incorrect players name!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else return true;
        }
        private void finishGame(string name)
        {
            MessageBox.Show(name + " won game!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            startButton.PerformClick();
        }
        private void createPlayersList()
        {
            this.players.Clear();
            this.players.Add(this.player1);
            this.players.Add(this.player2);
            this.players.Add(this.easyMode);
        }

        private void switchMode(object sender, EventArgs e)
        {
            if (this.gameMode == 0)
            {
                this.easyMode = new Computer("x", false, "Computer", false);
                this.createPlayersList();

                this.gameMode = 1;
                this.textBox2.Text = this.players[2].Name;

                startButton.PerformClick();
            }
            else
            {
                this.player2 = this.textBox2.Text == "" ? new Human("x", false) : new Human("x", false, "Player 2");
                this.createPlayersList();

                this.gameMode = 0;
                this.textBox2.Text = this.players[1].Name;

                startButton.PerformClick();
            }
        }
    }
}
