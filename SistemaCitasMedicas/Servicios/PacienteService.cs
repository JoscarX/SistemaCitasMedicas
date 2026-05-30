using SistemaCitasMedicas.Modelos;
using SistemaCitasMedicas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Servicios
{
    public class PacienteService 
    { 
        private readonly PacienteRepository repository; 
        public PacienteService(PacienteRepository repository) 
        {
            this.repository = repository;
        } 
        public void Registrar(Paciente paciente) 
        {
            repository.Agregar(paciente); 
        }
        public List<Paciente> ObtenerTodos() 
        { 
            return repository.ObtenerTodos(); 
        } 
    }
}
