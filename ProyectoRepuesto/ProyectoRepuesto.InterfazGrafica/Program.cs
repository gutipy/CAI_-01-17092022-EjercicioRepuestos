using ProyectoRepuesto.Dominio;
using ProyectoRepuesto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
                            Listar(gestorRepuestos);
                            break;
                        case "2":
                            //Agrego un repuesto al listado
                            AgregarR(gestorRepuestos);
                            break;
                        case "3":
                            //Elimino un repuesto del listado
                            Eliminar(gestorRepuestos);
                            break;
                        case "4":
                            //Modifico el precio de un repuesto
                            Modificar(gestorRepuestos);
                            break;
                        case "5":
                            //Agrego el stock de un repuesto
                            AgregarS(gestorRepuestos);
                            break;
                        case "6":
                            //Modifico el precio de un repuesto
                            QuitarS(gestorRepuestos);
                            break;
                        case "7":
                            //Salgo del programa
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

        public static void Listar(VentaRepuestos gestorRepuestos)
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

            Console.WriteLine(gestorRepuestos.TraerPorCategoria(C));
        }

        public static void AgregarR(VentaRepuestos gestorRepuestos)
        {
            //Declaración de variables
            string _nombreRepuesto;
            string _precioRepuesto;
            double _precioRepuestoValidado = 0;
            string _stockRepuesto;
            int _stockRepuestoValidado = 0;
            string _codigoCategoria;
            int _codigoCategoriaValidado = 0;
            string _nombreCategoria;
            bool flag;

            //Pido al usuario que ingrese los datos del repuesto y a la vez valido cada input ingresado
            do
            {
                Console.WriteLine("Ingrese el nombre del repuesto");
                _nombreRepuesto = Console.ReadLine();
                flag = FuncionValidacionCadena(ref _nombreRepuesto);

            }while(flag == false);

            do
            {
                Console.WriteLine("Ingrese el precio del repuesto");
                _precioRepuesto = Console.ReadLine();
                flag = FuncionValidacionPrecio(_precioRepuesto, ref _precioRepuestoValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese el stock del repuesto");
                _stockRepuesto = Console.ReadLine();
                flag = FuncionValidacionStock(_stockRepuesto, ref _stockRepuestoValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese el código de la categoría del repuesto");
                _codigoCategoria = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoCategoria, ref _codigoCategoriaValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese el nombre de la categoría del repuesto");
                _nombreCategoria = Console.ReadLine();
                flag = FuncionValidacionCadena(ref _nombreCategoria);

            } while (flag == false);

            //Instancio la clase Categoria y le asigno los valores ingresados por el usuario
            Categoria C = new Categoria(
                _codigoCategoriaValidado,
                _nombreCategoria
                )
                ;

            //Instancio la clase Repuesto y le asigno los valores ingresados por el usuario
            Repuesto R = new Repuesto(
                _nombreRepuesto,
                _precioRepuestoValidado,
                _stockRepuestoValidado,
                C
                )
                ;

            //Agrego el repuesto al gestor de repuestos
            gestorRepuestos.AgregarRepuesto(R);

            Console.WriteLine("El repuesto fue agregado exitosamente al gestor de repuestos, presione Enter para elegir otra opción.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Eliminar(VentaRepuestos gestorRepuestos)
        {
            //Declaración de variables
            string _codigoRepuesto;
            int _codigoRepuestoValidado = 0;
            bool flag;

            do
            {
                Console.WriteLine("Ingrese el código del repuesto que desea eliminar");
                _codigoRepuesto = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoRepuesto, ref _codigoRepuestoValidado);

            } while (flag == false);

            gestorRepuestos.QuitarRepuesto(_codigoRepuestoValidado);
        }

        public static void Modificar(VentaRepuestos gestorRepuestos)
        {
            //Declaración de variables
            string _codigoRepuesto;
            int _codigoRepuestoValidado = 0;
            string _precioRepuesto;
            double _precioRepuestoValidado = 0;
            bool flag;

            do
            {
                Console.WriteLine("Ingrese el código del repuesto que desea modificar el precio");
                _codigoRepuesto = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoRepuesto, ref _codigoRepuestoValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese el nuevo precio que desea colocarle al repuesto");
                _precioRepuesto = Console.ReadLine();
                flag = FuncionValidacionPrecio(_precioRepuesto, ref _precioRepuestoValidado);

            } while (flag == false);

            gestorRepuestos.ModificarPrecio(_codigoRepuestoValidado, _precioRepuestoValidado);
        }

        public static void AgregarS(VentaRepuestos gestorRepuestos)
        {
            //Declaración de variables
            string _codigoRepuesto;
            int _codigoRepuestoValidado = 0;
            string _stockRepuesto;
            int _stockRepuestoValidado = 0;
            bool flag;

            do
            {
                Console.WriteLine("Ingrese el código del repuesto que desea agregar el stock");
                _codigoRepuesto = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoRepuesto, ref _codigoRepuestoValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese la cantidad de stock que desea adicionarle al repuesto");
                _stockRepuesto = Console.ReadLine();
                flag = FuncionValidacionStock(_stockRepuesto, ref _stockRepuestoValidado);

            } while (flag == false);

            gestorRepuestos.AgregarStock(_codigoRepuestoValidado,_stockRepuestoValidado);
        }

        public static void QuitarS(VentaRepuestos gestorRepuestos)
        {
            //Declaración de variables
            string _codigoRepuesto;
            int _codigoRepuestoValidado = 0;
            string _stockRepuesto;
            int _stockRepuestoValidado = 0;
            bool flag;

            do
            {
                Console.WriteLine("Ingrese el código del repuesto que desea agregar el stock");
                _codigoRepuesto = Console.ReadLine();
                flag = FuncionValidacionCodigo(_codigoRepuesto, ref _codigoRepuestoValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese la cantidad de stock que desea quitarle al repuesto");
                _stockRepuesto = Console.ReadLine();
                flag = FuncionValidacionStock(_stockRepuesto, ref _stockRepuestoValidado);

            } while (flag == false);

            gestorRepuestos.QuitarStock(_codigoRepuestoValidado, _stockRepuestoValidado);
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido del gestor de repuestos, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
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

        public static bool FuncionValidacionCadena(ref string cadena)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! El valor ingresado no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionPrecio(string precio, ref double precioValidado)
        {
            //Declaración de variables
            bool flag = false;

            if (!Double.TryParse(precio, out precioValidado))
            {
                Console.WriteLine("ERROR! El precio ingresado tiene que ser de tipo numérico, intente nuevamente.");
            }
            else if (precioValidado <= 0)
            {
                Console.WriteLine("ERROR! El precio ingresado tiene que ser mayor a cero, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionStock(string stock, ref int stockValidado)
        {
            //Declaración de variables
            bool flag = false;

            if (!int.TryParse(stock, out stockValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo numérico, intente nuevamente.");
            }
            else if (stockValidado <= 0)
            {
                Console.WriteLine("ERROR! El stock ingresado tiene que ser mayor a cero, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}
