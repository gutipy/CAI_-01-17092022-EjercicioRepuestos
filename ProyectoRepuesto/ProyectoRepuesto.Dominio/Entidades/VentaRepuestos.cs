using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProyectoRepuesto.Dominio.Excepciones;

namespace ProyectoRepuesto.Dominio.Entidades
{
    public class VentaRepuestos
    {
        //Atributos
        private List<Repuesto> _listaRepuestos;
        private string _nombreComercio;
        private string _direccion;

        //Constructor
        public VentaRepuestos(string nombreComercio, string direccion)
        {
            _listaRepuestos = new List<Repuesto>();
            _nombreComercio = nombreComercio;
            _direccion = direccion;
        }

        //Propiedades
        public List<Repuesto> ListaRepuestos { get => _listaRepuestos; }
        public string NombreComercio { get => _nombreComercio; }
        public string Direccion { get => _direccion; }

        //Método para agregar un repuesto
        public void AgregarRepuesto(Repuesto r)
        {
            //Asignación del código de tarea de manera incremental
            r.Codigo = _listaRepuestos.Count + 1;

            //Regla de negocio que valida que el listado de productos no se exceda de los 1000 productos sino tira excepción
            if (_listaRepuestos.Count > 1000)
            {
                throw new ListadoProductosLlenoException();
            }
            else
            {
                _listaRepuestos.Add(r);
            }
        }

        //Método para quitar un repuesto de la lista mediante su código
        public void QuitarRepuesto(int codigoRepuesto)
        {
            //Declaración de variables
            Repuesto r = null;

            //Si no encuentra el código ingresado por el usuario tira excepción
            if (_listaRepuestos.Find(R => R.Codigo == codigoRepuesto) == null)
            {
                throw new CodigoRepuestoNoExisteException(codigoRepuesto);
            }

            //Si el repuesto todavía tiene stock no se puede eliminar, por ende tira excepción
            else if (r.Stock > 0)
            {
                throw new NoSePuedeBorrarPorStockException(codigoRepuesto);
            }
            else
            {
                _listaRepuestos.RemoveAll(R => R.Codigo == codigoRepuesto);
            }
        }

        //Método para modificar el precio de un repuesto a través de su código
        public void ModificarPrecio(int codigoRepuesto, double precioRepuesto)
        {
            if (_listaRepuestos.Find(R => R.Codigo == codigoRepuesto) == null)
            {
                throw new CodigoRepuestoNoExisteException(codigoRepuesto);
            }
            else
            {
                foreach(Repuesto r in _listaRepuestos)
                {
                    if (r.Codigo == codigoRepuesto)
                    {
                        r.Precio = precioRepuesto;
                    }
                }
            }
        }

        //Método para agregar stock a un repuesto a través de su código
        public void AgregarStock(int codigoRepuesto, int stockRepuesto)
        {
            if (_listaRepuestos.Find(R => R.Codigo == codigoRepuesto) == null)
            {
                throw new CodigoRepuestoNoExisteException(codigoRepuesto);
            }
            else
            {
                foreach (Repuesto r in _listaRepuestos)
                {
                    if (r.Codigo == codigoRepuesto)
                    {
                        r.Stock = stockRepuesto;
                    }
                }
            }
        }

        public void QuitarStock(int codigoRepuesto, int stockRepuesto)
        {
            if (_listaRepuestos.Find(R => R.Codigo == codigoRepuesto) == null)
            {
                throw new CodigoRepuestoNoExisteException(codigoRepuesto);
            }
            else
            {
                foreach (Repuesto r in _listaRepuestos)
                {
                    if (r.Codigo == codigoRepuesto)
                    {
                        r.Stock = stockRepuesto;
                    }
                }
            }
        }

        public List<Repuesto> TraerPorCategoria(Categoria C)
        {
            //Declaración de lista
            List<Repuesto> _listaRepuestos = new List<Repuesto>();

            foreach (Repuesto r in _listaRepuestos)
            {
                if (r.Categoria == C)
                {
                    _listaRepuestos.Add(r);
                }
            }

            if (_listaRepuestos.Count == 0)
            {
                throw new CategoriaRepuestoInvalidaException(C);
            }

            return _listaRepuestos;
        }
    }
}
