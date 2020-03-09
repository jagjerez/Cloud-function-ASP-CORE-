using Cliente_A.Architecture;
using System;
using System.ComponentModel.Design;

namespace Cliente_A
{
    class Program
    {
        //private static ClienteA cliente{ get; set; }
        private static bool espera {get;set;}
        static void Main(string[] args)
        {
            espera = true;
            ClienteA cliente = new ClienteA();
            cliente.CloudFunction<string>().Subscribe((s) => 
            {
                Console.WriteLine(s);
                Console.Write("Press 'c' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "c") cliente.cerrar();
            },
            () =>
            {
                espera = false;
            }
            );
            while (espera) { }
        }


        
    }
}
