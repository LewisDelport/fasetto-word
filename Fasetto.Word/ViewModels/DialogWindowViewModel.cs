using Fasetto.Word.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region Public Properties

        /// <summary>
        /// the title of this dialog window
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// the content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public DialogWindowViewModel(Window window) : base(window)
        {
            //make minimum size smaller
            WindowMinimumWidth = 250;
            WindowMinimumHeight = 100;

            //make title bar smaller
            TitleHeight = 30;
        }

        #endregion

    }
}
