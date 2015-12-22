using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehaviour : DependencyObject, IBehavior
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject != null)
            {
                this.AssociatedObject = associatedObject;
                (this.AssociatedObject as Page).RightTapped += PageRightTapped;
            }
        }

        public void Detach()
        {
            if (this.AssociatedObject != null && this.AssociatedObject is Page)
            {
                this.AssociatedObject = null;
                (this.AssociatedObject as Page).RightTapped -= PageRightTapped;
            }
        }

        private async void PageRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(this.Message, this.Title).ShowAsync();
        }
    }
}
