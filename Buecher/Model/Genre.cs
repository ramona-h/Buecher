using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Model
{
    public class Genre : IComparable
    {

        public static Genre THRILLER = new Genre("Thriller");
        public static Genre FANTASY = new Genre("Fantasy");
        public static Genre KRIMI = new Genre("Krimi");
        public static Genre COMIC = new Genre("Comic");
        public static Genre KINDERBUCH = new Genre("Kinderbuch");
        public static Genre JUGENDBUCH = new Genre("Jugendbuch");
        public static Genre SONSTIGE = new Genre("Sonstige");

        public static List<Genre> Values()
        {
            List<Genre> list = new List<Genre>()
            {
                THRILLER, FANTASY, KRIMI, COMIC, KINDERBUCH, JUGENDBUCH, SONSTIGE
            };
            return list;
        }

        public string Bezeichnung { get; set; }

        public Genre(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
        }

        public override string ToString()
        {
            return Bezeichnung;
        }

        public int CompareTo(object obj)
        {
            Genre other = obj as Genre;
            return Bezeichnung.CompareTo(other.Bezeichnung);
        }
    }
}
