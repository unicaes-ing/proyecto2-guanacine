using GuanaCine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuanaCine.Controllers
{
    public class PeliculasController
    {
        #region Atributos
        private Pelicula _pelicula;
        private List<Pelicula> _listaPeliculas;
        #endregion

        #region Propiedades
        public Pelicula Pelicula
        {
            get { return _pelicula; }
            set { _pelicula = value; }
        }
        public List<Pelicula> ListaPeliculas
        {
            get { return _listaPeliculas; }
            set { _listaPeliculas = value; }
        }
        #endregion

        #region Constructor
        public PeliculasController()
        {
            ListaPeliculas = new List<Pelicula>
            {
               new Pelicula
               {
                   IdPelicula = 1,
                   Nombre = "Eso Capitulo 2",
                   Sala = 1,
                   Horarios = new List<string> { "1:30pm", "3:30pm", "6:05pm" },
                   Butacas = new List<bool[,]> { new bool[10,10], new bool[10,10], new bool[10,10] },
                   CantidadBoletos = new List<List<int>>
                   {
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                   },
                   Ingresos = new List<double>{ 0.0, 0.0, 0.0},
                   Sinopsis = "El mal resurgirá en Derry cuando el director Andy Muschietti reúna al \nClub de los Perdedores —jóvenes y adultos— en el lugar donde todo \ncomenzó para IT: Capítulo 2. El filme es la secuela de la cinta de \nMuschietti IT: Eso (2017) aclamada por la crítica y con un éxito en taquillas \nque reunió más de 700 millones de dólares en todo el mundo."
               },
               //
               new Pelicula {
                   IdPelicula = 2,
                   Nombre = "Agente bajo fuego",
                   Sala = 2,
                   Horarios = new List<string> { "4:35pm", "7:15pm", "9:50pm" },
                   Butacas = new List<bool[,]> { new bool[10,10], new bool[10,10], new bool[10,10] },
                   CantidadBoletos = new List<List<int>>
                   {
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                   },
                   Ingresos = new List<double>{ 0.0, 0.0, 0.0},
                   Sinopsis = "Después de un intento de asesinato en contra del presidente de los \nEstados Unidos, Allan Trumbull (Morgan Freeman), el agente Mike \nBanning (Gerard Butler) es acusado injustamente. Perseguido por el FBI, \ndeberá encontrar la verdadera amenaza para el Presidente, limpiar su \nnombre y salvar a su país de un peligro inminente."
               },
               //
               new Pelicula {
                   IdPelicula = 3,
                   Nombre = "Angry birds 2",
                   Sala = 3,
                   Horarios = new List<string> { "1:15pm", "3:30pm", "5:35pm" },
                   Butacas = new List<bool[,]> { new bool[10,10], new bool[10,10], new bool[10,10] },
                   CantidadBoletos = new List<List<int>>
                   {
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                   },
                   Ingresos = new List<double>{ 0.0, 0.0, 0.0},
                   Sinopsis = "Secuela de la película 'Angry Birds' en la que Red, \nChuck, Bomb y el resto de sus amigos con plumas son \nabordados por un cerdo verde que les pide que se \nunan para luchar contra una amenaza común."
               },
               //
               new Pelicula {
                   IdPelicula = 4,
                   Nombre = "El rey leon",
                   Sala = 4,
                   Horarios = new List<string> { "10:00am", "2:30pm", "3:35pm" },
                   Butacas = new List<bool[,]> { new bool[10,10], new bool[10,10], new bool[10,10] },
                   CantidadBoletos = new List<List<int>>
                   {
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                       new List<int> { 0, 0, 0 },
                   },
                   Ingresos = new List<double>{ 0.0, 0.0, 0.0},
                   Sinopsis = "Tras el asesinato de su padre, Simba, un joven león \nes apartado su reino y tendrá que descubrir con \nayuda de amigos de la sabana africana el significado \nde la responsabilidad y la valentía."
               }
            };
        }
        #endregion

        #region Metodos
        public void ImprimirCartelera()
        {
            DibujarPeliculas();
            foreach (var item in ListaPeliculas)
            {
                int left = 0, top = 0;
                if (item.Sala == 1)
                {
                    top = 7;
                    Console.SetCursorPosition(9, top);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                }
                else if(item.Sala == 2)
                {
                    left = 53;
                    top = 7;
                    Console.SetCursorPosition(62, top);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                }
                else if (item.Sala == 3)
                {
                    top = 12;
                    Console.SetCursorPosition(9, top);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                }
                else if (item.Sala == 4)
                {
                    left = 53;
                    top = 12;
                    Console.SetCursorPosition(62, top);
                    Colorful.Console.Write("{0}", item.Nombre, ColorTranslator.FromHtml("#ffc107"));
                }

                foreach (var horario in item.Horarios)
                {
                    Console.SetCursorPosition(left += 9, top+1);
                    Colorful.Console.Write("{0} | ", horario, ColorTranslator.FromHtml("#80cbc4"));
                }
            }
        }

        public void DibujarPeliculas()
        {
            Colorful.Console.WriteAscii("Cartelera", ColorTranslator.FromHtml("#b0bec5"));

            Console.WriteLine("╔═══════════════════════════════════════════════════╦═════════════════════════════════════════════════╗");
            Console.WriteLine("║  ╔═══╗                                            ║  ╔═══╗                                          ║");
            Console.WriteLine("║  ║ 1 ║                                            ║  ║ 2 ║                                          ║");
            Console.WriteLine("║  ╚═══╝                                            ║  ╚═══╝                                          ║");
            Console.WriteLine("║                                                   ║                                                 ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════╬═════════════════════════════════════════════════╣");
            Console.WriteLine("║  ╔═══╗                                            ║  ╔═══╗                                          ║");
            Console.WriteLine("║  ║ 3 ║                                            ║  ║ 4 ║                                          ║");
            Console.WriteLine("║  ╚═══╝                                            ║  ╚═══╝                                          ║");
            Console.WriteLine("║                                                   ║                                                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╩═════════════════════════════════════════════════╝");

            Console.WriteLine("");
            Console.WriteLine("Precios: ");
            Console.WriteLine("Adultos: $4.25 Adulto mayor: $3.25 Niños: $2.25");
        }

        public void DibujarSala(Pelicula peliculaSelec, int horario)
        {
            Console.WriteLine("     SALIDA                                                                                 ");
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    │    │               ┌─────────────────────────────────────────────────────────────┐  ║");
            Console.WriteLine("║    │    │               │░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║    └────┘               │░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         │░░░░░░░░░░░░░░                               ░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         │░░░░░░░░░░░░░░                               ░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         │░░░░░░░░░░░░░░                               ░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         │░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         │░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░│  ║");
            Console.WriteLine("║                         └─────────────────────────────────────────────────────────────┘  ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                            1     2     3     4     5     6     7     8     9    10       ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 A.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 B.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 C.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 D.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 E.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 F.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 G.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║                 H.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║                                                                                          ║");
            Console.WriteLine("║    ENTRADA      I.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║    ┌────┐                                                                                ║");
            Console.WriteLine("║    │    │       J.        ███   ███   ███   ███   ███   ███   ███   ███   ███   ███      ║");
            Console.WriteLine("║    │    │                                                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════╝");

            int x = 28, y = 22;
            bool[,] asientosDisp = peliculaSelec.Butacas[horario];

            for (int i = 0; i < asientosDisp.GetLength(0); i++)
            {
                for (int j = 0; j < asientosDisp.GetLength(1); j++)
                {
                    if (asientosDisp[i,j] == true)
                    {
                        Colorful.Console.ForegroundColor = ColorTranslator.FromHtml("#e53935");
                        Console.SetCursorPosition(x + (j * 6), y + (i * 2));
                        Console.WriteLine("███");
                    }
                    Console.SetCursorPosition(x + (j * 6), y + (i * 2));
                    Console.WriteLine("███");
                    Console.ResetColor();
                }
            }
        }
        #endregion
    }
}