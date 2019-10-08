using GuanaCine.Controllers;
using GuanaCine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuanaCine.Views
{
    public class Configuraciones
    {
        #region Atributos
        private bool isNumber;
        private int _horario;
        private PeliculasController _peliculas;
        private Pelicula _peliculaSeleccionada;
        #endregion

        #region Constructor
        public Configuraciones(PeliculasController peliculas)
        {
            _peliculas = peliculas;
        }
        #endregion

        #region Metodos
        public void Configuracion()
        {
            int opc;
            do
            {
                Console.Clear();
                _peliculas.ImprimirCartelera();

                Console.SetCursorPosition(0, 0);
                Colorful.Console.WriteAscii("Configuraciones");

                Console.SetCursorPosition(0, 18);
                Console.WriteLine("           ");
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("Selecciona una película para reiniciar            ");

                Console.SetCursorPosition(0, 22);
                isNumber = int.TryParse(Console.ReadLine(), out opc);
                _peliculaSeleccionada = _peliculas.ListaPeliculas.Find(pelicula => pelicula.IdPelicula == opc);
            } while (isNumber == false || _peliculaSeleccionada == null);

            do
            {
                Console.Clear();
                Colorful.Console.WriteAscii(_peliculaSeleccionada.Nombre, ColorTranslator.FromHtml("#e91e63"));
                Console.WriteLine("Sinopsis: ");
                Console.WriteLine(_peliculaSeleccionada.Sinopsis);
                Console.WriteLine("\n\n");
                Console.WriteLine("Seleccione un horario:");

                int i = 1;
                foreach (var item in _peliculaSeleccionada.Horarios)
                {
                    Colorful.Console.WriteLine("[" + i++ + "] " + item);
                }

                isNumber = int.TryParse(Console.ReadLine(), out opc);
                opc--;
            } while (isNumber == false || opc < 0 || opc >= 3);

            _horario = opc;

            _peliculaSeleccionada.Butacas[_horario] = new bool[10, 10];
            _peliculaSeleccionada.CantidadBoletos[_horario] = new List<int> { 0, 0, 0 };
            _peliculaSeleccionada.Ingresos[_horario] = 0.0;

            Console.WriteLine("Butaca reestablecida!");

            Console.ReadKey();
            MenuInicial menuInicial = new MenuInicial(_peliculas);
        }
        #endregion
    }
}
