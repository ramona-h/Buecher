using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Util
{
    public class Paths
    {

        public static Paths AUTOR { get; }
        public static Paths BUCH { get; }
        public static Paths GENRE { get; }
        public static Paths ORT { get; }
        public static Paths SETTINGS { get; }

        public static List<Paths> Values()
        {
            return new List<Paths>() { AUTOR, BUCH, GENRE, ORT, SETTINGS };
        }


        public string Pfad { get; set; }


        public static string BASE_PATH = @"D:\";

        static Paths()
        {
            BASE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MeineBuecherverwaltung");
            AUTOR = new Paths("Autor.json");
            BUCH = new Paths("Buch.json");
            GENRE = new Paths("Genre.json");
            ORT = new Paths("Ort.json");
            SETTINGS = new Paths("Settings.json");
        }


        public Paths(string pfad)
        {
            Pfad = Path.Combine(BASE_PATH, pfad);
        }
    }
}
