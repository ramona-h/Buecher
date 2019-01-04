using Buecher.Styles.MahAppsMetroThemesSample;
using Buecher.Util;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Buecher.Styles
{
    /// <summary>
    /// Interaktionslogik für AccentStyleWindow.xaml
    /// </summary>
    public partial class AccentStyleWindow : MetroWindow
    {
        public static readonly DependencyProperty ColorsProperty
           = DependencyProperty.Register("Colors",
                                         typeof(List<KeyValuePair<string, Color>>),
                                         typeof(AccentStyleWindow),
                                         new PropertyMetadata(default(List<KeyValuePair<string, Color>>)));

        public List<KeyValuePair<string, Color>> Colors
        {
            get { return (List<KeyValuePair<string, Color>>)GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }

        public AccentStyleWindow()
        {
            InitializeComponent();

            ThemeManager.IsThemeChanged += ThemeManager_IsThemeChanged;

            this.DataContext = this;

            this.Colors = typeof(Colors)
                .GetProperties()
                .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
                .Select(prop => new KeyValuePair<String, Color>(prop.Name, (Color)prop.GetValue(null)))
                .ToList();

            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(this, theme.Item2, theme.Item1);
        }

        private void ChangeAppThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));
            ThemeManager.ChangeAppStyle(this, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));

        }

        private void ChangeAppAccentButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(((Button)sender).Content.ToString()), theme.Item1);
            ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent(((Button)sender).Content.ToString()), theme.Item1);
        }

        private void ThemeManager_IsThemeChanged(object sender, OnThemeChangedEventArgs e)
        {
            Accent accent = e.Accent;
            AppTheme theme = e.AppTheme;


            MyTheme myTheme = new MyTheme(theme, accent);
            JsonHandler<MyTheme> jsonHandler = new JsonHandler<MyTheme>(Paths.SETTINGS);
            jsonHandler.Write(myTheme, true);



        }
    }
}
