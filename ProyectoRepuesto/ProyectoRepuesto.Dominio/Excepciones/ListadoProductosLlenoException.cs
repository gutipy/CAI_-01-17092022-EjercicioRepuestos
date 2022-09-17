using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio.Excepciones
{
    public class ListadoProductosLlenoException : Exception
    {
        public ListadoProductosLlenoException() : base("ERROR! El listado de productos se encuentra lleno, por favor intente elimine un producto e intente nuevamente.") { }
    }
}
