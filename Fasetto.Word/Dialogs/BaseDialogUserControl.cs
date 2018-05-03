using Fasetto.Word.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// the base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// the dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// the minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;
        /// <summary>
        /// the minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;
        /// <summary>
        /// the height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;
        /// <summary>
        /// the title for this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// closes this dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            //create a new dialog window
            mDialogWindow = new DialogWindow();

            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

            CloseCommand = new RelayCommand(() => mDialogWindow.Close());
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// display a single message box to the user
        /// </summary>
        /// <param name="viewModel">the view model</param>
        /// <typeparam name="T">the view model type for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            //create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            //run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //match controls expected sizes to the dialog windows view model
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    //setup this controls data context binding to the view model
                    DataContext = viewModel;

                    //show in the center of the parent
                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    //show dialog
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    //let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion

    }
}
