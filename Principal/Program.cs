using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    internal class Program
    {
        private static Class1 _class1 = null;
        static void Main(string[] args)
        {
            _class1 = new Class1();
            Program program = new Program();
            program.Create();
            program.Read();
            program.Read();
            program.Read();
            program.Read();
            program.Read();
        }

        private void Create()
        {
            bool ok = false;
            Console.WriteLine("Escribe el NOMBRE de la persona del nuevo registro");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                persona persona = new persona();
                //persona.id = ??;
                persona.nombre = texto;

                Console.WriteLine("Escribe el PRIMER APELLIDO de la persona del nuevo registro");
                texto = Console.ReadLine();
                if (texto != null && texto != "")
                {
                    persona.apellido01 = texto;

                    Console.WriteLine("Escribe el SEGUNDO APELLIDO de la persona del nuevo registro");
                    texto = Console.ReadLine();
                    if (texto != null && texto != "")
                    {
                        persona.apellido02 = texto;
                    }

                    ok = _class1.Create(persona);
                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                }
            }
            Console.WriteLine("La inserción del nuevo registro ha sido: " + ok);
            Console.ReadLine();
        }

        private void Read()
        {
            Console.WriteLine("Escribe el ID o el NOMBRE del registro que quieres leer");
            string texto = Console.ReadLine();

            IList<persona> personas = null;
            //personas = new List<persona>();
            personas = _class1.Read(texto);

            foreach(persona persona in personas)
            {
                Console.WriteLine(persona.id + " " + persona.nombre);
            }
            Console.ReadLine();
        }
    }
}
