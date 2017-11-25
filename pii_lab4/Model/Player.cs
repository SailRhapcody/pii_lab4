using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Model
{
    class Player
    {
        private String name;
        private String color;
        static int num_player = 0;
        
        public void setName(String p_name)
        {
            if (numValidator())
            {
                if (p_name.Length > 20)
                {
                    File.AppendAllText("log.txt", "Ilegal user name /n");
                }
                else
                {
                    name = p_name;
                    num_player++;
                }
            }
            else
            {
                    File.AppendAllText("log.txt", "Too much users! /n");
            }
        }

        public String getName()
        {
            return this.name;
        }

        public String getColor()
        {
            return this.color;
        }

        private bool numValidator()
        {
            if(num_player == 0)
            {
                this.color = "whitePlayer";
                return true;
            }
            else if(num_player == 1)
            {
                this.color = "blackPlayer";
                return true;
            }
            else
            {
                File.AppendAllText("log.txt", "Too much users! /n");
                return false;
            }
        }
    }
}
