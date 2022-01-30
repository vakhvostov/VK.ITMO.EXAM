using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VK.ITMO.EXAM.Data;


namespace VK.ITMO.EXAM.ViewModels
{
    internal class AuthorizationWindowViewModel : ViewModel
    {
        #region Commands

        #region ConnectCommand
        public ICommand ConnectCommand { get; }

        private void OnConnectCommandExecuted(object p)
        {
            if (authorizationWindows)
                DBAccess.DBSetConnectionParameters(path);
            else
                DBAccess.DBSetConnectionParameters(userName, password, path);
            MainWindow m = new MainWindow();
            m.Show();
        }

        private bool CanConnectCommandExecuted(object p) => true;
        #endregion

        #endregion

        #region Text
        private string userName = "sa";
        private string password = "satest";
        private string path = "LAPTOP-DHBMFRC4\\SQLEXPRESS";
        private bool authorizationWindows = true;
        public string UserName
        {
            get => userName;
            set
            {
                if (Equals(userName, value)) return;
                userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (Equals(password, value)) return;
                password = value;
                OnPropertyChanged();
            }
        }

        public string Path
        {
            get => path;
            set
            {
                if (Equals(path, value)) return;
                path = value;
                OnPropertyChanged();
            }
        }

        public bool AuthorizationWindows
        {
            get => authorizationWindows;
            set
            {
                authorizationWindows = value;
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
