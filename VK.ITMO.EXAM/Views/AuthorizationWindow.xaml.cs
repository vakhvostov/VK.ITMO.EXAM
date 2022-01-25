using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VK.ITMO.EXAM.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }



        private void cbWinAuthorization_Unchecked(object sender, RoutedEventArgs e)
        {
            tbPassword.IsEnabled = true;
            tbUserName.IsEnabled = true;
        }

        private void cbWinAuthorization_Checked(object sender, RoutedEventArgs e)
        {
            tbPassword.IsEnabled = false;
            tbUserName.IsEnabled = false;
        }
    }
}
