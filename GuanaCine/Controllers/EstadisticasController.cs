using GuanaCine.Models;
using System;
using System.Drawing;

namespace GuanaCine.Controllers
{
    public class EstadisticasController
    {
        #region Metodos
        public void PintarBoletos(int left, int top, Pelicula item)
        {
            int steep = left;
            int totalBoletos = 0;

            for (int i = 0; i < 3; i++)
            {
                top += 2;
                left = steep;
                for (int j = 0; j < 3; j++)
                {
                    left += 16;
                    if (item.CantidadBoletos[i][j] < 10)
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("0" + item.CantidadBoletos[i][j]);
                        totalBoletos += item.CantidadBoletos[i][j];
                    }
                }
            }
            Console.SetCursorPosition(steep + 10, top + 3);
            Console.WriteLine("{0}", totalBoletos);
        }

        public void DibujarTabla()
        {
            Console.Clear();
            Colorful.Console.WriteAscii("Estadisticas", ColorTranslator.FromHtml("#b0bec5"));

            Console.WriteLine("╔═════════════════════════════════════════════════════╦═════════════════════════════════════════════════════╗");
            Console.WriteLine("║  ╔═══╗                                              ║  ╔═══╗                                              ║");
            Console.WriteLine("║  ║ 1 ║                                              ║  ║ 2 ║                                              ║");
            Console.WriteLine("║  ╚═══╝                                              ║  ╚═══╝                                              ║");
            Console.WriteLine("║                Boletos vendidos                     ║                Boletos vendidos                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║             Adultos       Adulto mayor       Niños  ║             Adultos       Adulto mayor       Niños  ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  1:30pm       20              02              03    ║  4:35pm       20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  3:30pm       20              02              03    ║  7:15pm       20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  6:05pm       20              02              03    ║  9:50pm       20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  Total:                                             ║  Total:                                             ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╬═════════════════════════════════════════════════════╣");
            Console.WriteLine("║  ╔═══╗                                              ║  ╔═══╗                                              ║");
            Console.WriteLine("║  ║ 3 ║                                              ║  ║ 4 ║                                              ║");
            Console.WriteLine("║  ╚═══╝                                              ║  ╚═══╝                                              ║");
            Console.WriteLine("║                Boletos vendidos                     ║                Boletos vendidos                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║             Adultos       Adulto mayor       Niños  ║             Adultos       Adulto mayor       Niños  ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  1:15pm       20              02              03    ║  10:00am      20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  3:30pm       20              02              03    ║  2:30pm       20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  5:35pm       20              02              03    ║  3:35pm       20              02              03    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  Total:                                             ║  Total:                                             ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════╩═════════════════════════════════════════════════════╝");

            Console.WriteLine();
            Console.WriteLine("Preciona cualquier tecla para regresar..");
        }

        public void PintarIngresos(int left, int top, Pelicula item)
        {
            left += 16;
            double totalIngresos = 0;

            foreach (var ingresos in item.Ingresos)
            {
                top += 2;
                Console.SetCursorPosition(left, top);
                Console.WriteLine("{0:C2}", ingresos);
                totalIngresos += ingresos;
            }
            Console.SetCursorPosition(left - 6, top + 3);
            Console.WriteLine("{0:C2}", totalIngresos);
        }

        public void DibujarTabla2()
        {
            Console.Clear();
            Colorful.Console.WriteAscii("Estadisticas", ColorTranslator.FromHtml("#b0bec5"));

            Console.WriteLine("╔═════════════════════════════════════════════════════╦═════════════════════════════════════════════════════╗");
            Console.WriteLine("║  ╔═══╗                                              ║  ╔═══╗                                              ║");
            Console.WriteLine("║  ║ 1 ║                                              ║  ║ 2 ║                                              ║");
            Console.WriteLine("║  ╚═══╝                                              ║  ╚═══╝                                              ║");
            Console.WriteLine("║                Ingresos por función                 ║                Ingresos por función                 ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  1:30pm       20                                    ║  4:35pm       20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  3:30pm       20                                    ║  7:15pm       20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  6:05pm       20                                    ║  9:50pm       20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  Total:                                             ║  Total:                                             ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════╬═════════════════════════════════════════════════════╣");
            Console.WriteLine("║  ╔═══╗                                              ║  ╔═══╗                                              ║");
            Console.WriteLine("║  ║ 3 ║                                              ║  ║ 4 ║                                              ║");
            Console.WriteLine("║  ╚═══╝                                              ║  ╚═══╝                                              ║");
            Console.WriteLine("║                Ingresos por función                 ║                Ingresos por función                 ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  1:15pm       20                                    ║  10:00am      20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  3:30pm       20                                    ║  2:30pm       20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  5:35pm       20                                    ║  3:35pm       20                                    ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("║  Total:                                             ║  Total:                                             ║");
            Console.WriteLine("║                                                     ║                                                     ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════╩═════════════════════════════════════════════════════╝");

            Console.WriteLine();
            Console.WriteLine("Preciona cualquier tecla para regresar..");
        }
        #endregion
    }
}
