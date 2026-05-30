using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Validadores
{
    public static class ValidadorDisponibilidad 
    {
        public static bool MedicoDisponible(List<CitaMedica> citas, Medico medico, DateTime fecha) 
        { 
            return !citas.Any(x => x.Medico.Id == medico.Id && x.Fecha == fecha && x.Estado != EstadoCita.Cancelada); 
        } 
    }
}
