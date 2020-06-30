using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EvaInternshipChallenge
{
    class Challenge1
    { 
            /*
             
            Challeng  #1
             
             ــــــــــ     ||       ــــــــــــ
            | 12 | 17 | 10|      ||    | a | b | c |
             ــــــــــ     ||       ــــــــــــ
            | 11 |    |   |      ||    | d | e | f |
             ــــــــــ     ||       ــــــــــــ
            |    |    |   |      ||    | g | h | i |
             ــــــــــ     ||       ــــــــــــ

             */

        public void Solution()
        {

            int[,] Box = new int[3, 3];

            Box[0, 0] = 12;
            Box[0, 1] = 17;
            Box[0, 2] = 10;
            Box[1, 0] = 11;

            Console.WriteLine("\nChallenge 1:\n");
            PrintBox(Box);

            FillBox(Box);

            Console.WriteLine("\nSolution is:\n");
            PrintBox(Box);
            Console.WriteLine("\nsum of : {0}\n\n", 3 * Box[1, 1]);

        }
        private static void FillBox(int[,] Box)
        {
            
            //sum = a + b + c
            int Sum = Box[0, 0] + Box[0, 1] + Box[0, 2];
            
            //g = sum - (a + d)
            Box[2, 0] = Sum - (Box[0, 0] + Box[1, 0]);

            //e = sum - (c + g)
            Box[1, 1] = Sum - (Box[0, 2] + Box[2, 0]);

            //h = sum - (b + e)
            Box[2, 1] = Sum - (Box[1, 1] + Box[0, 1]);

            //f = sum - (d + e)
            Box[1, 2] = Sum - (Box[1, 0] + Box[1, 1]);

            //i = sum - (g + h)
            Box[2, 2] = Sum - (Box[2, 0] + Box[2, 1]);
        }
        private static void PrintBox(int[,] Box)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(Box[i, j] + "  ");
                Console.WriteLine();
            }
        }

    }
}
