namespace Fasetto.Word.Core
{
    /// <summary>
    /// details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the title of the message box
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// the message to display
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// the text to use for the OK button
        /// </summary>
        public string OkText { get; set; }

        #endregion

    }
}
