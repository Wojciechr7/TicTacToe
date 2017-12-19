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
    class BoardView : Form1
    {

        public BoardView()
        {
            this.CreatePicList(this.boardSize);

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

        protected void SwitchGameSize(object sender, EventArgs e)
        {
            this.boardSize = (int)Char.GetNumericValue((sender as ToolStripMenuItem).Name[1]);

            Console.WriteLine("sgsdg");
            this.x5ToolStripMenuItem.Click += new EventHandler(this.SwitchGameSize);
            this.x4ToolStripMenuItem.Click += new EventHandler(this.SwitchGameSize);
            this.x3ToolStripMenuItem.Click += new EventHandler(this.SwitchGameSize);
            this.x5ToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.x4ToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.x3ToolStripMenuItem.CheckState = CheckState.Unchecked;

            (sender as ToolStripMenuItem).CheckState = CheckState.Checked;

            int windowSize = Convert.ToInt32((sender as ToolStripMenuItem).Tag);

            this.MinimumSize = new Size(windowSize, windowSize);
            this.MaximumSize = new Size(windowSize, windowSize);

            this.CreatePicList(this.boardSize);
            this.startButton.PerformClick();

        }
    }
}
