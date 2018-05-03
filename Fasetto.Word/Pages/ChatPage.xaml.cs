using Fasetto.Word.Core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
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
            //storyboard.AddSlideFromRight(0.5f, ChatMessageList.RenderSize.Width);
            storyboard.Begin(ChatMessageList);

            //make the message box focused
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// preview the input into the message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //get the text box
            var textbox = sender as TextBox;

            //check if we have pressed enter
            //if (e.Key == Key.Enter)
            //{
            //    //send the message
            //    ViewModel.Send();
            //    //mark this key handled by us
            //    e.Handled = true;
            //}

            //above code not needed - set isdefault on send button

            //check if we have pressed enter and are holding the control key
            if (e.Key == Key.Enter)
            {
                //if we have control pressed
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    //add a new line to the message box at where the cursor is
                    var index = textbox.CaretIndex;
                    //insert the new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //shift catet forward to the new line
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    //mark this key handled by us
                    e.Handled = true;
                }
                else
                {
                    //send the message
                    ViewModel.Send();
                    //mark key as handled
                    e.Handled = true;
                }
            }
        }
    }
}
