using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for a <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {

        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion
        
        #region Constructor

        /// <summary>
        /// default contructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>()
            {
                new MenuItemDesignModel() { Type = MenuItemType.Header, Text = "Design-time header" },
                new MenuItemDesignModel() { Text = "menu item 1 - file", Icon = IconType.File },
                new MenuItemDesignModel() { Text = "menu item 2 - picture", Icon = IconType.Picture },
            };
        }

        #endregion

    }
}
