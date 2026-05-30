using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Repositorios
{
    public class MedicoRepository 
    {
        private List<Medico> medicos = new List<Medico>();
        public void Agregar(Medico medico) 
        { 
            medicos.Add(medico); 
        } 
        public List<Medico> ObtenerTodos() 
        { 
            return medicos; 
        } 
        public Medico ObtenerPorId(int id)
        { 
            return medicos.FirstOrDefault(x => x.Id == id);
        } 
    }
}
