namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design model for the <see cref="MessageBoxDialogViewModel"/>
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {

        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            Message = "Design time message... Hello World";
            OkText = "Ok";
        } 

        #endregion
    }
}
