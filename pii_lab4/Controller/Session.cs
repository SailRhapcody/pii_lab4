using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pii_lab4.Controller
{
    static class Session
    {
        static private Model.Board board;
        static private Controller.MakeTurn makeTurn;
        static private Controller.Validator validator;
        static private View.Render render;
        static private Model.Player player1;
        static private Model.Player player2;
        static public void start()
        {
            while((!playerInitializer())); 
            board = new Model.Board();
            render = new View.Render();
            makeTurn = new Controller.MakeTurn();
            render.show(board.getCells());
            bool isWhite = false;
            int[,] values = new int[2,2];
            bool falseMove = false;
            validator = new Controller.Validator();
            while (true)
            {
                isWhite = !isWhite;
                falseMove = !falseMove;
                //Отрисовка имени игрока под доской
                if(isWhite)
                {
                    render.writeCurrentUserLine(player1);
                }
                else {
                    render.writeCurrentUserLine(player2);
                }

                //Пока не будет введен корректный ход
                while (falseMove) {
                    //Проверка символьной правильности введенного хода
                    values = makeTurn.moveChecker();
                    //
                    if(validator.check(board.getCells(), values, isWhite)) falseMove = false;
                }
                board.setCells(values);
                render.show(board.getCells());
            }
        }

        //Ввод имен игроков.Начало программы.
        static private bool playerInitializer()
        {
            player1 = new Model.Player();
            player2 = new Model.Player();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hi!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("player1 name = ");
            player1.setName(Console.ReadLine());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("player2 name = ");
            player2.setName(Console.ReadLine());
            if(String.Compare(player1.getColor(), "whitePlayer") == 0 && player1.getName() != null && String.Compare(player2.getColor(), 
                "blackPlayer") == 0 && player2.getColor() != null)
            {
                return true;
            }
            else{
                return false;
            }
        }
        
    }
}
