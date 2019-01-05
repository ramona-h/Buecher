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

            JsonHandler<Autor> autorJsonHandler = new JsonHandler<Autor>(Paths.AUTOR);
            List<Autor> autoren = autorJsonHandler.Read();
            //if (autoren != null)
            //{
                foreach (var autor in autoren)
                {
                    cboxAutor.Items.Add(autor);
                }
            //}

            JsonHandler<Genre> genreJsonHandler = new JsonHandler<Genre>(Paths.GENRE);
            List<Genre> genres = genreJsonHandler.Read();
            foreach (var genre in genres)
            {
                cboxGenre.Items.Add(genre);
            }

            
            foreach (var ort in new JsonHandler<Ort>(Paths.ORT).Read())
            {
                cboxOrt.Items.Add(ort);
            }
        }
    }
}
