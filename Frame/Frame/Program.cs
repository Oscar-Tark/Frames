using System;
using System.Collections;

/*
 * [
[1,0,0,0,0,0]
[0,1,0,1,1,1]
[0,0,1,0,1,0]
[1,1,0,0,1,0]
[1,0,1,1,0,0]
[1,0,0,0,0,1],
]
    */


namespace Frame
{
    //We will do a boolean comparison, this will help us resolve things quicker and with less code.
    class MainClass
    {
        static short[][] matrix = {
        new short[] { 1,0,0,0,0,0 },
        new short[] { 0,1,0,1,1,1 },
        new short[] { 0,0,1,0,1,0 },
        new short[] { 1,1,0,0,1,0 },
        new short[] { 1,0,1,1,0,0 },
        new short[] { 1,0,0,0,0,1 },
    };

        static bool[][] conversion_matrix;

        public static void Main(string[] args)
        {
            //First conver the whole table to boolean values
            conversion_matrix = convertTableToBool();
            convertPixels();
            convertTableToBool();
            printResult();
            return;
        }

        public static void convertPixels()
        {
            //Ignore the boders
            for (int y = 1; y < (matrix.Length-1); y++)
            {
                for (int x = 1; x < 5; x++)
                {
                    //Seek_range
                    if (conversion_matrix[x][y])
                    {
                        //if (conversion_matrix[x - 1][y] || conversion_matrix[x + 1][y] || conversion_matrix[x][y + 1] || conversion_matrix[x][y - 1])
                        //{
                            if (seek(x, y))
                                matrix[x][y] = 0;
                        //}
                    }
                }
            }
        }

        public static bool seek(int x, int y)
        {
            //There are 4 directions in which we can seek
            Console.WriteLine("{0},{1}", x, y);

            bool l = true, r = true, u = true, d = true;
            int increment = 1;
            for(int i = 0; i < 4; i++)
            {
                //Determine direction to seek in
                //0=left, 1=right, 2=down, 3=up
                increment = 1;
                while (true)
                {
                    //Right
                    if (i == 0)
                    {
                        //if true follow
                        if (x + increment < 6)
                        {
                            if (!conversion_matrix[x + increment][y])
                            {
                                //Done, left side is connected
                                r = false;
                                break;
                            }
                        }
                        else
                        {
                            //Done, but not connected
                            break;
                        }
                    }
                    //Left
                    if (i == 1)
                    {
                        //if true follow
                        if (x - increment > -1)
                        {
                            if (!conversion_matrix[x - increment][y])
                            {
                                //Done, left side is not connected
                                l = false;
                                break;
                            }
                        }
                        else
                        {
                            //Done, but not connected
                            break;
                        }
                    }
                    //UP
                    if (i == 2)
                    {
                        //if true follow
                        if (y - increment > -1)
                        {
                            if (!conversion_matrix[x][y - increment])
                            {
                                //Done, left side is not connected
                                u = false;
                                break;
                            }
                        }
                        else
                        {
                            //Done, but not connected
                            break;
                        }
                    }
                    //DOWN
                    if (i == 3)
                    {
                        //if true follow
                        if (y + increment < conversion_matrix.Length - 1)
                        {
                            if (!conversion_matrix[x][y + increment])
                            {
                                //Done, left side is connected
                                d = false;
                                break;
                            }
                        }
                        else
                        {
                            //Done, but not connected
                            break;
                        }
                    }
                    increment++;
                }
                Console.WriteLine("Done: l={0}, r={1}, u={2}, d={3}", l, r, u, d);
            }

            if (!l && !r && !u && !d)
                return true;
            return false;
        }

        public static bool[][] convertTableToBool()
        {
            //conversion not working properly
            bool[][] b_vals = { 
                new bool[6],
                new bool[6],
                new bool[6],
                new bool[6],
                new bool[6],
                new bool[6],
            };

            //Fill Bool table
            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[0].Length; x++)
                {
                    if (matrix[y][x] == 1)
                        b_vals[y][x] = true;
                    else
                        b_vals[y][x] = false;
                    Console.Write("[{0},{1}]", y, x);
                    Console.Write("{0},", b_vals[y][x]);
                }
                Console.Write("\n");
            }

            return b_vals;
        }

        public static void printResult()
        {
            //Fill Bool table
            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[0].Length; x++)
                    Console.Write("{0},", matrix[y][x]);
                Console.Write("\n");
            }
        }
    }
}
