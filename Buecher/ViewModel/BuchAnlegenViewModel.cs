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
    public class BuchAnlegenViewModel : BaseViewModel
    {
        #region Properties
        private string _titel;

        public string Titel
        {
            get { return _titel; }
            set
            {
                _titel = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        private Autor _autor;

        public Autor Autor
        {
            get { return _autor; }
            set
            {
                _autor = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        private Genre _genre;

        public Genre Genre
        {
            get { return _genre; }
            set { _genre = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        private Ort _ort;

        public Ort Ort
        {
            get { return _ort; }
            set { _ort = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        private string _kommentar;

        public string Kommentar
        {
            get { return _kommentar; }
            set
            {
                _kommentar = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }



        #endregion

        private IDialogCoordinator dialogCoordinator;

        public JsonHandler<Buch> JsonHandler { get; }

        public DelegateCommand AnlegenCommand { get; }

        public BuchAnlegenViewModel(IDialogCoordinator instance)
        {
            dialogCoordinator = instance;
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnCanAnlegen);
            JsonHandler = new JsonHandler<Buch>(Paths.BUCH);
        }

        private bool OnCanAnlegen()
        {
            return string.IsNullOrEmpty(Titel) || Autor == null || Genre == null || Ort == null ? false : true;
        }

        private async void OnAnlegen()
        {
            Buch buch = new Buch(Titel, Autor, Genre, Ort, Kommentar);

            if (JsonHandler.Contains(buch))
            {
                //Error
                await dialogCoordinator.ShowMessageAsync(this, "Fehler", buch.ToString() + " existiert bereits");
            }
            else
            {
                JsonHandler.Write(buch);
                await dialogCoordinator.ShowMessageAsync(this, "Erfolg", buch.ToString() + " erfolgreich angelegt");
            }
        }
    }
}
