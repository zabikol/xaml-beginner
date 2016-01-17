using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
            => NotifyPropertyChanged(nameof(OrderItems));

        public List<Order> OrderItems => Repository?.Orders;
    }
}