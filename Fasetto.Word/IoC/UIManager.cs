using Fasetto.Word.Core;
using System;
using System.Threading.Tasks;
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
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
