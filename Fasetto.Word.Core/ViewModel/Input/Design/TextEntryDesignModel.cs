namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design model for the <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {

        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructor

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Pielkop Cain";
            EditedText = "Editing :)";
        } 

        #endregion
    }
}
