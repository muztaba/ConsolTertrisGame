﻿using System;


namespace ConsoleApplication1
{
    public class Bucket
    {
        private const int BucketPositionLeft = 25;
        private const int BucketPositionTop = 10;
        private const int BucketHight = 30;
        private const int BucketWidth = 30;
        private bool[,] bucketStatus;
        private int currentCursorLeft, currentCursorTop;
        private Random random;
        private IObjectOperation obj;
//        private bool GameOver;
        public Bucket()
        {
            bucketStatus = new bool[BucketHight, BucketWidth];
            random = new Random(); // 'This is for select object randomly.
//            GameOver = false;
        }

        /**
         * This is method responsible for the control the flow of the game
         */
        public void PlayGame()
        {
            Console.Clear();
            CreateBucket();
            while (true)
            {
                InitCursorPosObject();
                obj = ChoseRandomObject();
                if (obj == null) continue;
                if (!InitialyPlaceObject()) break;
                KeyDetection();
            }
        }

        /**
         * Set the cursor position for the initial object position. That 
         * is in the middle of the bucket.
         */
        private void InitCursorPosObject()
        {
            currentCursorLeft = BucketPositionLeft + (BucketWidth / 2);
            currentCursorTop = BucketPositionTop;
        }

        /**
         * Place a random object to the upper middle of the bucket. This is method return 
         * boolean value. If the method return 'False' then there is no way to place new object.
         * That time the game is over. Otherwise when it is true then the game will continue.
         */
        private bool InitialyPlaceObject()
        {
            //            if (!BucketStatus[CurrentCursorLeft, CurrentCursorTop]) return false;
            Console.SetCursorPosition(currentCursorLeft, currentCursorTop);

            obj.DrawShape(currentCursorLeft, currentCursorTop);
            return true;
        }

        /**
         * Create bucket for the first time.
         */
        private void CreateBucket()
        {
            // Initialy set the cursor position where to bucket printing start. 
            Console.SetCursorPosition(BucketPositionLeft, BucketPositionTop);

            for (int i = 0; i <= BucketHight; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(new string(' ', BucketWidth));
                // Incriment the cursor position verticaly.
                Console.SetCursorPosition(BucketPositionLeft, BucketPositionTop + i);
            }

        }

        /**
         * This method return a randomly chose object.
         */

        private IObjectOperation ChoseRandomObject()
        {
            /*
             * Genarate random value 1 to 5. There is 5 object in the game.
             */
            int rand = random.Next(1, 5);

            switch (rand)
            {
                case 1:
                    return new BoxShape(BucketPositionLeft, BucketPositionTop, BucketHight, BucketWidth);

            }
            return null;
        }

        private void KeyDetection()
        {
            int bucketPosLeft = currentCursorLeft,
                bucketPosTop = currentCursorTop;

            Console.SetCursorPosition(bucketPosLeft, bucketPosTop);
            Console.ForegroundColor = ConsoleColor.Red;
//            Console.Write("A");
            do
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (IsValidKey(bucketPosLeft, bucketPosTop + 1))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 1);
                        break;

                    case ConsoleKey.UpArrow:
                        if (IsValidKey(bucketPosLeft, bucketPosTop - 1))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 2);
                        break;

                    case ConsoleKey.RightArrow:
                        if (IsValidKey(bucketPosLeft + 1, bucketPosTop))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 3);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (IsValidKey(bucketPosLeft - 1, bucketPosTop))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 4);
                        break;

                    case ConsoleKey.Escape:
                        return;

                }


            } while (!Console.KeyAvailable);
        }

        private bool IsValidKey(int x, int y)
        {
            return BucketPositionLeft <= x && x <= (BucketPositionLeft + BucketWidth) - 1 &&
                   BucketPositionTop <= y && y <= (BucketPositionTop + BucketHight) - 1;
        }

        private void KeyPressed(ref int x, ref int y, int select)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");

            if (select == 1) y++;
            else if (select == 2) y--;
            else if (select == 3) x++;
            else if (select == 4) x--;

            Console.SetCursorPosition(x, y);
            Console.Write("A");
            showRowCol(x, y);
            //            Console.SetCursorPosition(x, y);

        }

        private void showRowCol(int x, int y)
        {
            Console.SetCursorPosition(10, 10);
            Console.Write(new string(' ', 5));
            Console.Write(x + " " + y);
        }

    }
}