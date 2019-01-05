using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Model 
{
    public class Ort : IComparable
    {
        //public static Ort REGAL_BETT_RECHTS = new Ort("Regal Bett rechts");
        //public static Ort REGAL_BETT_LINKS = new Ort("Regal Bett links");
        //public static Ort SCHRANK_LINKS_1 = new Ort("Schrank links 1. von oben");
        //public static Ort SCHRANK_LINKS_2 = new Ort("Schrank links 2. von oben");
        //public static Ort SCHRANK_LINKS_3 = new Ort("Schrank links 3. von oben");
        //public static Ort SCHRANK_LINKS_4 = new Ort("Schrank links 4. von oben");
        //public static Ort SCHRANK_LINKS_5 = new Ort("Schrank links 5. von oben");
        //public static Ort SCHRANK_RECHTS_1 = new Ort("Schrank rechts 1. von oben");
        //public static Ort SCHRANK_RECHTS_2 = new Ort("Schrank rechts 2. von oben");
        //public static Ort SCHRANK_RECHTS_3 = new Ort("Schrank rechts 3. von oben");
        //public static Ort SCHRANK_RECHTS_4 = new Ort("Schrank rechts 4. von oben");
        //public static Ort SCHRANK_RECHTS_5 = new Ort("Schrank rechts 5. von oben");
        //public static Ort SONSTIGE = new Ort("sonstige");

        //public static List<Ort> Values()
        //{
        //    List<Ort> list = new List<Ort>()
        //    {
        //        REGAL_BETT_RECHTS,
        //        REGAL_BETT_LINKS,
        //        SCHRANK_LINKS_1,
        //        SCHRANK_LINKS_2,
        //        SCHRANK_LINKS_3,
        //        SCHRANK_LINKS_4,
        //        SCHRANK_LINKS_5,
        //        SCHRANK_RECHTS_1,
        //        SCHRANK_RECHTS_2,
        //        SCHRANK_RECHTS_3,
        //        SCHRANK_RECHTS_4,
        //        SCHRANK_RECHTS_5,
        //        SONSTIGE
        //    };
        //    return list;
        //}

        public string Bezeichnung { get; set; }

        public Ort(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
        }

        public override string ToString()
        {
            return Bezeichnung;
        }

        public int CompareTo(object obj)
        {
            Ort other = obj as Ort;
            return Bezeichnung.CompareTo(other.Bezeichnung);
        }

        public override bool Equals(object obj)
        {
            return obj is Ort ort &&
                   Bezeichnung == ort.Bezeichnung;
        }

        public override int GetHashCode()
        {
            return 1826680653 + EqualityComparer<string>.Default.GetHashCode(Bezeichnung);
        }
    }
}
