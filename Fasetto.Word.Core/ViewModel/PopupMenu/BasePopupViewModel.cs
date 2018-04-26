namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for any popup menus
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the background color of the bubble in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }
        /// <summary>
        /// the alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }
        /// <summary>
        /// the content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public BasePopupViewModel()
        {
            //set default values
            //TODO: move colors into core and make use of it here
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion

    }
}
