using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a design model for the overview chat list
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>()
            {
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "3d00c5"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "3d00c5"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "PS",
                    Name = "Piet",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemDesignModel()
                {
                    Initials = "KL",
                    Name = "Koelie",
                    Message = "This chat app is taking loooooooonnnnnnggggg! I bet it will be fast too",
                    ProfilePictureRGB = "3d00c5"
                },
            };
        }

        #endregion
    }
}
