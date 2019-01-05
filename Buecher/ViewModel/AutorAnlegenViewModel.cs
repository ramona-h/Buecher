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

        private IDialogCoordinator dialogCoordinator;

        public JsonHandler<Autor> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        public AutorAnlegenViewModel(IDialogCoordinator instance)
        {
            dialogCoordinator = instance;
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
            JsonHandler = new JsonHandler<Autor>(Paths.AUTOR);
        }

        private bool OnAnlegenCanExecute()
        {
            return string.IsNullOrWhiteSpace(Vorname) || string.IsNullOrWhiteSpace(Nachname) ? false : true;
        }

        private async void OnAnlegen()
        {
            Autor autor = new Autor(Nachname, Vorname);

            if (JsonHandler.Contains(autor))
            {
                //Error: Autor exisitiert bereits
                await dialogCoordinator.ShowMessageAsync(this, "Fehler", autor.ToString() + " existiert bereits");
            }
            else
            {                 
                JsonHandler.Write(autor);
                await dialogCoordinator.ShowMessageAsync(this, "Erfolg", autor.ToString() + " erfolgreich angelegt");
            }

        }
    }
}
