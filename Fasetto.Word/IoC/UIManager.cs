using System;
using System.Threading.Tasks;
using Fasetto.Word.Core;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// the applications implementation of the <see cref="IUIManager"/> 
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// display a single message box to the user
        /// </summary>
        /// <param name="viewModel">the view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            //create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            //run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    new DialogWindow().ShowDialog();
                }
                finally
                {
                    //let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }
    }
}
