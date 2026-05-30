using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Modelos
{
    public abstract class Persona { 
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string Telefono { get; set; } 
        public string Email { get; set; } 
        public abstract void MostrarInformacion(); 
    }
}
