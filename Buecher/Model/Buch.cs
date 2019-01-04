using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Model
{
    public class Buch 
    {
        public string Titel { get; set; }
        public Autor Autor { get; set; }
        public Genre Genre { get; set; }
        public Ort Ort { get; set; }
        public string Kommentar { get; set; }

        public Buch(string titel, Autor autor, Genre genre, Ort ort, string kommentar)
        {
            Titel = titel;
            Autor = autor;
            Genre = genre;
            Ort = ort;
            Kommentar = kommentar;
        }

        public override string ToString()
        {
            return String.Format("{0} von {1}", Titel, Autor);
        }
    }
}
