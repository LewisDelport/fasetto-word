using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design-time data for a <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            DisplayTitle = "PielkopCain, Me[Design]";

            Items = new ObservableCollection<ChatMessageListItemViewModel>()
            {
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Ballas",
                    Initials = "BF",
                    Message = "I'm about to wipe the old server. We need to update the old server to Windows 2016",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Piet",
                    Initials = "PS",
                    Message = "Let me know when you manage to spin up the new Windows 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Ballas",
                    Initials = "BF",
                    Message = "The new server is up. Go to 192.168.1.1.\r\nUsername is admin, password is P8ssw0rd",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
            };
        }

        #endregion
    }
}
