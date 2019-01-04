using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.Util
{
    public class MyTheme
    {

        public string AppThemeName { get; set; }
        public string AccentName { get; set; }

        public MyTheme(AppTheme appTheme, Accent accent)
        {
            AppThemeName = appTheme == null ? "BaseLight" : appTheme.Name;
            AccentName = accent == null ? "Blue" : accent.Name;
        }
    }
}
