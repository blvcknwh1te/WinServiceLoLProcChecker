// See https://aka.ms/new-console-template for more information
//using CustomService;


using System.Diagnostics;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Checker checker = new Checker();
            try
            {
                Thread checkerThread = new Thread(() => checker.Start());
                checkerThread.Start();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Constr: " + ex.Message);
            }

        }
    }

}

