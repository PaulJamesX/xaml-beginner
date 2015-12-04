using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        #region Field Members

        private List<MenuItem> menuItems;
        private List<MenuItem> currentlySelectedMenuItems;

        #endregion

        #region Properties

        public List<MenuItem> MenuItems
        {
            get { return this.menuItems; }

            set
            {
                if(value != menuItems)
                {
                    this.menuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this.currentlySelectedMenuItems; }

            set
            {
                if (value != currentlySelectedMenuItems)
                {
                    this.currentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Method Members

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        #endregion
    }
}
