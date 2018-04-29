using System.Security;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the view model for a password entry to edit a password
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the label to identify what this value is for
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// the fake password display string
        /// </summary>
        public string FakePassword { get; set; }
        /// <summary>
        /// the current password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }
        /// <summary>
        /// the new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }
        /// <summary>
        /// the confirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }
        /// <summary>
        /// the current saved password
        /// </summary>
        public SecureString CurrentPassword { get; set; }
        /// <summary>
        /// the current non-commited edited password
        /// </summary>
        public SecureString NewPassword { get; set; }
        /// <summary>
        /// the current non-commited edited confirm password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }
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
        public PasswordEntryViewModel()
        {
            //create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            //set default hints
            //TODO: replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            //clear all password
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

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
            //make sure current password is correct
            //TODO: this will come from the real back-end store of this users password
            //      or via asking the web server to confirm it
            var storedPassword = "Testing";

            //confirm current password is a match
            //NOTE: typically this isn't done here, it's done on the server
            if (storedPassword != CurrentPassword.Unsecure())
            {
                //let user know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong Password",
                    Message = "The current password is invalid"
                });

                return;
            }

            //now check that the new and confirm password match
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                //let user know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not match"
                });

                return;
            }

            //check we actually have a password
            if (NewPassword.Unsecure().Length == 0)
            {
                //let user know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!"
                });

                return;
            }

            //set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);

            //go out of edit mode
            Editing = false;
        }

        #endregion

    }
}
