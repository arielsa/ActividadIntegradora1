using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadIntegradora1
{
    public class Empresa
    {
        List<Persona> lp;
        List<Auto> la;

        public Empresa()
        {
            la = new List<Auto>();
           lp =  new List<Persona>();
        }

        public void AgregarPersona(Persona pPersona) 
        {
            lp.Add(new Persona(pPersona));
        }

        public Object RetornaListaPersona()
        {
            return (from p in lp select new { DNI = p.DNI, Apellido_y_Nombre = $"{p.Apellido}, {p.Nombre}" }).ToArray();
        }
    }
}
