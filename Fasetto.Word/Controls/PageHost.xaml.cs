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
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty); 
            set => SetValue(CurrentPageProperty, value); 
        }
        /// <summary>
        /// register <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage),
                typeof(ApplicationPage),
                typeof(PageHost),
                new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));

        /// <summary>
        /// the current page view model to show in the page host
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }
        /// <summary>
        /// register <see cref="CurrentPageViewModel"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel),
                typeof(BaseViewModel),
                typeof(PageHost),
                new UIPropertyMetadata());

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
                this.NewPage.Content = IoC.Application.CurrentPage.ToBasePage();
        }

        #endregion

        #region Property Changed Event

        /// <summary>
        /// called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            //get current values
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //if current page hasn't changed
            //just update the view model
            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                //just update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }


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
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }

        #endregion
    }
}
