using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_Dinamicas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String nombre = "";
            String Nombre = Console.ReadLine();
            if (Nombre != null && Nombre.Trim() != "")
            {
                nombre = Nombre;
            }
            else
            {
                nombre = "Desconocido";
            }

            Console.WriteLine(nombre);
            Console.ReadKey();
        }
    }
}
