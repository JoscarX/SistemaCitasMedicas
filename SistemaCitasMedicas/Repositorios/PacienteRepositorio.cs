using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Repositorios
{
    public class PacienteRepository 
    { 
        private List<Paciente> pacientes = new List<Paciente>(); 
        public void Agregar(Paciente paciente) 
        { 
            pacientes.Add(paciente); 
        } 
        public List<Paciente> ObtenerTodos() 
        { 
            return pacientes; 
        } 
        public Paciente ObtenerPorId(int id) 
        { 
            return pacientes.FirstOrDefault(x => x.Id == id); 
        } 
    }
}
