using ProyectoRepuesto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio.Excepciones
{
    public class StockNegativoException : Exception
    {
        public StockNegativoException(int stock) : base("ERROR! el stock resultante es " + stock + " que es negativo, intente nuevamente.") { }
    }
}
