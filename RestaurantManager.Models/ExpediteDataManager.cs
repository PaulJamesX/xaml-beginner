using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        #region Field Members
        List<Order> orderItems;
        #endregion

        #region Properties

        public List<Order> OrderItems
        {
            get { return this.orderItems; }
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
