using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfPractice.Expressions;

namespace WpfPractice.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Runs command if updating flag is not set
        /// </summary>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // check if  flag property is true
            if (updatingFlag.GetPropertyValue())
                return;

            // set property flag to true
            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }
    }
}
