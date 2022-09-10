using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class Class1
    {
        private static UnaTablaDbContext _db = null;
        public Class1(){
            if (_db == null)
            {
                _db = new UnaTablaDbContext();
            }
        }   

        public bool Create(persona persona)
        {
            _db.persona.Add(persona);

            return true;    
        }

        public bool GuardarCambios()
        {
            bool ok = false;
            try
            {
                int respuesta = 0;
                respuesta = _db.SaveChanges();
                if (respuesta > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public IList<persona> Read(string texto)
        {
            IList<persona> personas = null;
            //personas = new List<persona>();

            //texto == null
            //devolveremos todos los registros
            personas = _db.persona.ToList();

            if (texto != null && texto != "")
            {   //texto != null && texto != ""
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {   //texto == INT
                    id = int.Parse(texto);
                    
                    if (id > 0)
                    {//texto > 0
                     //Devolveremos el registro con ese id

                        personas = personas.Where(x => x.id == id).ToList();
                        //persona persona = personas.Where(x => x.id == id).FirstOrDefault();
                    }
                }
                else
                {
                    //texto != INT
                    //Devolveremos todos los registros con ese nombre
                    personas = personas.Where(x => x.nombre == texto).ToList();
                }
            }

            return personas;
        }

        ////NO ES NECESARIO DEBIDO A LA INTERRELACIÓN DE OBJETOS
        ////SI ELIMINAMOS ESTE MÉTODO FUNCIONA IGUAL
        public bool Update(IList<persona> personas)
        {
            bool ok = false;

            foreach (var persona in personas)
            {
                _db.persona.Where(x => x.id == persona.id).FirstOrDefault().nombre = persona.nombre;
                ok = true;
            }

            return ok;
        }
        ////HASTA AQUÍ...

        public bool Delete(IList<persona> personas)
        {
            bool ok = false;
            foreach (persona persona in personas)
            {
                _db.persona.Remove(persona);
                ok = true;
            }

            return ok;
        }
    }
}
