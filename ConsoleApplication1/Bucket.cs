using System;


namespace ConsoleApplication1
{
    public class Bucket
    {
        private int BucketPositionLeft;
        private int BucketPositionTop;
        private int BucketHight;
        private int BucketWidth;
        private bool[,] BucketStatus;
        private int CurrentCursorLeft, CurrentCursorTop;
        public Bucket()
        {
            BucketPositionLeft = 25;
            BucketPositionTop = 10;
            BucketHight = 30;
            BucketWidth = 30; 
            BucketStatus = new bool[BucketHight, BucketWidth];
        }

        public void PlayGame()
        {
            Console.Clear();
            CreateBucket();
            InitCursorPosObject();
            IObjectOperation obj = new BoxShape();
            PlaceObject(obj);
            KeyDetection();
        }

        private bool PlaceObject(IObjectOperation obj)
        {
//            if (!BucketStatus[CurrentCursorLeft, CurrentCursorTop]) return false;
            Console.SetCursorPosition(CurrentCursorLeft, CurrentCursorTop);
            
            obj.DrawShape();
            return true;
        }

        private void InitCursorPosObject()
        {
            CurrentCursorLeft = (BucketPositionLeft + BucketWidth)/2;
            CurrentCursorTop = BucketPositionTop;
        }

        private void CreateBucket()
        {
            // Initialy set the cursor position where to bucket printing start. 
            Console.SetCursorPosition(BucketPositionLeft, BucketPositionTop);

            for (int i = 0; i < BucketHight; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(new string(' ', BucketWidth));
                // Incriment the cursor position verticaly.
                Console.SetCursorPosition(BucketPositionLeft, BucketPositionTop + i);
            }
            
        }

        private void KeyDetection()
        {
            int bucketPosLeft = BucketPositionLeft,
                bucketPosTop = BucketPositionTop;

            Console.SetCursorPosition(BucketPositionLeft, BucketPositionTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("A");
            do
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow :
                        if (IsValidKey(bucketPosLeft, bucketPosTop + 1))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 1);
                        break;

                    case ConsoleKey.UpArrow :
                        if(IsValidKey(bucketPosLeft, bucketPosTop - 1))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 2);
                        break;

                    case ConsoleKey.RightArrow :
                        if (IsValidKey(bucketPosLeft + 1, bucketPosTop))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 3);
                        break;

                    case ConsoleKey.LeftArrow :
                        if (IsValidKey(bucketPosLeft - 1, bucketPosTop))
                            KeyPressed(ref bucketPosLeft, ref bucketPosTop, 4);
                        break;

                    case ConsoleKey.Escape : 
                        return;
                }

            } while (!Console.KeyAvailable);
        }

        private bool IsValidKey(int x, int y)
        {
            return BucketPositionLeft <= x && x <= (BucketPositionLeft + BucketWidth) - 1 &&
                   BucketPositionTop <= y && y < (BucketPositionTop + BucketHight) - 1;
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
            
        }
       
    }
}