using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Model
{
    class Cell
    {
        private String status;
        public Cell(String status)
        {
            if(status == "black" || status == "white" || status == "forbd" || status == "empty")
            {
                this.status = status;
            }
            else
            {
                File.AppendAllText("log.txt", "Ilegal checker color initiation /n");
            }
        }

        public void setStatus(String status)
        {
            if(status == "black" || status == "white" || status == "empty")
            {
                this.status = status;
            }
        }

        public String getStatus()
        {
            return this.status;
        }

        public override string ToString()
        {
            return status;
        }
    }
}
