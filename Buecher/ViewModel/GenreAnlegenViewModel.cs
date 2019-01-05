using Buecher.Model;
using Buecher.Util;
using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buecher.ViewModel
{
    public class GenreAnlegenViewModel : BaseViewModel
    {
        private string _bezeichnung;

        public string Bezeichnung
        {
            get { return _bezeichnung; }
            set
            {
                _bezeichnung = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }

        public JsonHandler<Genre> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        private IDialogCoordinator dialogCoordinator;


        public GenreAnlegenViewModel(IDialogCoordinator instance)
        {
            dialogCoordinator = instance;
            JsonHandler = new JsonHandler<Genre>(Paths.GENRE);
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
        }

        private async void OnAnlegen()
        {
            Genre genre = new Genre(Bezeichnung);
            if (JsonHandler.Contains(genre))
            {
                //Error 
                await dialogCoordinator.ShowMessageAsync(this, "Fehler", "Das Genre " + genre.Bezeichnung + " existiert bereits!");
            }
            else
            {
                JsonHandler.Write(genre);
                await dialogCoordinator.ShowMessageAsync(this, "Erfolg", "Das Genre " + genre.Bezeichnung + " wurde erfolgreich angelegt!");
            }
        }

        private bool OnAnlegenCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Bezeichnung);
        }
    }
}
