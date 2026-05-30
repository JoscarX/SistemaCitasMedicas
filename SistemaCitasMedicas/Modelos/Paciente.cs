using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Modelos
{
    public class Paciente : Persona 
    {
        public string Cedula { get; set; } 
        public override void MostrarInformacion() 
        { 
            Console.WriteLine($"Paciente: {Nombre}"); 
        } 
    }
}
