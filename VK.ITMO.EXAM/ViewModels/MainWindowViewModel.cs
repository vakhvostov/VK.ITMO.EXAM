using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VK.ITMO.EXAM.Data;
using VK.ITMO.EXAM.Models;
using VK.ITMO.EXAM.Views;


namespace VK.ITMO.EXAM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Data
        
        public ObservableCollection<ReportModel> Reports { get; set; }
        private DBAccess dba;
        private void updateReports()
        {
            List<ReportModel> t = dba.GetReports(); //костыль, вьюха сохраняет указатель на исходный список, что делать ХЗ
            Reports.Clear();
            foreach (ReportModel item in t)
                Reports.Add(item);
        }
        
        #endregion

        #region Commands

        
        #region AddCommand
        public ICommand AddCommand { get; }

        private void OnAddCommandExecuted(object p)
        {
            dba.InsertRecord(_SelectedReport);
            updateReports();
        }

        private bool CanAddCommandExecuted(object p) => (_SelectedReport is null) || (_SelectedReport.LineID > 0) ? false : true;
        #endregion

        #region EditCommand
        public ICommand EditCommand { get; }

        private void OnEditCommandExecuted(object p)
        {
            dba.UpdateRecord(_SelectedReport);
            updateReports();
        }

        private bool CanEditCommandExecuted(object p) => (_SelectedReport is null) || (_SelectedReport.LineID < 0) ? false:true;
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; }

        private void OnDeleteCommandExecuted(object p)
        {
            try
            {
                if( dba.DeleteRecord(_SelectedReport.LineID) == true)
                {
                    System.Windows.MessageBox.Show("Record removed");
                }
                else
                    System.Windows.MessageBox.Show("Record not found");
                updateReports();
            }
                
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }            
        }

        private bool CanDeleteCommandExecuted(object p) => (_SelectedReport is null) || (_SelectedReport.LineID < 0) ? false : true;
        #endregion

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

        private ReportModel _SelectedReport;

        public ReportModel SelectedReport { get => _SelectedReport; set { _SelectedReport = value; } }


        public MainWindowViewModel()
        {
            dba = new DBAccess();
            Reports = new ObservableCollection<ReportModel>(dba.GetReports());
            AddCommand = new Commands.LambdaCommand(OnAddCommandExecuted, CanAddCommandExecuted);
            EditCommand = new Commands.LambdaCommand(OnEditCommandExecuted, CanEditCommandExecuted);
            DeleteCommand = new Commands.LambdaCommand(OnDeleteCommandExecuted, CanDeleteCommandExecuted);
        }
    }
}
