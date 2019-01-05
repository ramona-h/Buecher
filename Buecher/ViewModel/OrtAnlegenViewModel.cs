using Buecher.Model;
using Buecher.Util;
using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher.ViewModel
{
    public class OrtAnlegenViewModel : BaseViewModel
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

        private IDialogCoordinator dialogCoordinator;
        public JsonHandler<Ort> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        public OrtAnlegenViewModel(IDialogCoordinator instance)
        {
            dialogCoordinator = instance;
            JsonHandler = new JsonHandler<Ort>(Paths.ORT);
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
        }

        private async void OnAnlegen()
        {
            Ort ort = new Ort(Bezeichnung);
            if (JsonHandler.Contains(ort))
            {
                //Error
                await dialogCoordinator.ShowMessageAsync(this, "Fehler", "Der Ort " + ort.Bezeichnung + " existiert bereits!");
            }
            else
            {
                JsonHandler.Write(ort);
                await dialogCoordinator.ShowMessageAsync(this, "Erfolg", "Der Ort " + ort.Bezeichnung + " wurde erfolgreich angelegt!");

            }
        }

        private bool OnAnlegenCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Bezeichnung);
        }
    }
}
