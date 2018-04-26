using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for a menu
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// the items in this menu
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }
    }
}
