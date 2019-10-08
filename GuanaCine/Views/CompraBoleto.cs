using GuanaCine.Controllers;
using GuanaCine.Models;
using GuanaCine.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuanaCine.Views
{
    class CompraBoleto : Validaciones
    {
        #region Atributos
        private bool isNumber;
        private int _horario;
        private double _pagoTotal;
        private int _totalBoletos;
        private PeliculasController _peliculas;
        private Pelicula _peliculaSeleccionada;
        #endregion

        #region Constructor
        public CompraBoleto(PeliculasController peliculas)
        {
            this._peliculas = peliculas;
        }
        #endregion

        #region Metodos
        public void ComprarBoleto()
        {
            int opc;
            do
            {
                Console.Clear();
                _peliculas.ImprimirCartelera();
                Console.SetCursorPosition(0, 21);
                Colorful.Console.Write("Seleccione el número de la sala", Color.AliceBlue);
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

            int boletosAdulto, boletosAdulMayor, boletoNino;

            do
            {
                ValidarBoleto("Ingrese la cantidad de boletos para adulto: ", out boletosAdulto, _peliculaSeleccionada);
                ValidarBoleto("Ingrese la cantidad de boletos para adulto mayor: ", out boletosAdulMayor, _peliculaSeleccionada);
                ValidarBoleto("Ingrese la cantidad de boletos para niño: ", out boletoNino, _peliculaSeleccionada);
            } while ((boletosAdulto + boletosAdulMayor + boletoNino) <= 0);

            _pagoTotal = (boletosAdulto * 4.25) + (boletosAdulMayor * 3.25) + (boletoNino * 2.25);
            _totalBoletos = boletosAdulto + boletosAdulMayor + boletoNino;
            
            _peliculaSeleccionada.CantidadBoletos[_horario][0] += boletosAdulto;
            _peliculaSeleccionada.CantidadBoletos[_horario][1] += boletosAdulMayor;
            _peliculaSeleccionada.CantidadBoletos[_horario][2] += boletoNino;

            _peliculaSeleccionada.Ingresos[_horario] += _pagoTotal;

            SelecAsientos(_totalBoletos);
        }

        private void SelecAsientos(int boletos)
        {
            bool[,] asientos = _peliculaSeleccionada.Butacas[_horario];

            string asiento;
            bool isValid;
            int dif;

            for (int i = 1; i <= boletos; i++)
            {
                do
                {
                    Console.Clear();
                    Colorful.Console.WriteAscii("Sala " + _peliculaSeleccionada.Sala);
                    _peliculas.DibujarSala(_peliculaSeleccionada, _horario);

                    Console.SetCursorPosition(50, 12);
                    Colorful.Console.WriteLine(_peliculaSeleccionada.Nombre, Color.AliceBlue);
                    Console.SetCursorPosition(100, 4);
                    Console.WriteLine("Ingrese el boleto {0}", i);
                    Console.SetCursorPosition(100, 5);
                    asiento = Console.ReadLine().ToUpper();

                    isValid = ValidarDisponibilidad(asientos, asiento);
                } while (isValid == false);


                dif = 0;
                for (int j = 65; j <= 74; j++)
                {
                    if (asiento[0] == (char)j)
                    {
                        if (asiento.Length == 3 && asiento[1] == '1' && asiento[2] == '0')
                        {
                            asientos[dif, 9] = true;
                            break;
                        }
                        asientos[dif, byte.Parse(asiento[1].ToString()) - 1] = true;
                        break;
                    }
                    dif++;
                }
            }

            Console.Clear();
            Colorful.Console.WriteAscii("Sala " + _peliculaSeleccionada.Sala);
            _peliculas.DibujarSala(_peliculaSeleccionada, _horario);

            Console.SetCursorPosition(50, 12);
            Colorful.Console.WriteLine(_peliculaSeleccionada.Nombre, Color.AliceBlue);

            Console.ReadKey();

            ImprimirBoleto();
        }

        private void ImprimirBoleto()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                    │");
            Console.WriteLine("│  Pelicula:                                     Horario:            │");
            Console.WriteLine("│                                                                    │");
            Console.WriteLine("│                                                                    │");
            Console.WriteLine("│                          Boletos:                                  │");
            Console.WriteLine("│                                                                    │");
            Console.WriteLine("│  Adulto:               Adulto mayor:           Niños:              │");
            Console.WriteLine("│                                                                    │");
            Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│  Total a pagar:                                Sala:               │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────┘");

            Console.SetCursorPosition(13, 2);
            Colorful.Console.WriteLine(_peliculaSeleccionada.Nombre, ColorTranslator.FromHtml("#ffc107"));
            Console.SetCursorPosition(58, 2);
            Colorful.Console.WriteLine(_peliculaSeleccionada.Horarios[_horario], ColorTranslator.FromHtml("#ffc107"));

            Console.SetCursorPosition(11, 7);
            Colorful.Console.WriteLine(_peliculaSeleccionada.CantidadBoletos[_horario][0], ColorTranslator.FromHtml("#ffc107"));
            Console.SetCursorPosition(39, 7);
            Colorful.Console.WriteLine(_peliculaSeleccionada.CantidadBoletos[_horario][1], ColorTranslator.FromHtml("#ffc107"));
            Console.SetCursorPosition(56, 7);
            Colorful.Console.WriteLine(_peliculaSeleccionada.CantidadBoletos[_horario][2], ColorTranslator.FromHtml("#ffc107"));

            Console.SetCursorPosition(19, 10);
            Colorful.Console.WriteLine("{0:C2}", _pagoTotal, ColorTranslator.FromHtml("#ffc107"));

            Console.SetCursorPosition(55, 10);
            Colorful.Console.WriteLine(_peliculaSeleccionada.Sala, ColorTranslator.FromHtml("#ffc107"));

            Console.WriteLine();
            Colorful.Console.WriteAscii("Gracias por la compra");
            Console.ReadKey();

            MenuInicial menuInicial = new MenuInicial(_peliculas);
        }
        #endregion
    }
}
