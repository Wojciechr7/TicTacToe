using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TicTacToe.classes;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Board board;
        private Game game;
        private bool started;

        private Computer compMode;

        private string actualName;
        private int boardSize;

        // gameMode: 0 - human vs human  // 1 - human vs computer
        private int gameMode;
        private int CurrentWindowSize;

        public List<PictureBox> picList = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
            this.started = false;
            this.gameMode = 0;

            this.boardSize = 3;
            this.CreatePicList(this.boardSize);
            this.CurrentWindowSize = 500;
        }

        // start game button event
        private void StartGame(object sender, EventArgs e)
        {
            if (ValidateNames())
            {
                // game start field
                this.board = new Board(this.boardSize);
                this.game = new Game(this.boardSize, this.compMode);

                this.game.StartGame(this.picList, this.board, this.textBox1, this.textBox2);
                this.started = true;

                this.actualName = this.game.Players[0].Name;


                // it updates game sign and label in a bottom
                this.board.UpdateState(this, this.actualName, this.game.Players[0].Sign);

            }
        }

        // event for clicking a tile
        private void TileClickEvent(object sender, EventArgs e)
        {
            if (this.started && ValidateNames())
            {
                int[] actualIndex = (int[])(sender as PictureBox).Tag;


                if (this.board.IsTileSigned(actualIndex))
                {
                    this.game.Players[0].Name = this.textBox1.Text;


                    this.game.Players[this.board.ActualPlayer].DrawImage(this.picList, this.board.TileList, actualIndex);
                    this.game.UpdateList(actualIndex, this.board.TileList, this.board.ActualSign);

                    if (this.game.CheckWinner(actualIndex, this.board.TileList, this.board.ActualSign))
                    {
                        this.FinishGame(this.game.Players[this.board.ActualPlayer].Name);
                    }
                    else if (this.board.IsBoardFull()) FinishGame("Nobody");
                    else if (this.gameMode == 1)
                    {
                        this.ComputerTurn(actualIndex);
                    }
                    else
                    {
                        this.game.Players[1].Name = this.textBox2.Text;
                        if (this.gameMode == 0) this.board.ActualPlayer = this.board.ActualPlayer == 0 ? 1 : 0;
                        this.actualName = this.game.Players[this.board.ActualPlayer].Name;
                        this.board.UpdateState(this, this.actualName, this.game.Players[this.board.ActualPlayer].Sign);
                    }
                }
            }
        }

        private void ComputerTurn(int[] actualIndex)
        {
            this.game.Players[2].Name = this.textBox2.Text;

            int randomNumber = this.game.Players[2].DrawImage(this.picList, this.board.TileList, actualIndex);


            actualIndex = (int[])this.picList[randomNumber].Tag;

            this.board.UpdateState(this, this.game.Players[2].Name, this.game.Players[2].Sign);
            this.game.UpdateList(actualIndex, this.board.TileList, this.board.ActualSign);

            if (this.game.CheckWinner(actualIndex, this.board.TileList, this.board.ActualSign))
            {
                this.FinishGame(this.game.Players[2].Name);
            }
            else if (this.board.IsBoardFull()) FinishGame("Nobody");

            this.board.UpdateState(this, this.game.Players[this.board.ActualPlayer].Name, this.game.Players[this.board.ActualPlayer].Sign);

        }
        private bool ValidateNames()
        {
            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("Incorrect players name!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else return true;
        }
        private void FinishGame(string name)
        {
            MessageBox.Show(name + " won game!", "Game result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            startButton.PerformClick();
        }


        private void SwitchMode(object sender, EventArgs e)
        {
            if ((string)(sender as ToolStripMenuItem).Tag == "easy")
            {
                this.compMode = new Easy("x", "Computer");
                startButton.PerformClick();
                this.textBox2.Text = "Computer(easy)";
                this.game.CreatePlayersList(this.textBox1, this.textBox2);
                this.gameMode = 1;
                this.toolStripMenuItem1.CheckState = CheckState.Checked;
                this.hardModeToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.humanVsHumanToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else if ((string)(sender as ToolStripMenuItem).Tag == "hard")
            {
                this.compMode = new Hard("x", "Computer");
                startButton.PerformClick();
                this.textBox2.Text = "Computer(hard)";
                this.game.CreatePlayersList(this.textBox1, this.textBox2);
                this.gameMode = 1;
                this.toolStripMenuItem1.CheckState = CheckState.Unchecked;
                this.hardModeToolStripMenuItem.CheckState = CheckState.Checked;
                this.humanVsHumanToolStripMenuItem.CheckState = CheckState.Unchecked;

            }
            else
            {
                startButton.PerformClick();
                this.textBox2.Text = "Player 2";
                this.game.CreatePlayersList(this.textBox1, this.textBox2);
                this.gameMode = 0;
                this.toolStripMenuItem1.CheckState = CheckState.Unchecked;
                this.hardModeToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.humanVsHumanToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }


        private void CreatePicList(int bs)
        {
            if (this.picList.Count > 1)
                foreach (var item in this.picList)
                    item.Dispose();

            this.picList.Clear();
            for (int i = 0; i < Math.Pow(bs, 2); i++)
            {
                this.picList.Add(new PictureBox());
                ((ISupportInitialize)(this.picList[i])).BeginInit();
                int space = 106;
                this.picList[i].Cursor = Cursors.Cross;
                //this.picList[i].Name = "pictureBox" + (i+1);
                this.picList[i].Size = new Size(100, 100);
                this.picList[i].TabIndex = 8;
                this.picList[i].TabStop = false;
                this.picList[i].Click += new EventHandler(this.TileClickEvent);
                if (i == 0) this.picList[i].Location = new Point(84, 97);
                else if (i % bs == 0 && i < Math.Pow(bs, 2))
                {
                    this.picList[i].Location = new Point(this.picList[0].Location.X, this.picList[i - 1].Location.Y + space);
                }
                else
                {
                    this.picList[i].Location = new Point(this.picList[i - 1].Location.X + space, this.picList[i - 1].Location.Y);
                }
                this.Controls.Add(this.picList[i]);

                ((ISupportInitialize)(this.picList[i])).EndInit();
            }
        }

        private void SwitchGameSize(object sender, EventArgs e)
        {

            this.boardSize = (int)Char.GetNumericValue((sender as ToolStripMenuItem).Name[1]);

            this.x5ToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.x4ToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.x3ToolStripMenuItem.CheckState = CheckState.Unchecked;

            (sender as ToolStripMenuItem).CheckState = CheckState.Checked;

            int windowSize = Convert.ToInt32((sender as ToolStripMenuItem).Tag);

            int difference = Math.Abs(windowSize - this.CurrentWindowSize) / 2;

            for (int i = 0; i < difference; i++)
            {
                if (this.CurrentWindowSize < windowSize)
                    this.CurrentWindowSize += 2;
                else this.CurrentWindowSize -= 2;

                this.MinimumSize = new Size(this.CurrentWindowSize, this.CurrentWindowSize);
                this.MaximumSize = new Size(this.CurrentWindowSize, this.CurrentWindowSize);
                Thread.Sleep(3);
            }

            this.CreatePicList(this.boardSize);
            startButton.PerformClick();

        }
    }
}
