using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio.Excepciones
{
    public class NoSePuedeBorrarPorStockException : Exception
    {
        public NoSePuedeBorrarPorStockException(int codigo) : base("ERROR! El repuesto con código " + codigo + " no se puede borrar porqué posee stock.") { }
    }
}
