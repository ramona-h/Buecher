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

        public override bool Equals(object obj)
        {
            return obj is Buch buch &&
                   Titel == buch.Titel &&
                   EqualityComparer<Autor>.Default.Equals(Autor, buch.Autor);
        }

        public override int GetHashCode()
        {
            var hashCode = -693040488;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titel);
            hashCode = hashCode * -1521134295 + EqualityComparer<Autor>.Default.GetHashCode(Autor);
            hashCode = hashCode * -1521134295 + EqualityComparer<Genre>.Default.GetHashCode(Genre);
            hashCode = hashCode * -1521134295 + EqualityComparer<Ort>.Default.GetHashCode(Ort);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Kommentar);
            return hashCode;
        }
    }
}
