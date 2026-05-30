using SistemaCitasMedicas.Modelos;
using SistemaCitasMedicas.Repositorios;
using SistemaCitasMedicas.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Servicios
{
    public class CitaService
    { 
        private readonly CitaRepository repository; 
        public CitaService(CitaRepository repository) 
        { 
            this.repository = repository;
        } 
        public bool Agendar(CitaMedica cita)
        { 
            if (!ValidadorFecha.FechaEsValida(cita.Fecha)) 
            { 
                return false; 
            } 
            if (!ValidadorDisponibilidad.MedicoDisponible(repository.ObtenerTodas(), cita.Medico, cita.Fecha)) 
            {
                return false;
            } 
            repository.Agregar(cita); 
            return true; 
        } 
        public List<CitaMedica> ObtenerTodas() 
        { 
            return repository.ObtenerTodas(); 
        }
        public void Cancelar(int id)
        { 
            var cita = repository.ObtenerPorId(id); 
            if (cita != null) { cita.Cancelar(); 
            } 
        } 
        public void Reprogramar(int id, DateTime fecha) 
        { 
            var cita = repository.ObtenerPorId(id); 
            if (cita != null) { cita.Reprogramar(fecha); 
            } 
        }
    }
}
