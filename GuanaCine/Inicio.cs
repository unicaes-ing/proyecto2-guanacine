using GuanaCine.Controllers;
using GuanaCine.Views;
using System;

namespace GuanaCine
{
    class Inicio
    {
        static void Main(string[] args)
        {
            PeliculasController peliculas = new PeliculasController();
            MenuInicial menuInicial = new MenuInicial(peliculas);


            Console.ReadKey();
        }
    }
}
