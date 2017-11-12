﻿using System;
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
        private List<Human> humans;
        private List<Computer> computers;
        private string actualName;


        public Form1()
        {
            InitializeComponent();
            this.createList();
            this.label2.Text = "";
            this.started = false;
            
            this.humans = new List<Human>();
            this.computers = new List<Computer>();


            this.player1 = this.textBox1.Text == "" ? new Human("o", true) : new Human("o", true, this.textBox1.Text);
            this.player2 = this.textBox2.Text == "" ? new Human("x", false) : new Human("x", false, this.textBox2.Text);
            this.easyMode = new Computer("x", false, this.textBox2.Text, false);

            this.humans.Add(this.player1);
            this.humans.Add(this.player2);
            this.computers.Add(this.easyMode);
        }

        // start game button event
        private void button1_Click(object sender, EventArgs e)
        {
            // game start field
            this.game = new Board(9);
            this.game.startGame(this.picList);
            this.started = true;


            this.actualName = this.textBox1.Text;


            this.game.resetPlayers(this.humans, this.computers, this.textBox1.Text, this.textBox2.Text);

            this.game.updateState(this.humans, this.computers, this.label2, this.actualName);


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

                    
       
          

                    // check if somebody win
                    if (this.game.checkWinner())
                    {
                        MessageBox.Show(this.label2.Text + " won game!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button1.PerformClick();
                    }
                    else
                    {
                   
                        // switch fields: turn and name
                        this.humans[0].switchTurn(this.textBox1.Text);
                        this.humans[1].switchTurn(this.textBox2.Text);

                        this.game.ActualPlayer = this.game.ActualPlayer == 0 ? 1 : 0;

                        // set actualName
                        if (this.computers[0].Activated && this.game.ActualPlayer == 1)
                        {
                            Console.WriteLine("2");
                            // computer turn
                            this.actualName = this.computers[0].Name;
                            // draw new image on a tile
                            this.computers[0].drawImage(sender as PictureBox);

                            randomNumber = this.computers[0].chooseRandom(this.game.TileList, actualNr);
                            if (randomNumber != -1) this.TileClickEvent(this.picList[randomNumber], null);

                        }
                        else
                        {
                            Console.WriteLine("1");
                            // human turn
                            this.actualName = this.humans[this.game.ActualPlayer].Name;
                            this.humans[this.game.ActualPlayer].drawImage(sender as PictureBox);
                            
                        }

                 
                         this.game.updateState(this.humans,this.computers, this.label2, this.actualName);
                    }
                 
                }
            }
           // Console.WriteLine(this.game.ActualPlayer);
            

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.computers[0].Activated == false)
            {
               
                
                this.textBox2.Text = this.computers[0].Name;
                this.computers[0].Activated = true;
                button1.PerformClick();
            }
            else
            {
                
                this.textBox2.Text = "Player 2";
                this.computers[0].Activated = false;
                button1.PerformClick();
                


            }
        }
    }
}
