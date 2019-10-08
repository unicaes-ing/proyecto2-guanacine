using GuanaCine.Controllers;
using GuanaCine.Utils;
using System;
using System.Drawing;

namespace GuanaCine.Views
{
    public class Estadisticas : Validaciones
    {
        #region Atributos
        PeliculasController _peliculas;
        EstadisticasController _estadisticas;
        #endregion

        #region Constructor
        public Estadisticas(PeliculasController peliculas)
        {
            _peliculas = peliculas;
            _estadisticas = new EstadisticasController();
        }
        #endregion

        #region Metodos
        public void MenuEstadisticas()
        {
            Console.Clear();

            Validar("Seleccione una opción\n[1] Boletos vendidos\n[2] Ingresos por función\n[3] Total de ingresos\n[4] Regresar", out int opc, "Estadisticas");

            switch (opc)
            {
                case 1: BoletosVendidos(); break;
                case 2: TotalIngresos(); break;
                case 3: IngresosGlobales(); break;
                case 4: MenuInicial menuInicial = new MenuInicial(_peliculas); break;
                default:
                    break;
            }

            MenuEstadisticas();
        }

        private void IngresosGlobales()
        {
            double globales = 0.0;

            foreach (var item in _peliculas.ListaPeliculas)
            {
                foreach (var ingreso in item.Ingresos)
                {
                    globales += ingreso;
                }
            }
            Console.Clear();
            Colorful.Console.WriteAscii("Ingresos globales");
            Console.WriteLine("Ingresos totales: {0:C2}", globales);
            Console.ReadKey();
        }

        private void TotalIngresos()
        {
            _estadisticas.DibujarTabla2();
            foreach (var item in _peliculas.ListaPeliculas)
            {
                if (item.Sala == 1)
                {
                    Console.SetCursorPosition(9, 8);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarIngresos(0, 10, item);
                }
                else if (item.Sala == 2)
                {
                    Console.SetCursorPosition(63, 8);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarIngresos(54, 10, item);
                }
                else if (item.Sala == 3)
                {
                    Console.SetCursorPosition(9, 23);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarIngresos(0, 25, item);
                }
                else if (item.Sala == 4)
                {
                    Console.SetCursorPosition(63, 23);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarIngresos(54, 25, item);
                }
            }

            Console.ReadKey();
        }

        private void BoletosVendidos()
        {
            _estadisticas.DibujarTabla();
            foreach (var item in _peliculas.ListaPeliculas)
            {
                if (item.Sala == 1)
                {
                    Console.SetCursorPosition(9, 8);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarBoletos(0, 12, item);
                }
                else if (item.Sala == 2)
                {
                    Console.SetCursorPosition(63, 8);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarBoletos(54, 12, item);
                }
                else if (item.Sala == 3)
                {
                    Console.SetCursorPosition(9, 25);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarBoletos(0, 29, item);
                }
                else if (item.Sala == 4)
                {
                    Console.SetCursorPosition(63, 25);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                    _estadisticas.PintarBoletos(54, 29, item);
                }
            }
           
            Console.ReadKey();
        }

        
        #endregion
    }
}
