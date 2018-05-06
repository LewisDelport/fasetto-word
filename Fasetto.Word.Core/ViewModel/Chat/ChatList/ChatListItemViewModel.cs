using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the latest message from this chat
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// the initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// the RGB values(in hex) for the background color of the profile picture
        /// for example FF00FF for red and blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }
        /// <summary>
        /// true if there is unread messages in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }
        /// <summary>
        /// true if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            //create commands
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// 
        /// </summary>
        public void OpenMessage()
        {
            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                DisplayTitle = "PielkopCain, Me",

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Pielkop",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message",
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message 2",
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message 3",
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "This is awesome",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Pielkop",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message",
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message 2",
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Dummy Message 3",
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere.crap",

                        },
                        Initials = "KF",
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Kiewiet",
                        SentByMe = false,
                    },

                }
            });
        }

        #endregion
    }
}
