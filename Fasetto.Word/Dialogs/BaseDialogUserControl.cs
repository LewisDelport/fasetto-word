using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// the base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// the dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// the minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        #endregion

        #region Public Commands

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public BaseDialogUserControl()
        {

        }

        #endregion
    }
}
