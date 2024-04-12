using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Persona
    {
        public int ID { get; set;}
        public string DNI { get; set; } = "";
        public string Nombre { get; set; } = "";

        public string Apellido { get; set; } = "";
        public string CUIL { get; set; }
        public int Edad { get; set; } = 0;

        public DateTime FechaNac { get; set; } = DateTime.Today;

        public void Agregar(string aDNI, string aNombre, string aApellido,
                            string aCUIL, int aEdad, DateTime aFechaNac)
        {
            DNI = aDNI;
            Nombre = aNombre;
            Apellido = aApellido;
            CUIL = aCUIL;
            Edad = aEdad;
            FechaNac = aFechaNac;
        }
    }
}
