using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// the current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// true if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; }
        /// <summary>
        /// true if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">the page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            //always hide settings page if we are changing pages
            SettingsMenuVisible = false;

            //set the current page
            CurrentPage = page;

            //Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
