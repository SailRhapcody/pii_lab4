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
            int counter = 0;
            while (true)
            {
                if(counter == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("White Player : " + player1.getName());
                    counter = 1;
                }
                else if(counter == 1) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Black Player : " + player2.getName());
                    counter = 0;
                }
                board.setCells(makeTurn.moveChecker());
                render.show(board.getCells());
            }
        }

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
