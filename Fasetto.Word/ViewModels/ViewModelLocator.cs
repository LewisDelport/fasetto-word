using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// the application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Application;
        /// <summary>
        /// the settings view model
        /// </summary>
        public static SettingsViewModel SettingsViewModel => IoC.Settings;

        #endregion
    }
}
