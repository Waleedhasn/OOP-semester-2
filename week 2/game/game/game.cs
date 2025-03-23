using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;

namespace game
{
    class game
    {
        static void Main()
        {
            body c = new body();
            enemy e = new enemy();
            player p = new player();
            Console.Clear();
            c.PrintMaze();
            e.PrintEnemy(e.e1X, e.e1Y);

            Console.SetCursorPosition(p.pX, p.pY);
            p.PrintTank();
            Console.SetCursorPosition(90,90);

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    p.MovePlayerLeft();
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    p.MovePlayerRight();
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    p.MovePlayerUp();
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    p.MovePlayerDown();
                }
            

            e.MoveEnemyHorizontally();

                Thread.Sleep(200);
            }
        }
    }
}