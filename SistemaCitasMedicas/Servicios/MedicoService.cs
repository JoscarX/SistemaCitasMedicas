using SistemaCitasMedicas.Modelos;
using SistemaCitasMedicas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Servicios
{
    public class MedicoService 
    {
        private readonly MedicoRepository repository; 
        public MedicoService(MedicoRepository repository) 
        { 
            this.repository = repository; 
        } 
        public void Registrar(Medico medico) 
        { 
            repository.Agregar(medico);
        } 
        public List<Medico> ObtenerTodos()
        { 
            return repository.ObtenerTodos();
        }
    }
}
