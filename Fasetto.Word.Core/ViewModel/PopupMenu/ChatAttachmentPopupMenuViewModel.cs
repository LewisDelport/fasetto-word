using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for any popup menus
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {

        #region Public Properties



        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>()
                {
                    new MenuItemViewModel { Text = "Attach a file...", Type = MenuItemType.Header},
                    new MenuItemViewModel() { Text = "From Computer", Icon = IconType.File },
                    new MenuItemViewModel() { Text = "From Pictures", Icon = IconType.Picture },
                }
            };
        }

        #endregion

    }
}
