using ProyectoRepuesto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.Dominio
{
    public class Repuesto
    {
        //Atributos
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;

        //Constructor
        public Repuesto(string nombre, double precio, int stock, Categoria categoria)
        {
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
            _categoria = categoria;
        }

        //Propiedades
        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; }
        public double Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public Categoria Categoria { get => _categoria; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4}",
                _codigo,
                _nombre,
                _precio,
                _stock,
                _categoria
                )
                ;
        }
    }
}
