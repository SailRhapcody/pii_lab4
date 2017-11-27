using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Controller
{
    class Validator
    {
        private Model.Cell[,] cells;
        private int[,] values;
        private bool isWhite;
        private int r1, c1, r2, c2;
        private bool smtInLeft = false;
        private bool smtInRight = false;
        public bool check(Model.Cell[,] cel, int[,] val, bool isWhite)
        {
            this.isWhite = isWhite;
            cells = cel;
            values = val;
            Console.WriteLine("Validator.class");
            r1 = values[0, 1];
            c1 = values[0, 0];
            r2 = values[1, 1];
            c2 = values[1, 0];
            //Первая проверка.Цвет игрока = цвету шашки которую он хочет передвинуть
            if ((isWhite && String.Compare(cells[r1, c1].getStatus(), "white") == 0) ||
                (!isWhite && String.Compare(cells[r1, c1].getStatus(), "black") == 0)) {
                if (takePosForAnyChecker())
                {
                    return true;
                    //Вставить валидность мува
                }
                else
                {
                    return false;
                }
            }
            else {
                return false;
            }
            Console.WriteLine("SOmething wrong in here");
        }

        private bool validMove()
        {
            if (isWhite)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        //Проверка всех клеток для текущего игрока на необходимость взятия.Вызов в цикле метода findCheckerNeighbours
        private bool takePosForAnyChecker()
        {
            for (int currentRow = 0; currentRow < 8; currentRow++)
            {
                for (int currentCol = 0; currentCol < 8; currentCol++)
                {
                    if (findCheckerNeighbours(currentRow, currentCol)) {
                    }
                    else
                    {
                        //Совпадает ил введенные координаты с координатами на которыъ нужно взять взятие
                        if(r1 == currentRow && c1 == currentCol) { return true; }
                        else { return false; }
                    }
                }
            }
            return true;
        }

        //Проверка отдельной клетки на наличие возможных взятий
        private bool findCheckerNeighbours(int currentRow, int currentCol)
        {
            smtInRight = false;
            smtInLeft = false;
            if (isWhite)
            {
                //поиск шашек со статусом соотв.цвету игрока в массиве и проверка диагоналей на наличие шашек противника.
                if (cells[currentRow, currentCol].getStatus() == "white")
                {
                    if (currentRow != 7)
                    {
                        if (currentCol == 0)
                        {
                            if (cells[currentRow + 1, currentCol + 1].getStatus() == "black")
                            {
                                smtInRight = true;
                                return false;
                            }
                        }
                        else if (currentCol == 7)
                        {
                            if (cells[currentRow + 1, currentCol - 1].getStatus() == "black")
                            {
                                smtInLeft = true;
                                return false;
                            }
                        }
                        else
                        {
                            if (cells[currentRow + 1, currentCol - 1].getStatus() == "black" || cells[currentRow + 1, currentCol + 1].getStatus() == "black")
                            {
                                smtInLeft = true;
                                smtInRight = true;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Final Line achieved");
                        return false;
                    }
                }
            }
            //Есть ли черные шашки которые могут взять белую шашку
            else
            {
                if (cells[currentRow, currentCol].getStatus() == "black")
                {
                    if (currentRow != 0)
                    {
                        if (currentCol == 0)
                        {
                            if (cells[currentRow - 1, currentCol + 1].getStatus() == "white")
                            {
                                smtInRight = true;
                                return false;
                            }
                        }
                        else if (currentCol == 7)
                        {
                            if (cells[currentRow - 1, currentCol - 1].getStatus() == "white")
                            {
                                smtInLeft = true;
                                return false;
                            }
                        }
                        else
                        {
                            if (cells[currentRow - 1, currentCol - 1].getStatus() == "white" || cells[currentRow - 1, currentCol + 1].getStatus() == "white")
                            {
                                smtInLeft = true;
                                smtInRight = true;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Final Line achieved");
                        return false;
                    }
                }
            }
            return true;
        }


    }

}

