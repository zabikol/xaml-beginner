using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            MenuItems = Repository.StandardMenuItems;

            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                MenuItems[3],
                MenuItems[5]
            };
        }

        private List<MenuItem> menuItems;

        public List<MenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<MenuItem> currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return currentlySelectedMenuItems; }
            set { currentlySelectedMenuItems = value; NotifyPropertyChanged(); }
        }
    }
}