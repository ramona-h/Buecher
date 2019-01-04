using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Model
{
    public class Autor : IComparable
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }

        public Autor(string nachname, string vorname)
        {
            Nachname = nachname;
            Vorname = vorname;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Vorname, Nachname);
        }

        public override bool Equals(object obj)
        {
            return obj is Autor autor &&
                   Nachname == autor.Nachname &&
                   Vorname == autor.Vorname;
        }

        public override int GetHashCode()
        {
            var hashCode = 1790241851;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nachname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Vorname);
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            Autor other = obj as Autor;
            return Nachname.CompareTo(other.Nachname) == 0 ? Vorname.CompareTo(other.Vorname) : Nachname.CompareTo(other.Nachname);
        }
    }
}
