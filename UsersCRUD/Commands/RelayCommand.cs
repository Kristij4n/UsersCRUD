using System;
using System.Windows.Input;

namespace UsersCRUD.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action DoJob;
        public RelayCommand(Action job)
        {
            DoJob = job;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoJob();
        }
    }
}
