namespace Arboles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable //

            string[] nombres = { "Miguel", "Jessica", "Itzel", "Javier", "Luis", "Rebeca" };
            int[] edades = { 20, 22, 30, 20, 23, 12 };
            string[] sexo = { "Masculino", "Femenino", "Femenino", "Masculino", "Masculino", "Femenino" };
            
            // Proceso //
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
        }
    }
    public class Arbol
    {
        private objetoNodo Nodo = null;

        public Arbol() { }
        public Arbol(objetoNodo nodo)
        {
            Agregar(nodo);
        }
        public void Agregar(objetoNodo nodo)
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
                        Nodo.Derecha = nodo;
                    }
                    else
                    {
                        objetoNodo recorridoNodo = Nodo.Derecha;
                        RecorridoAgg(recorridoNodo);
                    }
                }
                else if (nodo.Persona.getID() < Nodo.Persona.getID())
                {
                    if (Nodo.Izquierda == null)
                    {
                        Nodo.Izquierda = nodo;
                    }
                    else
                    {
                        objetoNodo recorridoNodo = Nodo.Izquierda;
                        RecorridoAgg(recorridoNodo, nodo);
                    }
                }
            }
        }
        public void recorridoAgg(objetoNodo Nodo, objetoNodo nodo)
        {
            if (nodo.Persona.getID() > Nodo.Persona.getID())
            {
                if (Nodo.Derecha == null)
                {
                    Nodo.Derecha = nodo;
                }
                else
                {
                    objetoNodo recorridoNodo = Nodo.Derecha;
                    RecorridoAgg(recorridoNodo);
                }
            }
            else if (nodo.Persona.getID() < Nodo.Persona.getID())
            {
                if (Nodo.Izquierda == null)
                {
                    Nodo.Izquierda = nodo;
                }
                else
                {
                    objetoNodo recorridoNodo = Nodo.Izquierda;
                    RecorridoAgg(ref recorridoNodo);
                }
            }
        }
    }
    public class objetoNodo
    {
        public objetoNodo Arriba = null;
        public objetoNodo Izquierda = null;
        public objetoNodo Derecha = null;
        public datosNodo Persona = new datosNodo();

        public objetoLista(int Identificador)
        {
            Persona.setID(Identificador);
        }
        public objetoLista(int Identificador, string Nombre)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(0);
            Persona.setGenero("");
        }
        public objetoLista(int Identificador, string Nombre, int Edad)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(Edad);
            Persona.setGenero("");
        }
        public objetoLista(int Identificador, string Nombre, int Edad, string Genero)
        {
            Persona.setID(Identificador);
            Persona.setNombre(Nombre);
            Persona.setEdad(Edad);
            Persona.setGenero(Genero);
        }

    }
    public class datosNodo
    {
        private int _id;
        private string _nombre;
        private int _edad;
        private string _genero;

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
