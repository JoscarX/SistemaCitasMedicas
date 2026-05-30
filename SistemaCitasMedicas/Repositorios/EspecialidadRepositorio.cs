using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Repositorios
{
    public class EspecialidadRepository 
    { 
        private List<Especialidad> especialidades = new List<Especialidad>(); 
        public void Agregar(Especialidad especialidad) 
        { 
            especialidades.Add(especialidad);
        }
        public List<Especialidad> ObtenerTodas() 
        {
            return especialidades;
        }
        public Especialidad ObtenerPorId(int id) 
        {
            return especialidades.FirstOrDefault(x => x.Id == id); 
        }
    }
}
