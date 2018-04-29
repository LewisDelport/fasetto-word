using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the view model for a text entry to edit a string value
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the label to identify what this value is for
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// the current saved value
        /// </summary>
        public string OriginalText { get; set; }
        /// <summary>
        /// the current non-commited edited text
        /// </summary>
        public string EditedText { get; set; }
        /// <summary>
        /// indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }
        /// <summary>
        /// commits the edits and saves the value, 
        /// as well as go back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public TextEntryViewModel()
        {
            //create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            //set the edited text to the current value
            EditedText = OriginalText;

            //go into edit mode
            Editing = true;
        }
        /// <summary>
        /// cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }
        /// <summary>
        /// commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            //TODO: save content

            //save edited value
            OriginalText = EditedText;

            //go out of edit mode
            Editing = false;
        }

        #endregion

    }
}
