using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatPage() : base()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">the specific view model to use for this page</param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}
