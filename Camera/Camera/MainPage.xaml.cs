using Camera.db;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Camera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateList();
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPhotoPage());
        }

        void UpdateList()
        {
            ListPhoto.ItemsSource = null;
            ListPhoto.ItemsSource = App.Db.GetItems();
        }

        private void SwipeItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var id = ((SwipeItem)sender).CommandParameter.ToString();
                App.Db.DeleteItem(int.Parse(id));
                UpdateList();
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "ok");
            }
        }

        private async void SwipeItem_Clicked_1(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new UpdatePhotoPage((Photo)e.Item));
        }
    }
}
