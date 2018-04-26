namespace Fasetto.Word.Core
{
    /// <summary>
    /// helper functions for <see cref="IconType"/>
    /// </summary>
    public static class IconTypeExtensions
    {
        /// <summary>
        /// converts <see cref="IconType"/> to a FontAwesome string
        /// </summary>
        /// <param name="type">the type to convert</param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            //return a fontawesome string based on the icon type
            switch (type)
            {
                case IconType.Picture:
                    return "\uf1c5";
                case IconType.File:
                    return "\uf0f6";
                default:
                    return null;
            }
        }
    }
}
