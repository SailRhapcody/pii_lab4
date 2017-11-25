using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Controller
{
    class MakeTurn
    {
        public int[,] moveChecker()
        {
            Console.Write("posToMove : ");
            String pos = Console.ReadLine();
            Console.Write("posTarget : ");
            String pos2 = Console.ReadLine();
            int[,] values = new int[2, 2];
            getCoord(ref values, pos, pos2);
            return values;

        }
        private void getCoord(ref int[,] values, String s, String s2)
        {
            values[0, 0] = getNumFromChar(s[0]);
            values[0, 1] = s[1] - '0' - 1;
            values[1, 0] = getNumFromChar(s2[0]);
            values[1, 1] = s2[1] - '0' - 1;
        }

        private int getNumFromChar(char c)
        {
            switch (c)
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                default:
                    return 0;
            }
        }
    }
}
