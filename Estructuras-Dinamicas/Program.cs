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
            objetoPila objtpila = new objetoPila();

            Console.Write("Escribe un nombre: ");
            string nombre = Console.ReadLine();
            objtpila.setNombre(nombre);

            Console.Write("Escribe la edad: ");
            int edad = int.Parse(Console.ReadLine());
            objtpila.setEdad(edad);

            Console.Write("Escribe un sexo: ");
            string genero = Console.ReadLine();
            objtpila.setGenero(genero);

            Console.Clear();

            Console.Write("El nombre escrito es: ");
            Console.WriteLine(objtpila.getNombre());
            Console.Write("La edad escrita es: ");
            Console.WriteLine(objtpila.getEdad());
            Console.Write("El sexo escrito es: ");
            Console.WriteLine(objtpila.getGenero());
            Console.ReadKey();
        }
    }
    public class pila
    {
        // Variables de la clase //
        private objetoPila objeto = null; // Varible privada del objeto de la pila //

        // Constructores de la clase pila //
        public pila() // Constructor vacio //
        { }

        public pila(objetoPila objeto) // Constructor para recibir el objeto //
        {
            this.objeto = objeto;
        }

        // Metodos de la clase //
        public void agg(objetoPila objetoNuevo) // Metodo para agregar otros objetos a la pila //
        {
            if (objeto == null)
            {
                objeto = objetoNuevo;
            }
            else
            {
                // Ciclo para recorrer la pila y guardar donde corresponde el nuevo objeto //
                while (objeto.arriba != null)
                {
                    objeto.arriba = objeto.arriba;
                }
                // asignación al objeto que entrara a la pila //
                objetoNuevo.arriba = objeto;
                objeto = objetoNuevo;
            }
        }
        public string imprimir() // Metodo para imprimir los componentes de la pila //
        {
            if (objeto != null)
            {
                while (objeto.arriba != null)
                {
                    Console.Write("El nombre escrito es: ");
                    Console.WriteLine(objeto.getNombre());
                    Console.Write("La edad escrita es: ");
                    Console.WriteLine(objeto.getEdad());
                    Console.Write("El sexo escrito es: ");
                    Console.WriteLine(objeto.getGenero());
                    objeto.arriba = objeto.arriba;
                }
                Console.Write("El nombre escrito es: ");
                Console.WriteLine(objeto.getNombre());
                Console.Write("La edad escrita es: ");
                Console.WriteLine(objeto.getEdad());
                Console.Write("El sexo escrito es: ");
                Console.WriteLine(objeto.getGenero());
            }
        }

    }
    public class objetoPila
    {
        // variables //
        public objetoPila arriba = null; // Variable publica para determinar al componente de arriba //
        private string nombre = ""; // Variable nombre //
        private string edad = "0"; // Variable edad //
        private string genero = ""; // Variable genero //

        // Constructor de la clase //
        public objetoPila()
        { }

        // Metodos //
        public void setNombre(string Nombre)  // Asignar nombre //
        {
            if (Nombre != null && Nombre.Trim() != "")
            {
                nombre = Nombre.Trim();
            }
            else
            {
                nombre = "Desconocido";
            }
        }
        public void setEdad(int Edad) // Asignar edad //
        {
            if (Edad != null && Edad > 0)
            {
                edad = Edad.ToString();
            }
            else
            {
                edad = "Desconocida";
            }
        }
        public void setGenero(string Genero) // Asignar genero //
        {
            if (Genero != null && Genero.Trim() != "")
            {
                genero = Genero.Trim();
            }
            else
            {
                genero = "Otro";
            }
        }
        public string getNombre() => nombre; // Retorno de la variable nombre //
        public string getEdad() => edad; // Retorno de la variable edad //
        public string getGenero() => genero; // Retorno de la variable genero //
    }
}
