using Buecher.ViewModel;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaktionslogik für GenreAnlegenView.xaml
    /// </summary>
    public partial class GenreAnlegenView : UserControl
    {

        public GenreAnlegenView()
        {
            InitializeComponent();
            DataContext = new GenreAnlegenViewModel(DialogCoordinator.Instance); ;
        }
    }
}
