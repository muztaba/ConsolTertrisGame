using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Menu
    {
        private int CursorPositionLeft;
        private int CursorPositionTop;
        private int PadLeft;
        private int PadRight;
        private int BottomCursorPosition;
        private int Select;
        private List<string> MenuList = new List<string>();
       
        /**
         * Initialize the Menu consol's winodws size, title, and the MenuList. 
         */
        public Menu(int windowHight, int windowWidth)
        {
            Console.Title = "Tetris";
            Console.WindowHeight = windowHight;
            Console.WindowWidth = windowWidth;
            
            MenuList.Add("Play Game");
            MenuList.Add("High Score");
            MenuList.Add("Esc to exit");

            
            CursorPositionLeft = 40;
            CursorPositionTop = 20;
            PadLeft = 20;
            PadRight = 30;
            BottomCursorPosition = (MenuList.Count + CursorPositionTop) - 1;
//            Console.CursorVisible = false;
        }

        /**
         * Oparate the menu 
         */
        public int MenuOparation()
        {   
            // Initialy the menu is placed. That is place the String that is in the List.
            PlaceMenuString();
            // Listen for the key from the keyboard. And also nevigate the menu.
            MenuNevigation();

            return Select;
        }

        private void PlaceMenuString()
        {
            for (int i = 0; i < MenuList.Count; i++)
            {
                if (i == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(CursorPositionLeft - 10, CursorPositionTop + i);
                    Console.WriteLine(MenuList[i].PadLeft(PadLeft).PadRight(PadRight));
                }
                else
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop + i);
                    Console.WriteLine(MenuList[i]);
                }
            }
        }

        private void MenuNevigation()
        {
            Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
            int cursorPos = CursorPositionTop;
            do
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        cursorPos = DownKeyOparation(cursorPos);
                        break;

                    case ConsoleKey.UpArrow :
                        cursorPos = UpKeyOparation(cursorPos);
                        break;

                    case ConsoleKey.Enter :
                        Select = cursorPos - CursorPositionTop;
                        return;
                        
                        
                }

            } while (!Console.KeyAvailable);
        }

        private int DownKeyOparation(int cursorPos)
        {
            if (Console.CursorTop < BottomCursorPosition)
            {
                DeleteLine(cursorPos);
                WriteLine(cursorPos - CursorPositionTop, false);
                cursorPos++;
                DeleteLine(cursorPos);
                WriteLine(cursorPos - CursorPositionTop, true);
                Console.ResetColor();

            }
            return cursorPos;
        }

        private int UpKeyOparation(int cursorPos)
        {
            if (Console.CursorTop > CursorPositionTop)
            {
                DeleteLine(cursorPos);
                WriteLine(cursorPos - CursorPositionTop, false);
                cursorPos--;
                DeleteLine(cursorPos);
                WriteLine(cursorPos - CursorPositionTop, true);
                Console.ResetColor();
            }
            return cursorPos;
        }

        /**
         * Delete line at the current cursor position. The lefe cursor position is at 0;
         */
        private void DeleteLine(int cursorPos)
        {
            Console.SetCursorPosition(0, cursorPos);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        private void WriteLine(int i, bool padding)
        {

            if (!padding)
            {
                Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop + i);
                Console.Write(MenuList[i]);
            }
            else
            {
                Console.SetCursorPosition(CursorPositionLeft - 10, CursorPositionTop + i);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(MenuList[i].PadLeft(PadLeft).PadRight(PadRight));
                Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop + i);
            }
        }

    } 
    

}
