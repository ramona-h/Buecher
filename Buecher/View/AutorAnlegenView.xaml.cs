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
    /// Interaktionslogik für AutorAnlegenView.xaml
    /// </summary>
    public partial class AutorAnlegenView : UserControl
    {
        public AutorAnlegenView()
        {
            InitializeComponent();
            DataContext = new AutorAnlegenViewModel(DialogCoordinator.Instance); ;
        }
    }
}
