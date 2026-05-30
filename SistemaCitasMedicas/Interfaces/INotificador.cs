using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Interfaces
{
    public interface INotificador 
    { 
        void Enviar(string mensaje, Persona persona); 
    }
}
