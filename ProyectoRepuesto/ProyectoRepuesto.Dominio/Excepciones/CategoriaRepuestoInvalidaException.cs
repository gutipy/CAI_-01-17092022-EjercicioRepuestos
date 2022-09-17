using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRepuesto.Dominio.Entidades;

namespace ProyectoRepuesto.Dominio.Excepciones
{
    public class CategoriaRepuestoInvalidaException : Exception
    {
        public CategoriaRepuestoInvalidaException(Categoria codigo) : base("ERROR! la categoria " + codigo + " no existe, intente nuevamente.") { }
    }
}
