using RestaurantManager.Models;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        #region Field Members

        private ObservableCollection<MenuItem> menuItems;
        private ObservableCollection<MenuItem> currentlySelectedMenuItems;

        public DelegateCommand<MenuItem> AddItemCommand { get; private set; }
        public DelegateCommand<string> AddOrderCommand { get; private set; }

        #endregion

        #region Properties
        public ObservableCollection<MenuItem> MenuItems
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

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
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

        #region Constructors
        public OrderViewModel()
        {
            AddItemCommand = new DelegateCommand<MenuItem>(AddItem);
            AddOrderCommand = new DelegateCommand<string>(AddOrder);
        }
        #endregion

        #region Command Handlers

        private void AddItem(MenuItem currentItem)
        {
            this.CurrentlySelectedMenuItems.Add(currentItem);
        }

        private void AddOrder(string specialRequest)
        {
            Order order = new Order { SpecialRequests = specialRequest, Items = this.CurrentlySelectedMenuItems, Table = base.Repository.Tables[0] };
            base.Repository.AddOrder(order);
            new MessageDialog("Order Added", "New Order").ShowAsync();
            
        }

        #endregion

        #region Method Members

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>{};
        }

        #endregion
    }
}
