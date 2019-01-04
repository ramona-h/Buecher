using Buecher.Model;
using Buecher.Util;
using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Buecher.ViewModel
{
    public class AutorAnlegenViewModel : BaseViewModel
    {
        #region Properties
        private string _vorname;

        public string Vorname
        {
            get { return _vorname; }
            set
            {
                _vorname = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        private string _nachname;

        public string Nachname
        {
            get { return _nachname; }
            set
            {
                _nachname = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        public JsonHandler<Autor> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        public AutorAnlegenViewModel()
        {
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
            JsonHandler = new JsonHandler<Autor>(Paths.AUTOR);
        }

        private bool OnAnlegenCanExecute()
        {
            return string.IsNullOrWhiteSpace(Vorname) || string.IsNullOrWhiteSpace(Nachname) ? false : true;
        }

        private void OnAnlegen()
        {
            Autor autor = new Autor(Nachname, Vorname);

            if (JsonHandler.Contains(autor))
            {
                //Error: Autor exisitiert bereits
                MessageBox.Show(autor.ToString() + " existiert bereits", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {                 
                JsonHandler.Write(autor);
                MessageBox.Show(autor.ToString() + " erfolgreich angelegt", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
