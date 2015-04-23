using System;
using System.Net;
using System.Threading;

namespace ConsoleApplication1
{
    internal class Program
    {
        public const int WindowHight = 40;
        private const int WindowWidht = 100;
        public static void Main(string[] args)
        {
            Menu menu = new Menu(WindowHight, WindowWidht);
            Bucket bucket = new Bucket();
            
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                int selection = menu.MenuOparation();
                if (selection == 0) bucket.PlayGame();
                else if (selection == 2) break;
            }
             
        }
    }
}