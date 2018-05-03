using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fasetto.Word
{
    /// <summary>
    /// creates a clipping region from the parent <see cref="Border"/> <see cref="CornerRadius"/>
    /// </summary>
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {

        #region Private Members

        /// <summary>
        /// called when the parent border first loads
        /// </summary>
        private RoutedEventHandler mBorder_Loaded;
        /// <summary>
        /// called when the border resizes
        /// </summary>
        private SizeChangedEventHandler mBorder_SizeChanged;

        #endregion
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get self
            var self = (sender as FrameworkElement);

            //check we have a parent border
            if (!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            //setup loaded event
            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, self);
            //setup size changed event
            mBorder_SizeChanged = (s1, e1) => Border_OnChange(s1, e1, self);

            //if true, hook into events
            if ((bool)e.NewValue)
            {
                border.Loaded += mBorder_Loaded;
                border.SizeChanged += mBorder_SizeChanged;
            }
            //otherwise unhook
            else
            {
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeChanged;
            }

        }

        /// <summary>
        /// called when the border is loaded and changed size
        /// </summary>
        /// <param name="sender">the border</param>
        /// <param name="e"></param>
        /// <param name="child">the child element (our selves)</param>
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            //get border
            var border = (Border)sender;

            //check we have an actual size
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            //setup the child clipping area
            var rect = new RectangleGeometry();
            //match the corner radius with the border's corner radius
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));
            //set rectangle to match child's actual size
            rect.Rect = new Rect(child.RenderSize);
            //assign clipping area to the child
            child.Clip = rect;
        }
    }
}
