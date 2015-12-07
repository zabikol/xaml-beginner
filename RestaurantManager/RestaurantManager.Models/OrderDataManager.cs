using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };

            //Property notification is handled in the Set methods
        }

        private List<MenuItem> menuItems;

        public List<MenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; NotifyPropertyChanged(); }
        }

        private List<MenuItem> currentlySelectedMenuItems;

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return currentlySelectedMenuItems; }
            set { currentlySelectedMenuItems = value; NotifyPropertyChanged(); }
        }
    }
}