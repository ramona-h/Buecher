using Buecher.Model;
using Buecher.Util;
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

        public JsonHandler<Ort> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        public OrtAnlegenViewModel()
        {
            JsonHandler = new JsonHandler<Ort>(Paths.ORT);
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
        }

        private void OnAnlegen()
        {
            Ort ort = new Ort(Bezeichnung);
            if (JsonHandler.Contains(ort))
            {
                //Error
                //  DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Logging Out?", "EMPLOYEE MODULE | LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            else
            {
                JsonHandler.Write(ort);
            }
        }

        private bool OnAnlegenCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Bezeichnung);
        }
    }
}
