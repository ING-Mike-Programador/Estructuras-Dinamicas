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
            string[] nombres = { "Miguel", "Jessica", "Itzel", "Javier", "Luis", "Rebeca" };
            int[] edades = { 20, 22, 30, 20, 23, 12 };
            string[] sexo = { "Masculino", "Femenino", "Femenino", "Masculino", "Masculino", "Femenino" };

            pila instanciaPila = new pila();

            Console.WriteLine("ESCRIBIENDO......");

            for (int i = 0; i < 6; i++)
            {
                objetoPila objtpila = new objetoPila();

                objtpila.setNombre(nombres[i]);
                objtpila.setEdad(edades[i]);
                objtpila.setGenero(sexo[i]);

                Console.Write("El nombre escrito es: ");
                Console.WriteLine(objtpila.getNombre());
                Console.Write("La edad escrita es: ");
                Console.WriteLine(objtpila.getEdad());
                Console.Write("El sexo escrito es: ");
                Console.WriteLine(objtpila.getGenero());
                Console.WriteLine();

                instanciaPila.agg(objtpila);
            }
            Console.WriteLine("Presiona ENTER para Imprimir");
            Console.WriteLine("--------------------------------------------");
            Console.ReadLine();
            Console.WriteLine();

            instanciaPila.imprimir();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Presiona ENTER para terminar");
            Console.ReadLine();
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
                objetoNuevo.arriba = objeto;
                objeto = objetoNuevo;
            }
        }
        public void imprimir() // Metodo para imprimir los componentes de la pila //
        {
            if (objeto != null)
            {
                if (objeto.arriba == null)
                {
                    impresiones(objeto);
                }
                else
                {
                    impresiones(objeto);

                    objetoPila recorrido = objeto.arriba;

                    while (recorrido.arriba != null)
                    {
                        impresiones(recorrido);
                        recorrido = recorrido.arriba;
                    }
                    impresiones(recorrido);
                }
            }
            Console.WriteLine();
            Console.WriteLine("No hay nada que imprimir");

        }
        private void impresiones(objetoPila datos)
        {
            Console.WriteLine();
            Console.Write("El nombre escrito es: ");
            Console.WriteLine(datos.getNombre());
            Console.Write("La edad escrita es: ");
            Console.WriteLine(datos.getEdad());
            Console.Write("El sexo escrito es: ");
            Console.WriteLine(datos.getGenero());
            Console.WriteLine();
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
