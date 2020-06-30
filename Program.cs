using System;

namespace EvaInternshipChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge1 ch1 = new Challenge1();
            ch1.Solution();
            Console.WriteLine("\n------------------------------");

            Challenge2 ch2 = new Challenge2();
            ch2.Solution();
            Console.WriteLine("\n------------------------------");

            Challenge3 ch3 = new Challenge3();
            ch3.Solution();
            Console.WriteLine("\n------------------------------");

            Challenge4 ch4 = new Challenge4();
            ch4.Solution();
            Console.WriteLine("\n------------------------------");

            Challenge5 ch5 = new Challenge5();
            ch5.Solution();
            Console.WriteLine("\n------------------------------");

            Console.ReadLine();
        }

    }
}
