using Buecher.Styles;
using Buecher.Util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buecher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       private MetroWindow accentThemeTestWindow;

       private void Button_StyleChange_Click(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }

            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }

        private MetroWindow aboutWindow;

        private void Button_About_Click(object sender, RoutedEventArgs e)
        {
            if (aboutWindow != null)
            {
                aboutWindow.Activate();
                return;
            }

            aboutWindow = new AboutWindow();
            aboutWindow.Owner = this;
            aboutWindow.Closed += (o, args) => aboutWindow = null;
            aboutWindow.Left = this.Left + this.ActualWidth / 2.0;
            aboutWindow.Top = this.Top + this.ActualHeight / 2.0;
            aboutWindow.Show();
        }
    }
}
