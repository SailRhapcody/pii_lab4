using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pii_lab4.Controller
{
    class Validator
    {
        private Model.Cell[,] cells;
        private int[,] values;
        private bool isWhite;
        private int r1, c1, r2, c2;
        private bool smtInLeftWhite = false;
        private bool smtInRightWhite = false;
        private bool smtInLeftBlack = false;
        private bool smtInRightBlack = false;
        public bool check(Model.Cell[,] cel, ref int[,] val, bool isWhite)
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
                    return validMove();
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
            Console.WriteLine(smtInRightWhite + " " + smtInLeftWhite + "; " + smtInRightBlack + " " + smtInLeftBlack);
            if (isWhite)
            {
                Console.WriteLine("white");
                Console.WriteLine(smtInLeftWhite + " " + smtInRightWhite);
                Thread.Sleep(3000);
                //Нет ни слева ни справа
                if (!(smtInLeftWhite || smtInRightWhite))
                {
                    if (cells[r2, c2].getStatus() == "empty")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                //Если есть что то слева 
                else if (smtInLeftWhite && !smtInRightWhite)
                {
                    if (c2 < c1)
                    {
                        if (c2 - 1 >= 0 && r2 + 1 <= 7)
                        {
                            values[1, 1] = r2 + 1;
                            values[1, 0] = c2 - 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //Если есть что то справа
                else if (smtInRightWhite && !smtInLeftWhite)
                {
                    Console.WriteLine("we are here");
                    if (c2 > c1)
                    {
                        if (c2 + 1 <= 7 && r2 + 1 <= 7)
                        {
                            values[1, 1] = r2 + 1;
                            values[1, 0] = c2 + 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //Значит что то есть и справа и слева
                else
                {
                    if (c2 < c1)
                    {
                        if (c2 - 1 >= 0 && r2 + 1 <= 7)
                        {
                            values[1, 1] = r2 + 1;
                            values[1, 0] = c2 - 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (c2 > c1)
                    {
                        if (c2 + 1 <= 7 && r2 + 1 <= 7)
                        {
                            values[1, 1] = r2 + 1;
                            values[1, 0] = c2 + 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("black");
                Console.WriteLine(smtInLeftBlack + " " + smtInRightBlack);
                Thread.Sleep(3000);
                //Нет ни слева ни справа
                if (!(smtInLeftBlack || smtInRightBlack))
                {
                    if (cells[r2, c2].getStatus() == "empty")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                //Если есть что то слева 
                else if (smtInLeftBlack && !smtInRightBlack)
                {
                    if (c2 < c1)
                    {
                        if (c2 - 1 >= 0 && r2 - 1 >= 0)
                        {
                            values[1, 1] = r2 - 1;
                            values[1, 0] = c2 - 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //Если есть что то справа
                else if (smtInRightBlack && !smtInLeftBlack)
                {
                    Console.WriteLine("we are here");
                    if (c2 > c1)
                    {
                        if (c2 + 1 <= 7 && r2 - 1 >= 0)
                        {
                            values[1, 1] = r2 - 1;
                            values[1, 0] = c2 + 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //Значит что то есть и справа и слева
                else
                {
                    if (c2 < c1)
                    {
                        if (c2 - 1 >= 0 && r2 - 1 >= 0)
                        {
                            values[1, 1] = r2 + 1;
                            values[1, 0] = c2 - 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (c2 > c1)
                    {
                        if (c2 + 1 >= 7 && r2 - 1 >= 0)
                        {
                            values[1, 1] = r2 - 1;
                            values[1, 0] = c2 + 1;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
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
                        if (r1 == currentRow && c1 == currentCol) { return true; }
                        else { return false; }
                    }
                }
            }
            return true;
        }

        //Проверка отдельной клетки на наличие возможных взятий
        private bool findCheckerNeighbours(int currentRow, int currentCol)
        {
            smtInLeftBlack = false;
            smtInRightBlack = false;
            smtInLeftWhite = false;
            smtInRightWhite = false;
            try
            {
                if (isWhite)
                {
                    //поиск шашек со статусом соотв.цвету игрока в массиве и проверка диагоналей на наличие шашек противника.
                    if (cells[currentRow, currentCol].getStatus() == "white")
                    {
                        if (currentRow != 7)
                        {
                            if (currentCol == 0)
                            {
                                //Белые - право
                                if (cells[currentRow + 1, currentCol + 1].getStatus() == "black")
                                {
                                    if (currentRow + 2 <= 7)
                                    {
                                        if (cells[currentRow + 2, currentCol + 2].getStatus() == "empty")
                                        {
                                            smtInRightWhite = true;
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else { return true; }
                                }
                            }
                            else if (currentCol == 7)
                            {
                                if (cells[currentRow + 1, currentCol - 1].getStatus() == "black")
                                {
                                    if (currentRow + 2 <= 7)
                                    {
                                        if (cells[currentRow + 2, currentCol - 2].getStatus() == "empty")
                                        {
                                            smtInLeftWhite = true;
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (cells[currentRow + 1, currentCol - 1].getStatus() == "black" || cells[currentRow + 1, currentCol + 1].getStatus() == "black")
                                {
                                    if (currentRow + 2 <= 7 && currentCol - 2 >= 0)
                                    {
                                        if (cells[currentRow + 2, currentCol - 2].getStatus() == "empty")
                                        {
                                            smtInLeftWhite = true;
                                        }
                                    }
                                    if (currentRow + 2 <= 7 && currentCol + 2 <= 7)
                                    {
                                        if (cells[currentRow + 2, currentCol + 2].getStatus() == "empty")
                                        {
                                            smtInRightWhite = true;
                                        }
                                    }
                                    if (smtInRightWhite || smtInLeftWhite)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Final Line achieved");
                            return true;
                        }
                    }
                    else
                    {
                        return true;
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
                                //Черные - право
                                if (cells[currentRow - 1, currentCol + 1].getStatus() == "white")
                                {
                                    if (currentRow - 2 >= 0)
                                    {
                                        if (cells[currentRow - 2, currentCol + 2].getStatus() == "empty")
                                        {
                                            smtInRightBlack = true;
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else { return true; }
                                }
                            }
                            else if (currentCol == 7)
                            {
                                if (cells[currentRow - 1, currentCol - 1].getStatus() == "white")
                                {
                                    if (currentRow - 2 >= 0)
                                    {
                                        if (cells[currentRow - 2, currentCol - 2].getStatus() == "empty")
                                        {
                                            smtInLeftBlack = true;
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (cells[currentRow - 1, currentCol - 1].getStatus() == "white" || cells[currentRow - 1, currentCol + 1].getStatus() == "white")
                                {
                                    if (currentRow - 2 >= 0 && currentCol - 2 >= 0)
                                    {
                                        if (cells[currentRow - 2, currentCol - 2].getStatus() == "empty")
                                        {
                                            smtInLeftBlack = true;
                                        }
                                    }
                                    if (currentRow - 2 >= 0 && currentCol + 2 <= 7)
                                    {
                                        if (cells[currentRow - 2, currentCol + 2].getStatus() == "empty")
                                        {
                                            smtInRightWhite = true;
                                        }
                                    }
                                    if (smtInRightWhite || smtInLeftWhite)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Final Line achieved");
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

    }

}

