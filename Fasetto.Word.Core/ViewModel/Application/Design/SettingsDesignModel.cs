using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design model for the <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Pielkop Cain" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "pielkop" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "Pielkop@cain.co.za" };
        }

        #endregion
    }
}
