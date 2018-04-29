using System;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the settings state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the current users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }
        /// <summary>
        /// the current users username
        /// </summary>
        public TextEntryViewModel Username { get; set; }
        /// <summary>
        /// the current users password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }
        /// <summary>
        /// the current users email
        /// </summary>
        public TextEntryViewModel Email { get; set; }
        /// <summary>
        /// the text for the logout button
        /// </summary>
        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// the command to open the settings menu
        /// </summary>
        public ICommand OpenCommand { get; set; }
        /// <summary>
        /// the command to close the settings menu
        /// </summary>
        public ICommand CloseCommand { get; set; }
        /// <summary>
        /// the command to logout of the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        /// <summary>
        /// the command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public SettingsViewModel()
        {
            //create commands
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //TODO: get from localization
            LogoutButtonText = "Logout";
        }

        #endregion

        /// <summary>
        /// Opens the settings menu
        /// </summary>
        public void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }
        /// <summary>
        /// Closes the settings menu
        /// </summary>
        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }
        /// <summary>
        /// Logs out of the application
        /// </summary>
        public void Logout()
        {
            //TODO: confirm user wants to logout

            //TODO: clear any user data/cache
            ClearUserData();

            //goto login page
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
        /// <summary>
        /// clears any data specific to the current user
        /// </summary>
        public void ClearUserData()
        {
            //clear all view models containing the users info
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}
