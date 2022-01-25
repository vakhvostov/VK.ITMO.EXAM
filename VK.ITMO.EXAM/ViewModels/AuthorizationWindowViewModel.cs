using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VK.ITMO.EXAM.ViewModels
{
    internal class AuthorizationWindowViewModel : ViewModel
    {
        #region Commands

        #region ConnectCommand
        public ICommand ConnectCommand { get; }

        private void OnConnectCommandExecuted(object p)
        {
            System.Windows.MessageBox.Show(this._UserName + "" + this._Password + this._AuthorizationWindows);
        }

        private bool CanConnectCommandExecuted(object p) => true;
        #endregion

        #endregion

        #region Text
        private string _UserName = "sa";
        private string _Password = "satest";
        private bool _AuthorizationWindows = true;
        public string UserName
        {
            get => _UserName;
            set
            {
                if (Equals(_UserName, value)) return;
                _UserName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (Equals(_Password, value)) return;
                _Password = value;
                OnPropertyChanged();
            }
        }

        public bool AuthorizationWindows
        {
            get => _AuthorizationWindows;
            set
            {
                _AuthorizationWindows = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public AuthorizationWindowViewModel()
        {
            ConnectCommand = new Commands.LambdaCommand(OnConnectCommandExecuted, CanConnectCommandExecuted);
        }

    }
}
