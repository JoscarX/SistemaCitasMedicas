using SistemaCitasMedicas.Modelos;
using SistemaCitasMedicas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Servicios
{
    public class EspecialidadService 
    { 
        private readonly EspecialidadRepository repository;
        public EspecialidadService(EspecialidadRepository repository) 
        {
            this.repository = repository; 
        } 
        public void Registrar(Especialidad especialidad)
        {
            repository.Agregar(especialidad);
        } 
        public List<Especialidad> ObtenerTodas() 
        {
            return repository.ObtenerTodas(); 
        } 
    }
}
