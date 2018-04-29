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
        public TextEntryViewModel Password { get; set; }
        /// <summary>
        /// the current users email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

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
    }
}
