using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Model
{
    class Board
    {
        private enum cols { a, b, c, d, e, f, g, h};
        private Cell[,] cells;
        public Board()
        {
            cells = new Cell[8, (int)cols.h + 1];
            bool startWithBlack;
            for(int row = 0;row < 8; row++)
            {
                if (row == 0 || row % 2 == 0) startWithBlack = true;
                else startWithBlack = false;
                for(int col = 0;col < (int)cols.h + 1; col++)
                {
                    if (startWithBlack)
                    {
                        if(col == 0 || col%2 == 0)
                        {
                            if(row <= 2)
                            {
                                cells[row, col] = new Cell("white");
                            }
                            else if (row >= 5)
                            {
                                cells[row, col] = new Cell("black");
                            }
                            else
                            {
                                cells[row, col] = new Cell("empty");
                            }
                        }
                        else
                        {
                            cells[row, col] = new Cell("forbd");
                        }
                    }
                    else
                    {
                        if(col == 1 || col % 2 != 0)
                        {
                            if(row <= 2)
                            {
                                cells[row, col] = new Cell("white");
                            }
                            else if (row >= 5)
                            {
                                cells[row, col] = new Cell("black");
                            }
                            else
                            {
                                cells[row, col] = new Cell("empty");
                            }

                        }
                        else
                        {
                            cells[row, col] = new Cell("forbd");
                        }
                    }
                }
            }
        }

        public Cell[,] getCells()
        {
            return this.cells;
        }

        public void setCells(int [,] values)
        {
            String status1 = cells[values[0, 1], values[0, 0]].getStatus();
            String status2 = cells[values[1, 1], values[1, 0]].getStatus();
            Console.WriteLine(status1 + " " + status2);
            foreach(var t in values)
            {
                Console.Write(t + " ");
            }
            cells[values[0, 1], values[0, 0]].setStatus(status2);
            cells[values[1, 1], values[1, 0]].setStatus(status1);
        }
        
    }
}
