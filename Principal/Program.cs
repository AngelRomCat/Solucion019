using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;

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
            program.Read();//Intro
            program.Read();//0
            program.Read();//1
            program.Read();//Angel

            program.Update();
            program.Read();
            program.Delete();
            program.Read();
            program.ExperimentoConObjetosIguales();
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

            foreach (persona persona in personas)
            {
                Console.WriteLine(persona.id + " " + persona.nombre);
            }
            Console.ReadLine();
        }

        private void Update()
        {
            Console.WriteLine("Escribe el ID o el NOMBRE de los registros que quieres modificar");
            string texto = Console.ReadLine();

            IList<persona> personas = null;
            if (texto != null && texto != "")
            {
                personas = _class1.Read(texto);

                Console.WriteLine("Escribe el nuevo NOMBRE de los registros que quieres modificar");
                texto = Console.ReadLine();

                bool ok = false;
                if (texto != null && texto != "")
                {
                    ////foreach NO PUEDE MODIFICAR LOS ATRIBUTOS DE SUS OBJETOS
                    //foreach (persona persona in personas)
                    //{
                    //    persona.nombre = texto;
                    //}
                    for (int i = 0; i < personas.Count; i++)
                    {
                        personas[i].nombre = texto;
                        ok = true;
                    }

                    //NO ES NECESARIO DEBIDO A LA INTERRELACIÓN DE OBJETOS
                    //SI ELIMINAMOS ESTE IF() FUNCIONA IGUAL
                    if (ok == true)
                    {
                        ok = _class1.Update(personas);
                    }
                    //HASTA AQUÍ...

                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                    Console.WriteLine("La modificación de los registros ha sido: " + ok);
                }
            }
            Console.ReadLine();
        }

        private void Delete()
        {
            Console.WriteLine("Escribe el ID o el NOMBRE de los registros que quieres eliminar");
            string texto = Console.ReadLine();

            IList<persona> personas = null;
            if (texto != null && texto != "")
            {
                personas = _class1.Read(texto);

                bool ok = false;
                ok = _class1.Delete(personas);

                if (ok == true)
                {
                    ok = _class1.GuardarCambios();
                }
                Console.WriteLine("La eliminación de los registros ha sido: " + ok);
            }
            Console.ReadLine();
        }

        private void ExperimentoConObjetosIguales()
        {
            //Creamos un objeto de la clase Fruta llamado: frutaOriginal
            //cuyos atributos valdrán: Amarillo, Plátano, Alargado y blando
            Console.WriteLine("Creamos frutaOriginal: ");
            Fruta frutaOriginal = null;
            frutaOriginal = new Fruta();
            frutaOriginal.name = "Plátano";
            frutaOriginal.color = "Amarillo";
            frutaOriginal.description = "Alargado y blando";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            Console.WriteLine("Creamos frutaModificada: ");
            Fruta frutaModificada = null;
            frutaModificada = frutaOriginal;

            Console.WriteLine("Cambiamos los Valores de frutaModificada: ");
            frutaModificada.name = "Pera";
            frutaModificada.color = "Verde";
            frutaModificada.description = "Con forma de pera";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            Console.WriteLine("Cambiamos los Valores de frutaOriginal: ");
            frutaOriginal.name = "Plátano";
            frutaOriginal.color = "Amarillo";
            frutaOriginal.description = "Alargado y blando";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            Console.WriteLine("Valores de frutaModificada: ");
            Console.WriteLine(frutaModificada.name + ", " + frutaModificada.color + " y " + frutaModificada.description);
            Console.ReadLine();
        }
    }
}
