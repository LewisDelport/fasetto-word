using Fasetto.Word.Core;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {

        #region Private Members

        /// <summary>
        /// the view model for this window
        /// </summary>
        private DialogWindowViewModel mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// the view model for this window
        /// </summary>
        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                //set new value
                mViewModel = value;

                //update data context
                DataContext = mViewModel;
            }
        }

        #endregion


        public DialogWindow()
        {
            InitializeComponent();

            DataContext = new DialogWindowViewModel(this);

            (DataContext as DialogWindowViewModel).Title = "Message Title";
        }
    }
}
