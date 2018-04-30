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
        /// the view model to use for the current page when the currentpage changes
        /// NOTE: this is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

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
        /// <param name="viewModel">the view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            //always hide settings page if we are changing pages
            SettingsMenuVisible = false;

            //set the view model
            CurrentPageViewModel = viewModel;

            //set the current page
            CurrentPage = page;

            //fire off a currentpage changed event
            OnPropertyChanged(nameof(CurrentPage));

            //Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
