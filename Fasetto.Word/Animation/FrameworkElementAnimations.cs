using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region Slide In From Left

        /// <summary>
        /// slides an element in from the left
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same width during animation</param>
        /// <param name="width">the animation width to animate to. if not specified then elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide from right animation
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// slides an element out to the left
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same width during animation</param>
        /// <param name="width">the animation width to animate to. if not specified then elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide from right animation
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
            //fully hide the element
            element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Slide In From Right

        /// <summary>
        /// slides an element in from the right
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same width during animation</param>
        /// <param name="width">the animation width to animate to. if not specified then elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide from right animation
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// slides an element out to the right
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same width during animation</param>
        /// <param name="width">the animation width to animate to. if not specified then elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide from right animation
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
            //fully hide the element
            element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Slide In From Bottom

        /// <summary>
        /// slides an element in from the bottom
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same height during animation</param>
        /// <param name="height">the animation height to animate to. if not specified then elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide from bottom animation
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// slides an element out to the bottom
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <param name="keepMargin">wheter to keep the element at the same height during animation</param>
        /// <param name="height">the animation height to animate to. if not specified then elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add slide to bottom animation
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);
            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
            //fully hide the element
            element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Fade In / Out

        /// <summary>
        /// fades an element in
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add fade in animation
            sb.AddFadeIn(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// fades an element out
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time in seconds the animation will take</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //create the storyboard
            var sb = new Storyboard();
            //add fade in animation
            sb.AddFadeOut(seconds);
            //start animating
            sb.Begin(element);
            //make page visible
            element.Visibility = Visibility.Visible;
            //wait for animation to finish
            await Task.Delay((int)seconds * 1000);
            //fully hide the element
            element.Visibility = Visibility.Hidden;
        }

        #endregion
        
    }
}
