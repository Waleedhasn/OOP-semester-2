
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
namespace game
{
    public class player
    {
        public player() { }
        public int pX = 7, pY = 5;
        public void PrintTank()
        {
           Console.SetCursorPosition(pY,pX);
            Console.WriteLine("     <||||||||||||>=========o");
            Console.SetCursorPosition(pY + 1, pX);
            Console.WriteLine("  [||||||||||||||||||||||]");
            Console.SetCursorPosition(pY + 2, pX);
            Console.WriteLine("  \\||||||||||||||||||||||/");
            Console.SetCursorPosition(pY + 3, pX);
            Console.WriteLine("    \\(OOOOOOOOOOOOOOOOO)/");
        }

        public void EraseTank()
        {
            Console.SetCursorPosition(pY,pX);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(pY + 1, pX);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(pY + 2, pX);
            Console.WriteLine("                            ");
            Console.SetCursorPosition(pY + 3, pX);
            Console.WriteLine("                           ");
        }
        public void MovePlayerLeft()
        {
            if (pX > 1)
            {
                EraseTank();
                pX -= 1;
                PrintTank();
            }
        }

        public void MovePlayerRight()
        {
            if (pX < 100)
            {
                EraseTank();
                pX += 1;
                PrintTank();
            }
        }

        public void MovePlayerUp()
        {
            if (pY > 1)
            {
                EraseTank();
                pY -= 1;
                PrintTank();
            }
        }

        public void MovePlayerDown()
        {
            if (pY < 22)
            {
                EraseTank();
                pY += 1;
                PrintTank();
            }
        }
    }
}
