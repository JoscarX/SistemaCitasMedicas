using SistemaCitasMedicas.Interfaces;
using SistemaCitasMedicas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Servicios
{
    public class RecordatorioService 
    { 
        private readonly INotificador notificador; 
        public RecordatorioService(INotificador notificador) 
        { 
            this.notificador = notificador;
        } 
        public void EnviarRecordatorio(CitaMedica cita)
        { 
            string mensaje = $"Recordatorio: Tiene una cita el {cita.Fecha}";
            notificador.Enviar(mensaje, cita.Paciente);
        } 
    }
}
