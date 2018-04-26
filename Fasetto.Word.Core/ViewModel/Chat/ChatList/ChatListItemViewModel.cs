namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
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
    }
}
