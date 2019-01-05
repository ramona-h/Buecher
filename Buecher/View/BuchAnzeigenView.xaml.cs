using Buecher.Model;
using Buecher.Util;
using Buecher.ViewModel;
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

namespace Buecher.View
{
    /// <summary>
    /// Interaktionslogik für BuchAnzeigenView.xaml
    /// </summary>
    public partial class BuchAnzeigenView : UserControl
    {
        public BuchAnzeigenView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            DataContext = new BuchAnzeigenViewModel();
            //dGrid.Items.Clear();

            //dGrid.AutoGenerateColumns = true;
            //dGrid.IsSynchronizedWithCurrentItem = true;

            //JsonHandler<Buch> jsonHandler = new JsonHandler<Buch>("_Buch");
            //List<Buch> list = jsonHandler.Read();
            //foreach (var buch in list)
            //{
            //    dGrid.Items.Add(buch);
            //}
           
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
