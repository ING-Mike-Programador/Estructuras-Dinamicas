﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_Dinamicas
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Variables //
            // datos para mandar a los elementos //
            string[] nombres = { "Miguel", "Jessica", "Itzel", "Javier", "Luis", "Rebeca" };
            int[] edades = { 20, 22, 30, 20, 23, 12 };
            string[] sexo = { "Masculino", "Femenino", "Femenino", "Masculino", "Masculino", "Femenino" };
            // pruebaCola prueba = new pruebaCola(nombres, edades, sexo);
            pruebaLista lista = new pruebaLista(nombres, edades, sexo);
        }

        public class pruebaLista
        {
            // Constructor para ejecutar al momento de crearlo //
            public pruebaLista(string[] nombres, int[] edades, string[] sexo) // se piden en parametros para reutilizar codigo en el resto de los elementos //
            {
                Lista instanciaLista = new Lista();

                Console.WriteLine("ESCRIBIENDO......");

                for (int i = 0; i < 6; i++)
                {
                    objetoLista objtLista = new objetoLista(i + 1, nombres[i], edades[i], sexo[i]);

                    Console.Write("El identificador escrito es: ");
                    Console.WriteLine(objtLista.getIdentificador());
                    Console.Write("El nombre escrito es: ");
                    Console.WriteLine(objtLista.getNombre());
                    Console.Write("La edad escrita es: ");
                    Console.WriteLine(objtLista.getEdad());
                    Console.Write("El sexo escrito es: ");
                    Console.WriteLine(objtLista.getGenero());
                    Console.WriteLine();

                    instanciaLista.agg(objtLista);
                }
                Console.WriteLine("Presiona ENTER para Imprimir");
                Console.WriteLine("--------------------------------------------");
                Console.ReadLine();

                instanciaLista.imprimirTodo();
                string id = "0";
                bool ciclo = true;
                do
                {
                    Console.Write("BUSCAR IDENTIFICADOR: ");
                    id = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("BUSCANDO.................");
                    Console.WriteLine("--------------------------------------------");
                    try
                    {
                        instanciaLista.Buscar(int.Parse(id.Trim()));
                        Console.Write("Deseas terminar? (sí: s / no: cualquier tecla) ");
                        string desicion = Console.ReadLine();
                        if (desicion.Trim().ToLower() == "s")
                        {
                            ciclo = false;
                        }
                    }
                    catch (Exception)
                    {
                        ciclo = true;
                    }
                } while (ciclo);
                do
                {
                    Console.Write("ELIMINAR POR IDENTIFICADOR: ");
                    id = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("BUSCANDO PARA ELIMINAR.................");
                    Console.WriteLine("--------------------------------------------");

                    try
                    {
                        instanciaLista.eliminar(int.Parse(id.Trim()));
                        ciclo = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Identificador invalido");
                        ciclo = true;
                    }
                } while (ciclo);
                Console.WriteLine();
                Console.WriteLine("Presiona ENTER para terminar");
                Console.ReadLine();
            }
        }
        public class Lista
        {
            // Variables de la clase //
            private objetoLista lista = null;
            // Constructor de la clase //
            public Lista()
            { }

            public Lista(objetoLista nuevo)
            {
                agg(nuevo);
            }

            // Metodos de la clase //
            public void agg(objetoLista nuevo) // Metodo para agregar otros objetos a la pila //
            {
                if (lista == null)
                {
                    lista = nuevo;
                    lista.siguiente = lista;
                    lista.anterior = lista;
                }
                else
                {
                    if (lista.siguiente == lista)
                    {
                        nuevo.siguiente = lista;
                        nuevo.anterior = lista;
                        lista.siguiente = nuevo;
                        lista.anterior = nuevo;
                    }
                    else
                    {
                        objetoLista objetoTemporal = lista.siguiente;
                        while (objetoTemporal.siguiente != lista)
                        {
                            objetoTemporal = objetoTemporal.siguiente;
                        }
                        // objetoTemporal.siguiente = nuevo; //
                        nuevo.siguiente = lista;
                        nuevo.anterior = objetoTemporal;
                        objetoTemporal.siguiente = nuevo;
                        lista.anterior = nuevo;
                    }
                }
            }
            public void imprimirTodo() // Metodo para imprimir los componentes de la pila //
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("IMPRIMIENDO.......");
                if (lista != null)
                {
                    if (lista.siguiente == null)
                    {
                        impresiones(lista);
                    }
                    else
                    {
                        impresiones(lista);

                        objetoLista recorrido = lista.siguiente;

                        while (recorrido.siguiente != lista)
                        {
                            impresiones(recorrido);
                            recorrido = recorrido.siguiente;
                        }
                        impresiones(recorrido);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay nada que imprimir");
                }
            }
            public void Buscar(int identificador)
            {
                string ID = identificador.ToString();
                Console.WriteLine("______________________________");
                Console.WriteLine("IMPRIMIENDO ELEMENTO.......");
                if (lista != null)
                {
                    if (lista.getIdentificador() == ID)
                    {
                        impresiones(lista);
                    }
                    else
                    {
                        objetoLista recorrido = lista.siguiente;
                        if (Busqueda(ref recorrido, ID))
                        {
                            impresiones(recorrido);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No se encontro el elemento");
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay nada que imprimir");
                }
            }
            public void eliminar(int identificador) // Metodo para eliminar los componentes de la pila //
            {
                string ID = identificador.ToString();
                Console.WriteLine("______________________________");
                Console.WriteLine("ELIMINANDO ELEMENTO.......");
                Buscar(identificador);
                if (lista != null)
                {
                    if (lista.getIdentificador() == ID)
                    {
                        lista.anterior.siguiente = lista.siguiente;
                        lista.siguiente.anterior = lista.anterior;
                        lista = lista.siguiente;
                    }
                    else
                    {
                        objetoLista recorrido = lista.siguiente;
                        if (Busqueda(ref recorrido, ID))
                        {
                            recorrido.anterior.siguiente = recorrido.siguiente;
                            recorrido.siguiente.anterior = recorrido.anterior;
                            recorrido = lista.siguiente;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No se encontro el elemento");
                        }
                    }
                    imprimirTodo();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay nada que imprimir");
                }
            }
            private void impresiones(objetoLista datos)   // Función para mantener mas limpio el codigo //
            {
                Console.WriteLine("______________________________");
                Console.Write("El identificador anterior es: ");
                Console.WriteLine(datos.anterior.getIdentificador());
                Console.Write("El identificador es: ");
                Console.WriteLine(datos.getIdentificador()); 
                Console.Write("El identificador siguiente es: ");
                Console.WriteLine(datos.siguiente.getIdentificador());
                Console.Write("El nombre escrito es: ");
                Console.WriteLine(datos.getNombre());
                Console.Write("La edad escrita es: ");
                Console.WriteLine(datos.getEdad());
                Console.Write("El sexo escrito es: ");
                Console.WriteLine(datos.getGenero());
                Console.WriteLine("______________________________");
            }
            private bool Busqueda(ref objetoLista buscar, string ID) // Funcion para poder reutilizar la busqueda en Buscar y Eliminar //
            {
                bool encontro = false; // Variable para definir si se encontro o no el elemento //
                while (buscar.getIdentificador() != lista.getIdentificador()) // Ciclo de Busqueda //
                {
                    if (buscar.getIdentificador() == ID) // Condicional para veriificar si el elemento actual es el buscado //
                    {
                        encontro = true;
                        break;
                    }
                    buscar = buscar.siguiente;
                }
                return encontro;
            }
        }
        public class objetoLista
        {
            // variables //
            public objetoLista siguiente = null; // Variable publica para determinar al componente de arriba //
            public objetoLista anterior = null; // Variable publica para determinar al componente de arriba //
            private string identificador = ""; // Variable identificador //
            private string nombre = ""; // Variable nombre //
            private string edad = "0"; // Variable edad //
            private string genero = ""; // Variable genero //

            // Consturctores de la clase //
            public objetoLista(int Identificador)
            {
                setID(Identificador);
            }
            public objetoLista(int Identificador, string Nombre)
            {
                setID(Identificador);
                setNombre(Nombre);
                setEdad(0);
                setGenero("");
            }
            public objetoLista(int Identificador, string Nombre, int Edad)
            {
                setID(Identificador);
                setNombre(Nombre);
                setEdad(Edad);
                setGenero("");
            }
            public objetoLista(int Identificador, string Nombre, int Edad, string Genero)
            {
                setID(Identificador);
                setNombre(Nombre);
                setEdad(Edad);
                setGenero(Genero);
            }

            // Metodos //
            public void setID(int Identificador)
            {
                identificador = Identificador.ToString();
            }
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
            public string getIdentificador() => identificador; // Retorno de la variable identificador //
            public string getNombre() => nombre; // Retorno de la variable nombre //
            public string getEdad() => edad; // Retorno de la variable edad //
            public string getGenero() => genero; // Retorno de la variable genero //
        }
        public class pruebaCola
        {
            // Constructor para ejecutar al momento de crearlo //
            public pruebaCola(string[] nombres, int[] edades, string[] sexo) // se piden en parametros para reutilizar codigo en el resto de los elementos //
            {
                Cola instanciaCola = new Cola();

                Console.WriteLine("ESCRIBIENDO......");

                for (int i = 0; i < 3; i++)
                {
                    objetoCola objtCola = new objetoCola(nombres[i], edades[i], sexo[i]);

                    Console.Write("El nombre escrito es: ");
                    Console.WriteLine(objtCola.getNombre());
                    Console.Write("La edad escrita es: ");
                    Console.WriteLine(objtCola.getEdad());
                    Console.Write("El sexo escrito es: ");
                    Console.WriteLine(objtCola.getGenero());
                    Console.WriteLine();

                    instanciaCola.agg(objtCola);
                }
                Console.WriteLine("Presiona ENTER para Imprimir");
                Console.WriteLine("--------------------------------------------");
                Console.ReadLine();

                instanciaCola.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar");
                Console.WriteLine("--------------------------------------------");
                Console.ReadLine();

                instanciaCola.Eliminar();
                Console.WriteLine();
                instanciaCola.imprimir();

                Console.WriteLine();
                Console.WriteLine("Presiona ENTER para terminar");
                Console.ReadLine();
            }
        }
        public class Cola
        {
            // Variables de la clase //
            private objetoCola objeto = null; // Varible privada del objeto de la pila //

            // Constructores de la clase pila //
            public Cola() // Constructor vacio //
            { }
            public Cola(objetoCola nuevo)
            {
                agg(nuevo);
            }


            // Metodos de la clase //
            public void agg(objetoCola objetoNuevo) // Metodo para agregar otros objetos a la pila //
            {
                if (objeto == null)
                {
                    objeto = objetoNuevo;
                }
                else
                {
                    if (objeto.siguiente == null)
                    {
                        objeto.siguiente = objetoNuevo;
                    }
                    else
                    {
                        objetoCola objetoTemporal = objeto.siguiente;
                        while (objetoTemporal.siguiente != null)
                        {
                            objetoTemporal = objetoTemporal.siguiente;
                        }
                        objetoTemporal.siguiente = objetoNuevo;
                    }
                }
            }
            public void imprimir() // Metodo para imprimir los componentes de la pila //
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("IMPRIMIENDO.......");
                if (objeto != null)
                {
                    if (objeto.siguiente == null)
                    {
                        impresiones(objeto);
                    }
                    else
                    {
                        impresiones(objeto);

                        objetoCola recorrido = objeto.siguiente;

                        while (recorrido.siguiente != null)
                        {
                            impresiones(recorrido);
                            recorrido = recorrido.siguiente;
                        }
                        impresiones(recorrido);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay nada que imprimir");
                }
            }
            public void Eliminar() // Metodo para eliminar los componentes de la pila //
            {
                if (objeto.siguiente == null) // En caso que solo sea 1 solo elemento en la cola //
                {
                    objeto = null;
                }
                else // En caso de ser 2 o mas elementos //
                {
                    objetoCola objetoTemporal = objeto.siguiente,
                        objetoTemporalAnterior = objeto;

                    while (objetoTemporal.siguiente != null)
                    {
                        objetoTemporalAnterior = objetoTemporal;
                        objetoTemporal = objetoTemporal.siguiente;
                    }
                    Console.WriteLine("______________________________");
                    Console.WriteLine("ELIMINANDO.......");
                    impresiones(objetoTemporal);
                    objetoTemporalAnterior.siguiente = null;
                }
            }
            private void impresiones(objetoCola datos)   // Función para mantener mas limpio el codigo //
            {
                Console.WriteLine("______________________________");
                Console.Write("El nombre escrito es: ");
                Console.WriteLine(datos.getNombre());
                Console.Write("La edad escrita es: ");
                Console.WriteLine(datos.getEdad());
                Console.Write("El sexo escrito es: ");
                Console.WriteLine(datos.getGenero());
                Console.WriteLine("______________________________");

            }

        }
        public class objetoCola
        {
            // variables //
            public objetoCola siguiente = null; // Variable publica para determinar al componente de arriba //
            private string nombre = ""; // Variable nombre //
            private string edad = "0"; // Variable edad //
            private string genero = ""; // Variable genero //

            // Consturctores de la clase //
            public objetoCola()
            {
            }
            public objetoCola(string Nombre)
            {
                setNombre(Nombre);
                setEdad(0);
                setGenero("");
            }
            public objetoCola(string Nombre, int Edad)
            {
                setNombre(Nombre);
                setEdad(Edad);
                setGenero("");
            }
            public objetoCola(string Nombre, int Edad, string Genero)
            {
                setNombre(Nombre);
                setEdad(Edad);
                setGenero(Genero);
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
            public string getNombre() => nombre; // Retorno de la variable nombre //
            public string getEdad() => edad; // Retorno de la variable edad //
            public string getGenero() => genero; // Retorno de la variable genero //
        }
        public class pruebaPila
        {
            // Constructor de la clase para ejecutar los metodos al iniciar //
            public pruebaPila(string[] nombres, int[] edades, string[] sexo) // Parametros para reutilizar datos en el resto de elementos //
            {
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

                instanciaPila.imprimir();

                Console.WriteLine();
                Console.WriteLine("Presiona ENTER para Eliminar de la pila");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();
                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

                Console.WriteLine("Presiona ENTER para Eliminar de la pila otra vez");
                Console.ReadLine();
                Console.WriteLine();

                instanciaPila.Eliminar();

                Console.WriteLine("Imprimiendo......");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

                instanciaPila.imprimir();

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
                agg(objeto);
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
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No hay nada que imprimir");
                }
            }
            public void Eliminar() // Metodo para eliminar los componentes de la pila //
            {
                if (objeto != null)
                {
                    objeto = objeto.arriba;
                }
                else
                {
                    Console.WriteLine("La pila esta vacia");
                }
            }
            private void impresiones(objetoPila datos)   // Función para mantener mas limpio el codigo //
            {
                Console.WriteLine("______________________________");
                Console.Write("El nombre escrito es: ");
                Console.WriteLine(datos.getNombre());
                Console.Write("La edad escrita es: ");
                Console.WriteLine(datos.getEdad());
                Console.Write("El sexo escrito es: ");
                Console.WriteLine(datos.getGenero());
                Console.WriteLine("______________________________");

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
            public objetoPila(string Nombre)
            {
                setNombre(Nombre);
                setEdad(0);
                setGenero("");
            }
            public objetoPila(string Nombre, int Edad)
            {
                setNombre(Nombre);
                setEdad(Edad);
                setGenero("");
            }
            public objetoPila(string Nombre, int Edad, string Genero)
            {
                setNombre(Nombre);
                setEdad(Edad);
                setGenero(Genero);
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
            public string getNombre() => nombre; // Retorno de la variable nombre //
            public string getEdad() => edad; // Retorno de la variable edad //
            public string getGenero() => genero; // Retorno de la variable genero //
        }
    }
}