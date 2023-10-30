using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioKiosco
{
    public class Usuario
    {
        private string Nombre;

        private int Edad;
        public Usuario() { }

        public Usuario(string nombre, int edad)
        {
            Nombre1 = nombre;
            Edad1 = edad;
        }

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
    }
}
