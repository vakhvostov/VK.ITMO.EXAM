using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VK.ITMO.EXAM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Commands

        /*
        #region CloseAppCommand
        public ICommand CloseAppCommand { get; }

        private void OnCloseAppCommandExecuted(object p)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private bool CanCloseAppCommandExecuted(object p) => true;
        #endregion*/

        #endregion

        #region Title
        private string _Title = "DB Frontend";
        public string Title
        {
            get { return _Title; }
            set
            {
                if (Equals(_Title, value)) return;
                _Title = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            //CloseAppCommand = new Commands.LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecuted);
        }
    }
}
