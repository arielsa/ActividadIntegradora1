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
        public void AgregarAuto(Auto pAuto)//////////////////////////////////////////////////////
        {
            la.Add(new Auto(pAuto));
        }
        public void BorrarPersona(Persona pPersona)
        {
            try
            {
                Persona p = lp.Find(x => x.DNI == pPersona.DNI);
                if (p == null) throw new Exception("NO EXISTE");
                lp.Remove(p);
            } catch (Exception ex){ throw ex ;}            
        }
        public void BorrarAuto(Auto pAuto)
        {
            try
            {
                Auto a = la.Find(x=> x.Patente == pAuto.Patente);
                if (a == null) throw new Exception("no existe");
                la.Remove(a);
            } catch ( Exception ex ){ throw ex; }
        }
        public Object RetornaListaPersona()
        {
            return (from p in lp select new { DNI = p.DNI, Apellido_y_Nombre = $"{p.Apellido}, {p.Nombre}" }).ToArray();
        }
        public Object RetornaListaAutos()
        {
            return (from a in la select new { Patente = a.Patente, Marca = a.Marca, Modelo = a.Modelo, Año = a.Año, Precio = a.Precio }).ToArray();
        }
        public bool ValidaDni(Persona pPersona) 
        {
            return lp.Exists(x => x.DNI == pPersona.DNI);
        }
        public bool ValidarPatente(Auto pAuto)
        {
            return la.Exists(x => x.Patente == pAuto.Patente);
        }
    }
}
