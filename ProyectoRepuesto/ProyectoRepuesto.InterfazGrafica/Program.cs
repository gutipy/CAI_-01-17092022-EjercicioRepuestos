using ProyectoRepuesto.Dominio;
using ProyectoRepuesto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRepuesto.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            bool _consolaActiva = true;
            string _opcionMenu = "";

            Categoria C1 = new Categoria(01, "Almacenamiento");

            Categoria C2 = new Categoria(02, "Tarjeta Gráfica");

            Categoria C3 = new Categoria(03, "Fuente de alimentación eléctrica");

            Repuesto R1 = new Repuesto("Disco duro 500 GB", 8000, 10, C1);

            Repuesto R2 = new Repuesto("Nvidia GTX 3080", 200000, 5, C2);

            Repuesto R3 = new Repuesto("Fuente GIGABYTE 700w 80 plus", 15000, 20, C3);

            VentaRepuestos gestorRepuestos = new VentaRepuestos("Hardware San Isidro", "Avenida Centenario 100");

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    OpcionesMenu();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    FuncionValidacionOpcion(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Listar repuestos del negocio por categoría
                            Listar(tableroElectronico, _estado);
                            break;
                        case "2":
                            //Cambio el estado a una tarea del tablero
                            Cambiar(tableroElectronico);
                            break;
                        case "3":
                            //Agrego una tarea al tablero
                            Agregar(tableroElectronico);
                            break;
                        case "4":
                            //Salir del programa
                            Salir();
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void OpcionesMenu()
        {
            Console.WriteLine(
                "Bienvenido al gestor de repuestos! Seleccione una opción:" + Environment.NewLine +
                "1 - Listar repuestos por categoría" + Environment.NewLine +
                "2 - Agregar un repuesto" + Environment.NewLine +
                "3 - Eliminar un repuesto" + Environment.NewLine +
                "4 - Modificar precio de un repuesto" + Environment.NewLine +
                "5 - Agregar stock a un repuesto" + Environment.NewLine +
                "6 - Eliminar stock a un repuesto" + Environment.NewLine +
                "7 - Salir"
                )
                ;
        }

        public static void Listar(VentaRepuestos gestorRepuestos, int codigoCategoria)
        {
            //Declaración de variables
            string _codigoCategoria;
            int _codigoCategoriaValidado = 0;
            bool flag;

            do
            {
                Console.WriteLine("Ingrese el código de la categoría por el cual desea listar los repuestos");
                _codigoCategoria = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoCategoria, ref _codigoCategoriaValidado);

            }while (flag == false);

            Categoria C = new Categoria(_codigoCategoriaValidado);

            gestorRepuestos.TraerPorCategoria(C);
        }

        //Funciones que validan los inputs requeridos al usuario
        public static string FuncionValidacionOpcion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6" || opcion == "7")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                if (!int.TryParse(codigo, out codigoValidado))
                {
                    Console.WriteLine("El código ingresado debe ser de tipo numérico, intente nuevamente.");
                }
                else if (codigoValidado <= 0)
                {
                    Console.WriteLine("El código ingresado debe ser mayor a cero, intente nuevamente");
                }
                else
                {
                    flag = true;
                }
            } while (flag == false);

            return flag;
        }
        }
    }
}
