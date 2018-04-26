using Fasetto.Word.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// a base page for all pages to gain base functionality 
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Properties

        /// <summary>
        /// the animation to play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        /// <summary>
        /// the animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        /// <summary>
        /// the time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;
        /// <summary>
        /// a flag to indicate if this page should animate out on load
        /// useful for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public BasePage() : base()
        {
            //don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            //if we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //listen for the page load
            this.Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load/Unload

        /// <summary>
        /// once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            //if we are setup to animate out on load,
            if (ShouldAnimateOut)
                //animate the page out
                await AnimateOutAsync();
            //otherwise
            else
                //animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            //make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //start the animation
                    await this.SlideAndFadeInFromRightAsync(this.SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;
            }
        }
        /// <summary>
        /// animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            //make sure we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    //start the animation
                    await this.SlideAndFadeOutToLeftAsync(this.SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;
            }
        }

        #endregion

    }

    /// <summary>
    /// a base page with added viewmodel support
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {

        #region Private Members

        /// <summary>
        /// the viewmodel associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// the viewmodel associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                //if nothing has changed, return
                if (mViewModel == value)
                    return;

                //update the value
                mViewModel = value;

                //set the data context for this page
                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        public BasePage() : base()
        {
            //create a default view model
            this.ViewModel = new VM();
        }

        #endregion
    }
}
