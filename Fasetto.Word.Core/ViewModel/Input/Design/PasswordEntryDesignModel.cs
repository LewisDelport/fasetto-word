namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design model for the <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {

        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        public PasswordEntryDesignModel()
        {
            Label = "Password";
            FakePassword = "********";
        } 

        #endregion
    }
}
