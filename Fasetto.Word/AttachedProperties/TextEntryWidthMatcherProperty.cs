using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// match the label width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the panel (grid typically)
            var panel = (sender as Panel);

            //call SetWidths initially (this also helps design time to work)
            SetWidths(panel);

            //wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                //unhook
                panel.Loaded -= onLoaded;

                //set widths
                SetWidths(panel);

                foreach (var child in panel.Children)
                {
                    //ignore any non-text entry control
                    if (!(child is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        //update widths
                        SetWidths(panel);
                    };
                }
            };

            //hook into the Loaded event
            panel.Loaded += onLoaded;
        }

        /// <summary>
        /// update all child text entry controls so their widths match the largest width of the group
        /// </summary>
        /// <param name="panel">the panel containing the text entry controls</param>
        private void SetWidths(Panel panel)
        {
            //keep track of the maximum width
            var maxSize = 0d;

            //for each child...
            foreach (var child in panel.Children)
            {
                //ignore any non-text entry control
                if (!(child is TextEntryControl control))
                    continue;

                //find if this value is larger than the other controls
                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            //create a grid length converter
            var gridLength = (GridLength)(new GridLengthConverter().ConvertFromString(maxSize.ToString()));

            //for each child
            foreach (var child in panel.Children)
            {
                //ignore any non-text entry control
                if (!(child is TextEntryControl control))
                    continue;

                //set each controls LabelWidth value to the max size
                control.LabelWidth = gridLength;
            }
        }
    }
}
