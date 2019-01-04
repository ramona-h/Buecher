using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Util
{
    public class JsonHandler<T>
    {
        public Paths Path { get; set; }

        public JsonHandler(Paths path)
        {
            Path = path;
        }

        public void Write(T o)
        {
            Write(o, false);
        }

        public void Write(List<T> objects)
        {
            Write(objects, false);
        }

        public void Write(List<T> objects, bool ueberschreiben)
        {
            List<T> vorhandenesZeug = new List<T>();

            if (!ueberschreiben)
            {
                vorhandenesZeug = Read();

                if (vorhandenesZeug == null)
                    vorhandenesZeug = new List<T>();
            }
            else
            {
                File.Delete(Path.Pfad);
                var file = File.Create(Path.Pfad);
                file.Close();
            }
            vorhandenesZeug.AddRange(objects);

            string json = JsonConvert.SerializeObject(vorhandenesZeug, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(File.Open(Path.Pfad, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None), Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        public void Write(T o, bool ueberschreiben)
        {
            List<T> objects = new List<T>
            {
                o
            };
            Write(objects, ueberschreiben);
        }

        public List<T> Read()
        {
            List<T> list = new List<T>();
            //  try
            // {
            list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Path.Pfad, Encoding.UTF8));
            // }
            //catch (FileNotFoundException)
            //{
            //    File.Create(Path.Pfad);
            //    list = new List<T>();
            //}
            if (list == null)
                list = new List<T>();

            return list;
        }

        public bool Contains(T o)
        {
            List<T> objects = Read();

            return objects.IsEmpty() ? false : objects.Contains(o);
        }

    }
}
