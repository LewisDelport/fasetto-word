namespace Fasetto.Word.Core
{
    /// <summary>
    /// details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {

        #region Public Properties

        /// <summary>
        /// the message to display
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// the text to use for the OK button
        /// </summary>
        public string OkText { get; set; } = "OK";

        #endregion

    }
}
