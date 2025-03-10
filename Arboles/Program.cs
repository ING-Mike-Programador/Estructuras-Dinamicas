using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Arboles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable //
            int[] identificador = { 100, 50, 120, 110, 1, 33 };
            string[] nombres = { "Miguel", "Jessica", "Itzel", "Javier", "Luis", "Rebeca" };
            int[] edades = { 20, 22, 30, 20, 23, 12 };
            string[] sexo = { "Masculino", "Femenino", "Femenino", "Masculino", "Masculino", "Femenino" };
            Arbol arbol = new Arbol();

            // Proceso //
            Console.WriteLine("ESCRIBIENDO......");

            for (int i = 0; i < 6; i++)
            {
                objetoNodo objtNodo = new objetoNodo(identificador[i], nombres[i], edades[i], sexo[i]);
                arbol.Impresiones(objtNodo); // Limpieza de codigo //
                Console.WriteLine();

                arbol.Agregar(objtNodo);
            }
            Console.WriteLine("Presiona ENTER para Imprimir IRD");
            Console.WriteLine("--------------------------------------------");
            Console.ReadLine();

            arbol.ImprimirIRD();

            Console.WriteLine("ELIMINAR");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escribe el ID a eliminar: ");
            string id = Console.ReadLine(); ;
            try
            {
                int ID = int.Parse(id);
                arbol.Eliminar(ID);

            }
            catch (Exception)
            {
                Console.WriteLine("ID no valido");
            }
            Console.WriteLine("Presiona ENTER para Imprimir IRD");
            Console.WriteLine("--------------------------------------------");
            Console.ReadLine();

            arbol.ImprimirIRD();

            Console.WriteLine();
            Console.WriteLine("Presiona ENTER para terminar");
            Console.ReadLine();
        }
    }

    public class Arbol
    {
        // Variables//
        private objetoNodo Nodo = null;

        // Constructores //
        public Arbol() { }
        public Arbol(objetoNodo nodo)
        {
            Agregar(nodo);
        }

        // Metodos//
        public void Agregar(objetoNodo nodo) // Metodo para agregar //
        {
            if (Nodo == null)
            {
                Nodo = nodo;
            }
            else
            {
                if (nodo.Persona.getID() > Nodo.Persona.getID())
                {
                    if (Nodo.Derecha == null)
                    {
                        nodo.Arriba = Nodo;
                        Nodo.Derecha = nodo;
                    }
                    else
                    {
                        objetoNodo recorridoNodo = Nodo.Derecha;
                        recorridoAgg(recorridoNodo, nodo);
                    }
                }
                else if (nodo.Persona.getID() < Nodo.Persona.getID())
                {
                    if (Nodo.Izquierda == null)
                    {
                        nodo.Arriba = Nodo;
                        Nodo.Izquierda = nodo;
                    }
                    else
                    {
                        objetoNodo recorridoNodo = Nodo.Izquierda;
                        recorridoAgg(recorridoNodo, nodo);
                    }
                }
            }
        }
        public void recorridoAgg(objetoNodo Nodo, objetoNodo nodo)// Recorrido para agregar //
        {
            if (nodo.Persona.getID() > Nodo.Persona.getID())
            {
                if (Nodo.Derecha == null)
                {
                    nodo.Arriba = Nodo;
                    Nodo.Derecha = nodo;
                }
                else
                {
                    objetoNodo recorridoNodo = Nodo.Derecha;
                    recorridoAgg(recorridoNodo, nodo);
                }
            }
            else if (nodo.Persona.getID() < Nodo.Persona.getID())
            {
                if (Nodo.Izquierda == null)
                {
                    nodo.Arriba = Nodo;
                    Nodo.Izquierda = nodo;
                }
                else
                {
                    objetoNodo recorridoNodo = Nodo.Izquierda;
                    recorridoAgg(recorridoNodo, nodo);
                }
            }
        }
        public void ImprimirIRD() // Metodo de impresion de menor a mayor (Izquierda-Raiz-Derecha) //
        {
            if (Nodo != null)
            {
                if (Nodo.Izquierda != null)
                {
                    recorridoIRD(Nodo.Izquierda);
                }
                Impresiones(Nodo);
                if (Nodo.Derecha != null)
                {
                    recorridoIRD(Nodo.Derecha);
                }
            }
            else
            {
                Console.WriteLine("No hay nada en el arbol");
            }
        }
        public void recorridoIRD(objetoNodo Nodo) // Recorrido recursivo para imprimir de menor a mayor (Izquierda-Raiz-Derecha) //
        {
            if (Nodo.Izquierda != null)
            {
                recorridoIRD(Nodo.Izquierda);
            }
            Impresiones(Nodo);
            if (Nodo.Derecha != null)
            {
                recorridoIRD(Nodo.Derecha);
            }
        }
        public void ImprimirDRI() // Metodo de impresion de mayor a menor (Derecha-Raiz-Izquierda) //
        {
            if (Nodo != null)
            {
                if (Nodo.Derecha != null)
                {
                    recorridoDRI(Nodo.Derecha);
                }
                Impresiones(Nodo);
                if (Nodo.Izquierda != null)
                {
                    recorridoDRI(Nodo.Izquierda);
                }
                
            }
            else
            {
                Console.WriteLine("No hay nada en el arbol");
            }
        }
        public void recorridoDRI(objetoNodo Nodo) // Recorrido recursivo para imprimir de mayor a menor (Derecha-Raiz-Izquierda) //
        {
            if (Nodo.Derecha != null)
            {
                recorridoDRI(Nodo.Derecha);
            }
            Impresiones(Nodo);
            if (Nodo.Izquierda != null)
            {
                recorridoDRI(Nodo.Izquierda);
            }
        }
        public void Eliminar(int ID) // Metodo para eliminar nodos //
        {
            if (Nodo != null)
            {
                if (Nodo.Persona.getID() == ID)
                {
                    if (Nodo.Izquierda != null)
                    {
                        objetoNodo nodo = Nodo.Izquierda.Derecha;
                        Nodo.Izquierda.Derecha = Nodo.Derecha;
                        Nodo = Nodo.Izquierda;
                        if (nodo != null)
                        {
                            Agregar(nodo);
                        }
                    }
                    else if (Nodo.Derecha != null)
                    {
                        objetoNodo nodo = Nodo.Derecha.Izquierda;
                        Nodo.Derecha.Izquierda = Nodo.Izquierda;
                        Nodo = Nodo.Derecha;
                        if (nodo != null)
                        {
                            Agregar(nodo);
                        }
                    }
                    else
                    {
                        Nodo = null;
                        Console.WriteLine("El arbol ahora esta vacio");
                    }
                }
                else if (ID < Nodo.Persona.getID())
                {
                    recorridoEliminar(Nodo.Izquierda,ID);
                }
                else if (ID > Nodo.Persona.getID())
                {
                    recorridoEliminar(Nodo.Derecha,ID);
                }
                else
                {
                    Console.WriteLine("No existe el elemento");
                }
            }
            else
            {
                Console.WriteLine("No hay nada en el arbol");
            }
        }
        private void recorridoEliminar(objetoNodo Nodo, int ID) // recorrido donde se eliminan nodos //
        {
            if (Nodo.Persona.getID() == ID)
            {
                if (Nodo.Izquierda != null)
                {
                    objetoNodo nodo = Nodo.Izquierda.Derecha;
                    Nodo.Izquierda.Derecha = Nodo.Derecha;
                    Nodo = Nodo.Izquierda;
                    if (nodo != null)
                    {
                        Agregar(nodo);
                    }
                }
                else if (Nodo.Derecha != null)
                {
                    objetoNodo nodo = Nodo.Derecha.Izquierda;
                    Nodo.Derecha.Izquierda = Nodo.Izquierda;
                    Nodo = Nodo.Derecha;
                    if (nodo != null)
                    {
                        Agregar(nodo);
                    }
                }
                else
                {
                    Nodo = null;
                    Console.WriteLine("El arbol ahora esta vacio");
                }
            }
            else if (ID < Nodo.Persona.getID())
            {
                recorridoEliminar(Nodo.Izquierda, ID);
            }
            else if (ID > Nodo.Persona.getID())
            {
                recorridoEliminar(Nodo.Derecha,ID);
            }
            else
            {
                Console.WriteLine("No existe el elemento");
            }
        }
        public void Impresiones(objetoNodo nodo) // Metodo donde se imprimen los datos, para mantener mas limpio el codigo //
        {
            Console.WriteLine("______________________________");
            Console.Write("El identificador es: ");
            Console.WriteLine(nodo.Persona.getID());
            Console.Write("El nombre escrito es: ");
            Console.WriteLine(nodo.Persona.getNombre());
            Console.Write("La edad escrita es: ");
            Console.WriteLine(nodo.Persona.getEdad());
            Console.Write("El sexo escrito es: ");
            Console.WriteLine(nodo.Persona.getGenero());
            Console.WriteLine("______________________________");
        }
    }
    public class objetoNodo
    {
        // Variables //
        public objetoNodo Arriba = null; // Nodo padre (opcional) //
        public objetoNodo Izquierda = null; // Nodo hijo izquierdo //
        public objetoNodo Derecha = null; // // Nodo hijo derecho //

        public datosNodo Persona = new datosNodo(); // Datos de la persona //

        // Constructores //
        public objetoNodo(int Identificador)
        {
            Persona.setID(Identificador);
        } 
        public objetoNodo(int Identificador, string Nombre)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(0);
            Persona.setGenero("");
        }
        public objetoNodo(int Identificador, string Nombre, int Edad)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(Edad);
            Persona.setGenero("");
        }
        public objetoNodo(int Identificador, string Nombre, int Edad, string Genero)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(Edad);
            Persona.setGenero(Genero);
        }

    }
    public class datosNodo
    {
        // Variables //
        private int _id;
        private string _nombre;
        private int _edad;
        private string _genero;

        // Metodos //
        public void setID(int ID)
        {
            _id = ID;
        }
        public void setNombre(string Nombre)
        {
            _nombre = Nombre;
        }
        public void setEdad(int Edad)
        {
            _edad = Edad;
        }
        public void setGenero(string Genero)
        {
            _genero = Genero;
        }
        public int getID()
        {
            return _id;
        }
        public string getNombre()
        {
            return _nombre;
        }
        public int getEdad()
        {
            return _edad;
        }
        public string getGenero()
        {
            return _genero;
        }
    }
}
