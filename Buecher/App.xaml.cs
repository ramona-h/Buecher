using Buecher.Model;
using Buecher.Util;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Buecher
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // get the current app style (theme and accent) from the application
            // you can then use the current theme and custom accent instead set a new theme
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);


            if (File.Exists(Paths.SETTINGS.Pfad))
            {

                JsonHandler<MyTheme> jsonHandler = new JsonHandler<MyTheme>(Paths.SETTINGS);
                List<MyTheme> myThemes = jsonHandler.Read();

                //TODO: hier prüfen, ob Liste elemente enthält
                MyTheme myTheme = myThemes.ElementAt(0);

                ThemeManager.ChangeAppStyle(Application.Current,
                                           ThemeManager.GetAccent(myTheme.AccentName),
                                           ThemeManager.GetAppTheme(myTheme.AppThemeName));

            }
            else
            {
                //kein Pfad vorhanden, wird wohl später angelegt
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent("Blue"),
                                            ThemeManager.GetAppTheme("BaseLight"));
            }
            // or appStyle.Item1

            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            if (!Directory.Exists(Paths.BASE_PATH))
                Directory.CreateDirectory(Paths.BASE_PATH);

            foreach (var item in Paths.Values())
            {
                if (!File.Exists(item.Pfad))
                {
                   var myFile =  File.Create(item.Pfad);
                    myFile.Close();
                    if (item == Paths.SETTINGS)
                    {
                        JsonHandler<MyTheme> jsonHandler = new JsonHandler<MyTheme>(item);
                        jsonHandler.Write(new MyTheme(null, null));
                    }
                }
            }


            //JsonHandler<Genre> genre = new JsonHandler<Genre>(Paths.GENRE);
            //genre.Write(Genre.Values());

            //JsonHandler<Ort> ort = new JsonHandler<Ort>(Paths.ORT);
            //ort.Write(Ort.Values());
        }
    }
}
