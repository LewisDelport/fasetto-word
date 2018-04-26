using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
        /// <summary>
        /// the viewmodel for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }
        /// <summary>
        /// true to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }
        /// <summary>
        /// true if any popup menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        #endregion

        #region Public Commands

        /// <summary>
        /// the command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }
        /// <summary>
        /// the command for when the attachment button is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }
        /// <summary>
        /// the command for when the user clicks the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            //create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);
            //make a default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// when the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            //toggle menu visibility
            AttachmentMenuVisible ^= true;
        }
        /// <summary>
        /// when the popup clickaway area is clicked hide any popups
        /// </summary>
        private void PopupClickaway()
        {
            //toggle menu visibility to false
            AttachmentMenuVisible = false;
        }
        /// <summary>
        /// when the user clicks the send button, sends the message
        /// </summary>
        private void Send()
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for writing a nice message :)",
                OkText = "OK"
            });
        }

        #endregion

    }
}
