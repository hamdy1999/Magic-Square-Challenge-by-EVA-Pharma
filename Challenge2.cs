using System;

namespace EvaInternshipChallenge
{
    class Challenge2
    {
        /*

           Challeng  #2

            ـــــــــــــــــــــ     ||       ــــــــــــ
           |    | 7 | 16 |      ||    |  X+a  | X-a-b |  X+b  |
            ـــــــــــــــــــــ     ||       ــــــــــــ
           | 15 |   |    |      ||    | X-a+b |   X   | X+a+b |
            ـــــــــــــــــــــ     ||       ــــــــــــ
           |    |   | 11 |      ||    |  X-b  | X+a+b |  X-a  |
            ـــــــــــــــــــــ     ||       ــــــــــــ

            */
        public void Solution()
        {
            int[,] Box = new int[3, 3];

            Box[0, 1] = 7;
            Box[0, 2] = 16;
            Box[1, 0] = 15;
            Box[2, 2] = 11;

            Console.WriteLine("Challenge 2:\n");
            PrintBox(Box);

            Console.WriteLine("\nSolution is:\n\n");
            Operation(Box);
            
        }
        public static void Operation(int[,] Box)
        {
            double[][] Coeff = new double[3][];
            double[] RHS = new double[3];
            AssigneMatrix(ref Coeff, ref RHS);
            int[] Sol = GetSolution(Coeff, RHS);

            Box = AssignBox(Box, Sol[0], Sol[1], Sol[2]);

            PrintBox(Box);
            Console.WriteLine("\nsum of : {0}\n\n", 3 * Box[1, 1]);

        }

        private static void AssigneMatrix(ref double[][] Coeff, ref double[] RHS)
        {
            /*
             * X - a - b = 7
             * X + b = 16
             * X - a = 11
             */

            //int[][] Coeff = new int[3][];
            Coeff[0] = new double[] { 1, -1, -1 };
            Coeff[1] = new double[] { 1, 0, 1 };
            Coeff[2] = new double[] { 1, -1, 0 };
            RHS = new double[] { 7, 16, 11 };

        }
        private static int[] GetSolution(double[][] Coeff, double[] RHS)
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


            int[] solution = new int[N];
            for (int i = N - 1; i >= 0; i--)
            {
                double sum = 0.0;
                for (int j = i + 1; j < N; j++)
                    sum += Coeff[i][j] * solution[j];
                solution[i] =(int) (RHS[i] - sum) /(int) Coeff[i][i];
            }
            return solution;
        }
        private static int[,] AssignBox(int[,] box, int x, int a, int b)
        {
            box[0, 0] = x + a;
            box[0, 1] = x - a - b;
            box[0, 2] = x + b;
            box[1, 0] = x - a + b;
            box[1, 1] = x;
            box[1, 2] = x + a - b;
            box[2, 0] = x - b;
            box[2, 1] = x + a + b;
            box[2, 2] = x - a;
            return box;
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
