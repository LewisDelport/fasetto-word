using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// the chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
