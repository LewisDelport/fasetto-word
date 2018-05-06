using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// the last searched text in this list
        /// </summary>
        protected string mLastSearchText;
        /// <summary>
        /// the text to search for in the search command
        /// </summary>
        protected string mSearchText;
        /// <summary>
        /// a list of chat list items in the current search
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;
        /// <summary>
        /// a flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// the chat thread items for the list
        /// NOTE: do not call Items.Add to add messages to this list
        ///       as it will make the FilteredItems list out of sync
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                //make sure list has changed
                if (mItems == value)
                    return;

                //update value
                mItems = value;

                //update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }
        /// <summary>
        /// the chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }
        /// <summary>
        /// the title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }
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
        /// <summary>
        /// the text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }
        /// <summary>
        /// the text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                //check value is different
                if (mSearchText == value)
                    return;

                //update value
                mSearchText = value;

                //if the search text is empty
                if (string.IsNullOrEmpty(SearchText))
                    //Search to restore messages
                    Search();

            }
        }
        /// <summary>
        /// a flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                //check value has changed
                if (mSearchIsOpen == value)
                    return;

                //update value
                mSearchIsOpen = value;

                //if dialog closes...
                if (!mSearchIsOpen)
                    //clear search text
                    SearchText = string.Empty;
            }
        }

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
        /// <summary>
        /// the command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }
        /// <summary>
        /// the command for when the user wants to open the search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }
        /// <summary>
        /// the command for when the user wants to close the search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }
        /// <summary>
        /// the command for when the user wants to clear the search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

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
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
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
        public void Send()
        {

            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            //ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            //fake send a new message
            var message = new ChatMessageListItemViewModel
            {
                Initials = "PC",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Pielkop Cain",
                NewItem = true
            };

            //add message to both lists
            Items.Add(message);
            FilteredItems.Add(message);

            //message sent - clear the pending messsage text
            PendingMessageText = string.Empty;
        }
        /// <summary>
        /// searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            //make sure we don't re-search the same text
            if (string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            //if we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                //make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                //set last search
                mLastSearchText = SearchText;

                return;
            }

            //find all items that contain the given text
            //TODO: make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(Item => Item.Message.ToLower().Contains(SearchText)));

            //set last search
            mLastSearchText = SearchText;
        }
        /// <summary>
        /// clears the search text
        /// </summary>
        public void ClearSearch()
        {
            //if there is some search text
            if (!string.IsNullOrEmpty(SearchText))
                //clear the text
                SearchText = string.Empty;
            //otherwise...
            else
                //close search dialog
                SearchIsOpen = false;
        }
        /// <summary>
        /// opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;
        /// <summary>
        /// closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        #endregion

    }
}
