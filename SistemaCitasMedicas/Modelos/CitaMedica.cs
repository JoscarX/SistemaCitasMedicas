using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Modelos
{
    public class CitaMedica 
    { 
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoCita Estado { get; set; }
        public void Cancelar() 
        {
            Estado = EstadoCita.Cancelada; 
        } 
        public void Reprogramar(DateTime nuevaFecha) 
        { 
            Fecha = nuevaFecha; 
            Estado = EstadoCita.Reprogramada;
        }
    }
}
