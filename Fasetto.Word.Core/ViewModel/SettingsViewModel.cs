using System;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the settings state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
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
