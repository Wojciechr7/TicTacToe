using System.Collections.Generic;

namespace TicTacToe.classes
{
    class Hard : Computer, IComputerMode
    {

        public Hard(string s = "o", bool a = true, string n = "NO PLAYER NAME", bool act = false) : base(s, a, n)
        {

        }

        public override int ChooseTile(List<List<Tile>> tileList)
        {
            int winningTile = base.CanWin(tileList);

            if (winningTile != -1) return winningTile;

            for (int i = 0; i < tileList.Count; i++)
            {
                int counterHorizontal = 0;
                for (int j = 0; j < tileList.Count; j++)
                {
                    // increase counter when human sign found in one line
                    if (tileList[i][j].Signed && tileList[i][j].Sign == "o")
                        counterHorizontal++;

                    // break when line is marked by computer
                    if (tileList[i][j].Sign == "x") break;

                    // 2 human signs found in one line
                    if (counterHorizontal == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            // find first empty tile
                            if (!tileList[i][k].Signed)
                            {
                                // return number of tile to block horizontal line
                                return tileList[i][k].Nr;
                            }
                        }
                        break;
                    }
                }
            }


            for (int i = 0; i < tileList.Count; i++)
            {
                int counterVertical = 0;
                for (int j = 0; j < tileList.Count; j++)
                {
                    if (tileList[j][i].Signed && tileList[j][i].Sign == "o")
                        counterVertical++;

                    if (tileList[j][i].Sign == "x") break;

                    if (counterVertical == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (!tileList[k][i].Signed)
                            {
                                // block vertical line
                                return tileList[k][i].Nr;
                            }
                        }
                        break;
                    }
                }
            }

            int counterDiag = 0;
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i][i].Signed && tileList[i][i].Sign == "o")
                    counterDiag++;

                if (tileList[i][i].Sign == "x") break;

                if (counterDiag == 2)
                {

                    for (int k = 0; k < 3; k++)
                    {
                        if (!tileList[k][k].Signed)
                        {
                            // block diagonal line
                            return tileList[k][k].Nr;
                        }
                    }
                    break;
                }
            }


            int counterAntiDiag = 0;
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i][(tileList.Count - 1) - i].Signed && tileList[i][(tileList.Count - 1) - i].Sign == "o")
                    counterAntiDiag++;

                if (tileList[i][(tileList.Count - 1) - i].Sign == "x") break;

                if (counterAntiDiag == 2)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (!tileList[k][(tileList.Count - 1) - k].Signed)
                        {
                            // block anti-diagonal line
                            return tileList[k][(tileList.Count - 1) - k].Nr;
                        }
                    }
                    break;
                }
            }


            return base.ChooseTile(tileList);
        }

    }
}
