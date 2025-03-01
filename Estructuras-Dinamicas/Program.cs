﻿using System;
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
    
    public class objetoPila
    {
        // variables //
        private objetoPila objSig = null; // Variable privada para asimilar al siguiente componente que vendra //
        private string nombre = ""; // Variable nombre //
        private string edad = "0"; // Variable edad //
        private string genero = ""; // Variable genero //

        // Constructor de la clase //
        public objetoPila()
        {
        }


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
        public string getNombre() => nombre;
        public string getEdad() => edad;
        public string getGenero() => genero;
    }
}
