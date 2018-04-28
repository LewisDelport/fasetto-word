using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// a base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {

        #region Public Properties

        /// <summary>
        /// a flag indicating if this is the first time this property has been loaded
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the framework element
            if (!(sender is FrameworkElement element))
                return;

            //dont fire if the value doesnt change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            //on first load
            if (FirstLoad)
            {
                //create a single self-unhookable event
                //for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    //unhook ourselves
                    element.Loaded -= onLoaded;

                    //do desired animation
                    DoAnimation(element, (bool)value);

                    //no longer in first load
                    FirstLoad = false;
                };

                //hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
            else
                //do desired animation
                DoAnimation(element, (bool)value);
        }

        /// <summary>
        /// the animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">the element</param>
        /// <param name="value">the new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }

    /// <summary>
    /// animates a framework element,
    /// sliding in from the left on show and
    /// sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //animate out
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }
    /// <summary>
    /// animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }
    /// <summary>
    /// animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// NOTE: keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
            else
                //animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }
    /// <summary>
    /// animates a framework element fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //animate in
                await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
            else
                //animate out
                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);
        }
    }
}
