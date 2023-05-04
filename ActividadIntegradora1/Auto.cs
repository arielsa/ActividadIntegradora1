using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadIntegradora1
{
    public class Auto
    {
        public Auto()
        {
            Persona dueño = new Persona();
        }
        public Auto(string patente, string marca, string modelo, string año, decimal precio) :this()
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;
        }
        public Auto( Auto pAuto) : this (pAuto.Patente, pAuto.Marca, pAuto.Modelo, pAuto.Año, pAuto.Precio) { }

        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public decimal Precio { get; set; }


    }
}
