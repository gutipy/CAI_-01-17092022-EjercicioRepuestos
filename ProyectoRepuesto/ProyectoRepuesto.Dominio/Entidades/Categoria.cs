using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio.Entidades
{
    public class Categoria
    {
        //Atributos
        private int _codigo;
        private string _nombre;

        public Categoria(int codigoCategoriaValidado)
        {
            _codigo = codigoCategoriaValidado;
        }

        //Constructor
        public Categoria(int codigo, string nombre)
        {
            _codigo = codigo;
            _nombre = nombre;
        }

        //Propiedades
        public int Codigo { get => _codigo; }
        public string Nombre { get => _nombre; }
    }
}
