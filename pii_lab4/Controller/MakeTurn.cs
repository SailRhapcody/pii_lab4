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
            List<String> list = new List<string>();
            while (!correctInputValidator(pos, pos2))
            {
                Console.WriteLine("Incorrect Input.Try again...");
                list = turnGetter();
                pos = list[0];
                pos2 = list[1];
            }
            getCoord(ref values, pos, pos2);
            return values;

        }

        private List<String> turnGetter()
        {
            List<String> list = new List<string>();
            String[,] val = new String[1, 1];
            Console.Write("posToMove : ");
            list.Add(Console.ReadLine());
            Console.Write("posTarget : ");
            list.Add(Console.ReadLine());
            Console.WriteLine(list);
            return list;
        }
        private void getCoord(ref int[,] values, String s, String s2)
        {
            values[0, 0] = getNumFromChar(s[0]);
            values[0, 1] = s[1] - '0' - 1;
            values[1, 0] = getNumFromChar(s2[0]);
            values[1, 1] = s2[1] - '0' - 1;
        }

        private bool correctInputValidator(String s, String s2)
        {
            if(s.Length != 2 || s2.Length!= 2) { return false; }
            if((int)s[0] >= 97 && (int)s[0] <= 104 && (int)s[1] >=48 && (int)s[1] <= 55
                && (int)s2[0] >= 97 && (int)s2[0] <= 104 && (int)s2[1] >=48 && (int)s2[1] <= 55)
            {
                int checkDiff1 = Math.Abs((int)s[0] - (int)s2[0]);
                int checkDiff2 = Math.Abs((int)s[1] - (int)s2[1]);
                if(checkDiff1 == 1 && checkDiff2 == 1) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
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
