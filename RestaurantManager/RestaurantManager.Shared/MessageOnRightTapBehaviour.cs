using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace RestaurantManager.Shared
{
    public class MessageOnRightTapBehaviour : DependencyObject, IBehavior
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(MessageOnRightTapBehaviour), new PropertyMetadata(string.Empty));

        public DependencyObject AssociatedObject { get; private set; }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;

            if (AssociatedObject is UIElement)
            {
                (AssociatedObject as UIElement).RightTapped += PageRightTapped;
            }
        }

        public void Detach()
        {
            if (AssociatedObject != null && AssociatedObject is UIElement)
                (AssociatedObject as UIElement).RightTapped -= PageRightTapped;
        }

        private async void PageRightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(Message).ShowAsync();
        }
    }
}