using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.View
{
    class Render
    {
        private enum cols { a, b, c, d, e, f, g, h };
        public void show(Model.Cell [,] cells)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int row = 7; row >= 0; row--)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n--+-----------------------------------------------------------------");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(row + 1 + " |");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                for (int col = 0; col < 8; col++)
                {
                    switch (cells[row, col].getStatus())
                    {
                        case "black":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "white":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "empty":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case "forbd":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                    }
                    if (col == 0) Console.Write(" ");
                    Console.Write(cells[row, col]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" | ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            String space = "       ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("      ");
            for (int i = 0; i < 8; i++)
            {
                if (i == 7)
                {
                    Console.Write("h" + "     ");
                    break;
                }
                Console.Write(Enum.GetName(typeof(cols), i) + space);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        public void writeCurrentUserLine(Model.Player player)
        {
            if(String.Compare(player.getColor(), "whitePlayer") == 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("White Player : " + player.getName());
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Black Player : " + player.getName());
            }

        }
    }
}
