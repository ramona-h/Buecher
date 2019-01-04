using Buecher.Model;
using Buecher.Util;
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
using MahApps.Metro.Controls.Dialogs;
using Buecher.ViewModel;

namespace Buecher.View
{
    /// <summary>
    /// Interaktionslogik für BuchAnlegenView.xaml
    /// </summary>
    public partial class BuchAnlegenView : UserControl
    {

        public BuchAnlegenView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Altlasten entfernen
            cboxAutor.Items.Clear();
            cboxGenre.Items.Clear();
            cboxOrt.Items.Clear();

            JsonHandler<Autor> jsonHandler = new JsonHandler<Autor>(Paths.AUTOR);
            List<Autor> autoren = jsonHandler.Read();
            if (autoren != null)
            {
                foreach (var autor in autoren)
                {
                    cboxAutor.Items.Add(autor);
                }
            }

            foreach (var genre in Genre.Values())
            {
                cboxGenre.Items.Add(genre);
            }

            foreach (var ort in Ort.Values())
            {
                cboxOrt.Items.Add(ort);
            }
        }
    }
}
