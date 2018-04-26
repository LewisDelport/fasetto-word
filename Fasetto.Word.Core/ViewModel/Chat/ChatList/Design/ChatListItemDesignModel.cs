namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "PS";
            Name = "Piet";
            Message = "This chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
            NewContentAvailable = false;
        }

        #endregion
    }
}
