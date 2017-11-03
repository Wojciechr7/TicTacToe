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


            this.label2.Text = this.player1.Turn() != "" ? this.player1.Turn() : this.player2.Turn();

        }

        private void TileClickEvent(object sender, EventArgs e)
        {
            if (this.game.gameStarted)
            {
                // Console.WriteLine((sender as PictureBox).Name);
                (sender as PictureBox).Image = Properties.Resources.x50;


            }

        }
    }
}
