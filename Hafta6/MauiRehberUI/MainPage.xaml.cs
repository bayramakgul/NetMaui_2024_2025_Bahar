using RehberBL;

using RehberEntity;

using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiRehberUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            lstContacts.ItemsSource = BL.Contacts;
        }
        


        private void AddContactClicked(object sender, EventArgs e)
        {
            MyContact contact = new MyContact();
            ContactDetails page = new ContactDetails(contact);
            Navigation.PushModalAsync(page);

            string message = string.Empty;
            if (!BL.AddContact(contact, ref message))
                DisplayAlert("Hata", message, "Tamam");
        }

        private async void DeleteContactClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;
            var res = await DisplayAlert("Silmeyi onayla", "Silinsin mi", "Tamam", "İptal" );

            string message = string.Empty;
            if (res)
            {
               if(! BL.RemoveContact(contact, ref message))
                    DisplayAlert("Hata", message, "Tamam");
            }
        }

        private void EditContactClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;
            ContactDetails page = new ContactDetails(contact);
            Navigation.PushModalAsync(page);

            string message = string.Empty;
            if (!BL.EditContact(contact, ref message))
                DisplayAlert("Hata", message, "Tamam");
        }

        private async void AddPictureClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;

            string action = await DisplayActionSheet("Resim kaynağını seç", "İptal", null, "Kameradan Çek", "Galeriden Seç");

            FileResult result = null;

            try
            {
                if (action == "Kameradan Çek")
                {
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        result = await MediaPicker.Default.CapturePhotoAsync();
                    }
                    else
                    {
                        await DisplayAlert("Hata", "Cihazda kamera desteklenmiyor.", "Tamam");
                    }
                }
                else if (action == "Galeriden Seç")
                {
                    result = await FilePicker.Default.PickAsync(new PickOptions
                    {
                        FileTypes = FilePickerFileType.Images,
                        PickerTitle = "Bir resim seçin"
                    });
                }

                if (result != null)
                {
                    //var stream = await result.OpenReadAsync();
                    contact.Picture = result.FullPath; //ImageSource.FromStream(() => stream).;

                    string message = string.Empty;
                    if (!BL.EditContact(contact, ref message))
                        DisplayAlert("Hata", message, "Tamam");


                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Resim alınamadı: {ex.Message}", "Tamam");
            }
        }
    }


}


