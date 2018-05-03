using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for each chat message thread item in a chat thread
    /// </summary>
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// the display name of the sender of the message
        /// </summary>
        public string SenderName { get; set; }
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
        /// true if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// true if this message was sent by the signed in user
        /// </summary>
        public bool SentByMe { get; set; }
        /// <summary>
        /// the time the message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; } = DateTimeOffset.MinValue;
        /// <summary>
        /// true if this message has been read
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;
        /// <summary>
        /// the time the message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }
        /// <summary>
        /// a flag indicating if this item was added since the first main list of items was created
        /// used as a flag for animating in
        /// </summary>
        public bool NewItem { get; set; }
        /// <summary>
        /// the attachment to the message, if it is of an image type
        /// </summary>
        public ChatMessageListItemImageAttachmentViewModel ImageAttachment { get; set; }
        /// <summary>
        /// a flag indicating if we have any message text or not
        /// </summary>
        public bool HasMessage => Message != null;
        /// <summary>
        /// a flag indicating if we have an image attachment to this message
        /// </summary>
        public bool HasImageAttachment => ImageAttachment != null;
    }
}
