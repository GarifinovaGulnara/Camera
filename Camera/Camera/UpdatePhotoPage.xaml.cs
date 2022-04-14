using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camera.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Essentials;

namespace Camera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePhotoPage : ContentPage
    {
        Photo nphoto;
        public static string title { get; set; }
        private bool state = false;
        public UpdatePhotoPage(Photo nphoto)
        {
            this.nphoto = nphoto;
            title = nphoto.Title;
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            img.Source = ImageSource.FromFile(nphoto.Path);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            state = !state;
            TitleEntry.IsEnabled = state;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            EditConfirmIcon.IsVisible = true;
            nphoto.Title = TitleEntry.Text;
        }

        private async void ChangePhotoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {

                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);

                // загружаем в ImageView

                nphoto.Path = photo.FullPath;
                EditConfirmIcon.IsVisible = true;
                Update();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        private async void SaveChanges_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (await DisplayAlert("", "Вы точно хотите сохранить изменения объект", "Да", "Нет"))
                {
                    App.Db.SaveItem(nphoto);
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}