using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Util
{
   public static class ListExtension
    {

        public static bool IsEmpty<T>(this List<T> list)
        {
            return list!=null ? list.Count == 0 : true;
        }
    }
}
