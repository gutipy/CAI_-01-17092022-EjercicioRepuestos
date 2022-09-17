using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio.Excepciones
{
    public class CodigoRepuestoNoExisteException : Exception
    {
        public CodigoRepuestoNoExisteException(int codigo) : base("ERROR! El codigo " + codigo + " no corresponde a un repuesto, por favor ingrese un código de repuesto existente e intente nuevamente.") { }
    }
}
