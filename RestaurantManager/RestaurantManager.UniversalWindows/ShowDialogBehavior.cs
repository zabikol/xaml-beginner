using Microsoft.Xaml.Interactions;
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.UniversalWindows
{
    public class ShowDialogOnRightTappedBehavior : DependencyObject, IBehavior
    {
        public string Message { get; set; }
        public string Title { get; set; } = "Info";

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is UIElement)
            {
                AssociatedObject = associatedObject;
                (AssociatedObject as UIElement).Tapped += ShowDialogOnRightTappedBehavior_Tapped;
            }
        }

        private async void ShowDialogOnRightTappedBehavior_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        private async void ShowDialogOnRightTappedBehavior_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        private async void ShowDialogOnRightTappedBehavior_RightTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            if (AssociatedObject is UIElement)
                (AssociatedObject as UIElement).Tapped -= ShowDialogOnRightTappedBehavior_Tapped;
        }
    }
}