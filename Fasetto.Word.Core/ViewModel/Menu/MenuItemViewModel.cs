namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for a menu item
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// the text to display for the menu item
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// the icon for this menu item
        /// </summary>
        public IconType Icon { get; set; }
        /// <summary>
        /// the type of this menu item
        /// </summary>
        public MenuItemType Type { get; set; }
    }
}
