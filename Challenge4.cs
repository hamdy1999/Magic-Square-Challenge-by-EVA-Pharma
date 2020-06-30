using System;
using System.Collections.Generic;

namespace EvaInternshipChallenge
{
    class Challenge4
    {

        /*
         * important >>>> I presumed that zero is NOT a positive integer

          Challeng  #4

            ـــــــــــــــــــــ     ||       ــــــــــــ
           |   |    |    |      ||    |  X+a  | X-a-b |  X+b  |
            ـــــــــــــــــــــ     ||       ــــــــــــ
           |   |    | 18 |      ||    | X-a+b |   X   | X+a+b |
            ـــــــــــــــــــــ     ||       ــــــــــــ
           |   | 28 |    |      ||    |  X-b  | X+a+b |  X-a  |
            ـــــــــــــــــــــ     ||       ــــــــــــ

        * We have 2 valid equations with only 3 variables x, a, b

        * In order to obtain the 3 smallest sums we do the following in a loop
        
        - we assum x and solve a, b 
        
        - then check the solution 

        - and repeat the loop with incrementing x and follow the process untill we get the right solution
        */
        public void Solution()
        {
            int[,] Box = new int[3, 3];
            Box[1, 2] = 18;
            Box[2, 1] = 28;
            Console.WriteLine("Challenge 4:\n");
            PrintBox(Box);


            Console.WriteLine("\nSolution is:\n\n");
            Operation(Box);
            Console.WriteLine("\nConsidering 0 is NOT positive integer------------------------------");

        }
        private static void Operation(int[,] Box)
        {
            /*
             * a + b = 28 - x
             * a - b = 18 - x
             */
        int[,] EquationPrams =
            {
                {1,1,0 },  // we will assign 28 - x inside the loop
                {1,-1,0 }  // we will assign 18 - x inside the loop
            };
            int a = 0, b = 0, x = 0;

            do
            {
                x += 1;
                EquationPrams[0, 2] = 28 - x;
                EquationPrams[1, 2] = 18 - x;
                EquationSolver(EquationPrams, ref a, ref b);
                Box = AssignBox(Box, x, a, b);
            } while (!IsMagicSquare(Box) || !CheckDuplicates(x, a, b));

            PrintBox(Box);
            Console.WriteLine("\nsum of : {0}\n", 3 * Box[1, 1]);
        }
        private static void EquationSolver(int[,] mat, ref int x, ref int y)
        {
            int a = mat[0, 0];
            int b = mat[0, 1];
            int c = mat[1, 0];
            int d = mat[1, 1];
            int e = mat[0, 2];
            int f = mat[1, 2];
            var determinant = a * d - b * c;
            if (determinant != 0)
            {
                x = (e * d - b * f) / determinant;
                y = (a * f - e * c) / determinant;
            }
            else
            {
                throw new System.ArgumentException("Cramer equations system: determinant is zero\n" +
                        "there are either no solutions or many solutions exist.\n");
            }

        }
        private static int[,] AssignBox(int[,] Box, int x, int a, int b)
        {
            Box[0, 0] = x + a;
            Box[0, 1] = x - a - b;
            Box[0, 2] = x + b;
            Box[1, 0] = x - a + b;
            Box[1, 1] = x;
            Box[1, 2] = x + a - b;
            Box[2, 0] = x - b;
            Box[2, 1] = x + a + b;
            Box[2, 2] = x - a;
            return Box;
        }
        private static bool IsMagicSquare(int[,] Box)
        {
            //check for negative integers
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    if (Box[i, j] <= 0) // important >>>> I presumed that zero is NOT a positive integer
                        return false;
                Console.WriteLine();
            }
            // calculate the sum of 
            // the prime diagonal 
            int sum = 0, sum2 = 0;

            for (int i = 0; i < 3; i++)
                sum = sum + Box[i, i];

            // the secondary diagonal 
            for (int i = 0; i < 3; i++)
                sum2 = sum2 + Box[i, 3 - 1 - i];

            if (sum != sum2)
                return false;

            // For sums of Rows 
            for (int i = 0; i < 3; i++)
            {

                int rowSum = 0;
                for (int j = 0; j < 3; j++)
                    rowSum += Box[i, j];

                // check if every row sum is 
                // equal to prime diagonal sum 
                if (rowSum != sum)
                    return false;
            }

            // For sums of Columns 
            for (int i = 0; i < 3; i++)
            {

                int colSum = 0;
                for (int j = 0; j < 3; j++)
                    colSum += Box[j, i];

                // check if every column sum is 
                // equal to prime diagonal sum 
                if (sum != colSum)
                    return false;
            }
            return true;
        }
        private static bool CheckDuplicates(int x, int a, int b)
        {

            //it's much easier and effictive if we used the assigning parameters x, a, b and add elements tp
            //a set instead of looping through the box and loop with 4 nested loop

            //Also, we use hash set for faster accessing

            HashSet<int> Set = new HashSet<int>();

            Set.Add(x + a);

            if (!Set.Contains(x - a - b))
                Set.Add(x - a - b);
            else return false;

            if (!Set.Contains(x + b))
                Set.Add(x + b);
            else return false;

            if (!Set.Contains(x - a + b))
                Set.Add(x - a + b);
            else return false;

            if (!Set.Contains(x))
                Set.Add(x);
            else return false;

            if (!Set.Contains(x + a - b))
                Set.Add(x + a - b);
            else return false;

            if (!Set.Contains(x - b))
                Set.Add(x - b);
            else return false;

            if (!Set.Contains(x + a + b))
                Set.Add(x + a + b);
            else return false;

            if (!Set.Contains(x - a))
                Set.Add(x - a);
            else return false;

            return true;
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
