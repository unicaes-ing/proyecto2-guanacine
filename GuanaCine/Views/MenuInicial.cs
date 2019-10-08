using GuanaCine.Controllers;
using GuanaCine.Utils;
using System;

namespace GuanaCine.Views
{
    public class MenuInicial : Validaciones
    {
        public MenuInicial(PeliculasController peliculas)
        {
            CompraBoleto compraBoleto = new CompraBoleto(peliculas);
            Estadisticas estadisticas = new Estadisticas(peliculas);
            Configuraciones configuraciones = new Configuraciones(peliculas);

            Validar("Seleccione una opción\n[1] Venta de boletos\n[2] Estadísticas\n[3] Configuración\n[4] Salir", out int opc, "Menu");

            switch (opc)
            {
                case 1: compraBoleto.ComprarBoleto(); break;
                case 2: estadisticas.MenuEstadisticas(); break;
                case 3: configuraciones.Configuracion(); break;
                case 4: Environment.Exit(-1); break;
            }
        }
    }
}
