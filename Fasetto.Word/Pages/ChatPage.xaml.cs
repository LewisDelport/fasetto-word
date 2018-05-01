using Fasetto.Word.Core;
using System.Windows.Media.Animation;

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

        #region Override Methods

        /// <summary>
        /// fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            //make sure UI exists first
            if (ChatMessageList == null)
                return;

            //fade in message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(0.5f);
            storyboard.AddSlideFromRight(0.5f, ChatMessageList.RenderSize.Width);
            storyboard.Begin(ChatMessageList);
        }

        #endregion
    }
}
