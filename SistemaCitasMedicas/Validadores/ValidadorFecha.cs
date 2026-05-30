using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas.Validadores
{
    public static class ValidadorFecha 
    { 
        public static bool FechaEsValida(DateTime fecha)
        { 
            return fecha >= DateTime.Now; 
        } 
    } 
}
