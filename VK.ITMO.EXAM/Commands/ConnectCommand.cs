using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.ITMO.EXAM.Commands
{
    class ConnectCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => System.Windows.MessageBox.Show("d");
    }
}
