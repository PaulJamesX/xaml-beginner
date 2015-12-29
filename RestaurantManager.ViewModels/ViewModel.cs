using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading.Tasks;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        private bool isLoading;
        public bool IsLoading { get { return this.isLoading; } set { this.isLoading = value; OnPropertyChanged(); } }

        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            this.IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
            this.IsLoading = false;
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
