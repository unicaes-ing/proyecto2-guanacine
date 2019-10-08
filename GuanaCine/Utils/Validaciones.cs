using GuanaCine.Models;
using System;
using System.Drawing;

namespace GuanaCine.Utils
{
    public class Validaciones
    {
        public static void Validar(string mensaje, out int num)
        {
            bool isNumber;
            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                isNumber = int.TryParse(Console.ReadLine(), out num);
                if (isNumber == false || num < 0)
                {
                    Console.WriteLine("Valor no válido. Intentelo nuevamente.");
                    Console.ReadKey();
                }
            } while (isNumber == false || num < 0);
        }

        public static void Validar(string mensaje, out int num, string encabezado)
        {
            bool isNumber;
            do
            {
                Console.Clear();
                Colorful.Console.WriteAscii(encabezado);
                Console.WriteLine(mensaje);
                isNumber = int.TryParse(Console.ReadLine(), out num);
                if (isNumber == false || num < 0)
                {
                    Console.WriteLine("Valor no válido. Intentelo nuevamente.");
                    Console.ReadKey();
                }
            } while (isNumber == false || num < 0);
        }

        public static void ValidarBoleto(string mensaje, out int num, Pelicula pelicula)
        {
            bool isNumber;
            do
            {
                Console.Clear();
                Colorful.Console.WriteAscii(pelicula.Nombre, ColorTranslator.FromHtml("#e91e63"));
                Console.WriteLine("Sinopsis: ");
                Console.WriteLine(pelicula.Sinopsis);
                Console.WriteLine("\n\n");
                Console.WriteLine("Adultos: $4.25 Adulto mayor: $3.25 Niños: $2.25");
                Console.WriteLine(mensaje);
                isNumber = int.TryParse(Console.ReadLine(), out num);
                if (isNumber == false || num < 0)
                {
                    Console.WriteLine("Valor no válido. Intentelo nuevamente.");
                    Console.ReadKey();
                }
            } while (isNumber == false || num < 0);
        }

        public bool ValidarDisponibilidad(bool[,] asientos, string asiento)
        {
            int dif, numAsiento = 0, numAsiento2 = 0;
            bool isNumber;

            if (string.IsNullOrEmpty(asiento)) asiento = "0";

            if (asiento.Length == 1)
            {
                return false;
            }

            if ((int)asiento[0] < 65 || (int)asiento[0] > 74)
            {
                return false;
            }

            if (asiento.Length >= 2)
            {
                isNumber = int.TryParse(asiento[1].ToString(), out numAsiento);
                if (!isNumber) return false;
                if (numAsiento < 1 || numAsiento > 9) return false;
            }

            if (asiento.Length >= 3)
            {
                isNumber = int.TryParse(asiento[2].ToString(), out numAsiento2);
                if (!isNumber) return false;

                if (asiento[1] != '1' || asiento[2] != '0')
                {
                    return false;
                }
            }

            dif = 0;
            for (int j = 65; j <= 74; j++)
            {
                if (asiento[0] == (char)j)
                {
                    if (asiento.Length == 3 && asiento[1] == '1' && asiento[2] == '0')
                    {
                        if (asientos[dif, 9] == true)
                        {
                            return false;
                        }
                        return true;
                    }

                    if (asientos[dif, byte.Parse(asiento[1].ToString()) - 1] == true)
                    {
                        return false;
                    }
                }
                dif++;
            }

            return true;
        }
    }
}
