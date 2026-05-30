using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Modelos
{
    public class Medico : Persona 
    { 
        public Especialidad Especialidad { get; set; } 
        public override void MostrarInformacion() 
        { 
            Console.WriteLine($"Médico: {Nombre}"); 
        }
    }
}
