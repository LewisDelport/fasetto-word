using Fasetto.Word.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// the current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty); 
            set => SetValue(CurrentPageProperty, value); 
        }
        /// <summary>
        /// register <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage),
                typeof(BasePage),
                typeof(PageHost),
                new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //if we are in design mode, show the current page
            //as the dependency property does not fire
            if (DesignerProperties.GetIsInDesignMode(this))
                this.NewPage.Content = (BasePage)new ApplicationPageValueConverter().Convert(IoC.Get<ApplicationViewModel>().CurrentPage);
        }

        #endregion

        #region Property Changed Event

        /// <summary>
        /// called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //remove current page from new page frame
            newPageFrame.Content = null;

            //move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            //animate out previous page when the loaded event fires
            //right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                //tell old page to animate out
                oldPage.ShouldAnimateOut = true;

                //once it is done, remove it
                Task.Delay((int)oldPage.SlideSeconds * 1000).ContinueWith((t) =>
                {
                    //remove old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            //set the new page content
            newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}
