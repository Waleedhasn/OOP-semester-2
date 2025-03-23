using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
namespace game
{
    public class enemy
    {
        public enemy() { }
        public int e1X = 90, e1Y = 10;
        public int e1Direc = 1;
        public void PrintEnemy(int y, int x)
        {
            e1X = x;
            e1Y = y;
            Console.SetCursorPosition(y,x);
            Console.WriteLine("         (~~~) (~~~)");
            Console.SetCursorPosition(y + 1,x);
            Console.WriteLine("o=======|=| | | |=|");
            Console.SetCursorPosition(y + 2,x);
            Console.WriteLine("o=======|=| | | |=|");
            Console.SetCursorPosition(y + 3,x);
            Console.WriteLine("         (~~~) (~~~)");
        }

        public void EraseEnemy(int y, int x)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(y + 1,x);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(y + 2,x);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(y + 3,x);
            Console.WriteLine("                    ");
        }

        public void MoveEnemyHorizontally()
        {
            EraseEnemy(e1X, e1Y);
            e1X += e1Direc;
            if (e1X >= 90 || e1X <= 30)
            {
                e1Direc = -e1Direc;
            }
            PrintEnemy(e1X, e1Y);
        }
    }
}
