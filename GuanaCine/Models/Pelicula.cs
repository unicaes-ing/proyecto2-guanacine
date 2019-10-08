using System.Collections.Generic;

namespace GuanaCine.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public int Sala { get; set; }
        public string Sinopsis { get; set; }
        public List<string> Horarios { get; set; }
        public List<bool[,]> Butacas { get; set; }

        //Lista de los boletos vendidos por el tipo de persona
        //0 Adulto 1 Adulto mayor 2 nino
        public List<List<int>> CantidadBoletos { get; set; }
        public List<double> Ingresos { get; set; }
    }
}
