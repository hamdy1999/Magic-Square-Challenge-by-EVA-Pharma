using System;
using System.Collections.Generic;
using System.Text;

namespace EvaInternshipChallenge
{
    class Challenge3
    {
        /*

           Challeng  #3

            ـــــــــــــــــــــ     ||       ـــــــــــــ
           |    |    |    |      ||    |  X+a  | X-a-b |  X+b  |
            ـــــــــــــــــــــ     ||       ـــــــــــــ
           | 31 |    | 15 |      ||    | X-a+b |   X   | X+a+b |
            ـــــــــــــــــــــ     ||       ـــــــــــــ
           |    | 28 |    |      ||    |  X-b  | X+a+b |  X-a  |
            ـــــــــــــــــــــ     ||       ـــــــــــــ

            */
        public void Solution()
        {
            int[,] Box = new int[3, 3];

            Box[01, 0] = 31;
            Box[1, 2] = 15;
            Box[2, 1] = 41;

            Console.WriteLine("Challenge 3:\n");
            PrintBox(Box);

            Console.WriteLine("\nSolution is:\n");
            Operation(Box);

        }
        public static void Operation(int[,] Box)
        {
            double[][] Coeff = new double[3][];
            double[] RHS = new double[3];
            AssigneMatrix(ref Coeff, ref RHS);
            int[] Sol = SolveEquation(Coeff, RHS);

            Box = AssignBox(Box, Sol[0], Sol[1], Sol[2]);

            PrintBox(Box);
            Console.WriteLine("\nsum of : {0}\n\n", 3 * Box[1, 1]);

        }

        private static void AssigneMatrix(ref double[][] Coeff, ref double[] RHS)
        {
            /*
             * X - a + b = 31
             * X + a - b = 15
             * X + a + b = 41
             */

            //int[][] Coeff = new int[3][];
            Coeff[0] = new double[] { 1, -1, 1 };
            Coeff[1] = new double[] { 1, 1, -1 };
            Coeff[2] = new double[] { 1, 1, 1 };
            RHS = new double[] { 31, 15, 41 };

        }
        private static int[] SolveEquation(double[][] Coeff, double[] RHS)
        {
            //Using Gaussian Elimination Algorithm

            int N = RHS.Length;
            for (int k = 0; k < 3; k++)
            {

                int max = k;
                for (int i = k + 1; i < N; i++)
                    if (Math.Abs(Coeff[i][k]) > Math.Abs(Coeff[max][k]))
                        max = i;

                double[] temp = Coeff[k];
                Coeff[k] = Coeff[max];
                Coeff[max] = temp;

                double t = RHS[k];
                RHS[k] = RHS[max];
                RHS[max] = t;

                for (int i = k + 1; i < N; i++)
                {
                    double factor = Coeff[i][k] / Coeff[k][k];
                    RHS[i] -= factor * RHS[k];
                    for (int j = k; j < N; j++)
                        Coeff[i][j] -= factor * Coeff[k][j];
                }
            }


            int[] Solution = new int[N];
            for (int i = N - 1; i >= 0; i--)
            {
                double Sum = 0.0;
                for (int j = i + 1; j < N; j++)
                    Sum += Coeff[i][j] * Solution[j];
                Solution[i] = (int)(RHS[i] - Sum) / (int)Coeff[i][i];
            }
            return Solution;
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
