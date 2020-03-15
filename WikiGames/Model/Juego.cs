using System;
namespace WikiGames.Model
{
    public class Juego
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Caratula { get; set; }
        public string Tipo { get; set; }
        public DateTimeOffset Flanzamiento { get; set; }
        public string Descripcion { get; set; }
        public string Media { get; set; }

    }

}
