using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for BubbleContent.xaml
    /// </summary>
    public partial class BubbleContent : UserControl
    {

        //#region Dependency Properties

        ///// <summary>
        ///// the current page to show in the page host
        ///// </summary>
        //public BasePage UIViewModel
        //{
        //    get => (BasePage)GetValue(CurrentPageProperty);
        //    set => SetValue(CurrentPageProperty, value);
        //}
        ///// <summary>
        ///// register <see cref="UIViewModel"/> as a dependency property
        ///// </summary>
        //public static readonly DependencyProperty CurrentPageProperty =
        //    DependencyProperty.Register(nameof(UIViewModel),
        //        typeof(BasePage),
        //        typeof(PageHost),
        //        new UIPropertyMetadata(CurrentPagePropertyChanged));

        //#endregion

        public BubbleContent()
        {
            InitializeComponent();
        }
    }
}
