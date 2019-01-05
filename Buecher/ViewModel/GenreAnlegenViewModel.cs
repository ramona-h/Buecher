using Buecher.Model;
using Buecher.Util;
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
            set { _bezeichnung = value;
                OnPropertyChanged();
                AnlegenCommand.RaiseCanExecuteChanged();
            }
        }
        
        public JsonHandler<Genre> JsonHandler { get; }
        public DelegateCommand AnlegenCommand { get; }

        public GenreAnlegenViewModel()
        {
            JsonHandler = new JsonHandler<Genre>(Paths.GENRE);
            AnlegenCommand = new DelegateCommand(OnAnlegen, OnAnlegenCanExecute);
        }

        private void OnAnlegen()
        {
            Genre genre = new Genre(Bezeichnung);
            if (JsonHandler.Contains(genre)){
                //Error
              //  DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Logging Out?", "EMPLOYEE MODULE | LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            else
            {
                JsonHandler.Write(genre);
            }
        }

        private bool OnAnlegenCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Bezeichnung);
        }
    }
}
