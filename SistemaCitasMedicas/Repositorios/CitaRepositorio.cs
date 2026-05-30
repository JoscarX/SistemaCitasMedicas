using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Repositorios
{
    public class CitaRepository 
    {
        private List<CitaMedica> citas = new List<CitaMedica>(); 
        public void Agregar(CitaMedica cita) 
        { 
            citas.Add(cita);
        } 
        public List<CitaMedica> ObtenerTodas() 
        {
            return citas; 
        }
        public CitaMedica ObtenerPorId(int id) 
        { 
            return citas.FirstOrDefault(x => x.Id == id); 
        } 
    }
}
