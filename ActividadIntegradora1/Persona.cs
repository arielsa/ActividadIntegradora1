using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ActividadIntegradora1
{
    public class Persona
    {
        List<Auto> la;

        public Persona()
        {
            la = new List<Auto>();
        }

        public Persona(string pNombre, string pApellido, string pDNI) : this()
        {            
            Nombre = pNombre;
            Apellido = pApellido;
            DNI = pDNI;
        }

        public Persona (Persona pPersona) : this( pPersona.DNI, pPersona.Apellido, pPersona.Nombre )
        {

        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

    }
}
