using RestaurantManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Home_BarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddOrder_button_Click(object sender, RoutedEventArgs e)
        {
            var ds = DataContext as DataManager;

            ds.CurrentlySelectedMenuItems.Add((string)MenuItems_listView.SelectedItem);
        }

        private void SubmitOrder_button_Click(object sender, RoutedEventArgs e)
        {
            var ds = DataContext as DataManager;

            ds.OrderItems.Add(string.Join(", ", ds.CurrentlySelectedMenuItems));
            ds.CurrentlySelectedMenuItems.Clear();
            Frame.Navigate(typeof(MainPage));
        }
    }
}