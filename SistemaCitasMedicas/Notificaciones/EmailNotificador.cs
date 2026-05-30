using SistemaCitasMedicas.Interfaces;
using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Notificaciones
{
    public class EmailNotificador : INotificador
    { 
        public void Enviar(string mensaje, Persona persona) 
        { 
            Console.WriteLine($"EMAIL enviado a {persona.Email}"); 
            Console.WriteLine(mensaje); 
        } 
    }
}
