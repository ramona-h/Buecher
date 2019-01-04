using Buecher.Model;
using Buecher.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.ViewModel
{
    public class BuchAnzeigenViewModel : BaseViewModel
    {
        public List<Buch> Buecherliste { get; }

        public JsonHandler<Buch> JsonHandler { get; }

        public BuchAnzeigenViewModel()
        {
            JsonHandler = new JsonHandler<Buch>(Paths.BUCH);

            Buecherliste = new List<Buch>();
            Buecherliste.AddRange(JsonHandler.Read());

            if (Buecherliste == null)
            {
                Buecherliste = new List<Buch>();
            }
        }


    }
}
