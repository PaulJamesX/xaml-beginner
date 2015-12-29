using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        #region Field Members
        ObservableCollection<Order> orderItems;
        #endregion

        #region Properties

        public ObservableCollection<Order> OrderItems
        {
            get
            {
                return this.orderItems;
            }
            set
            {
                if(value != orderItems)
                {
                    this.orderItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Method Members

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        #endregion
    }
}
