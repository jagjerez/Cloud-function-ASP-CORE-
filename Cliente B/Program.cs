using Cliente_B.Architecture;
using System;

namespace Cliente_B
{
    class Program
    {
        private static bool cerrar {get;set;}
        static void Main(string[] args)
        {
            cerrar = false;
            ClienteB s = new ClienteB();
            while (!cerrar)
            {
                Console.Write("Send Message to Client A: ");

                string numInput1 = Console.ReadLine();
                if (numInput1.Length <= 0)
                {
                    continue;
                }
                s.sendMessage(numInput1);
                

                Console.Write("Press 'c' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "c") cerrar = true;
            }
            Console.WriteLine("Hello World!");
        }
    }
}
