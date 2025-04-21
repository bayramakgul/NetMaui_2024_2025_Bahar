using Microsoft.Maui.ApplicationModel.Communication;

using RehberBL;

using RehberEntity;

using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiRehberUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            string message = string.Empty;
            if(!BL.LoadContacts(ref message))
                DisplayAlert("Hata", message, "Tamam");


            lstContacts.ItemsSource = BL.Contacts;
        }



        private async void AddContactClicked(object sender, EventArgs e)
        {
            MyContact contact = new MyContact();
            ContactDetails page = new ContactDetails(contact)
            {
                PictureSelector = AddPicture
            };
            var saveTask = page.SaveTaskCompletion.Task;
            await Navigation.PushModalAsync(page);

            bool isOk = await saveTask; // Tamam tıkladıysam
            if (isOk)
            {
                string message = string.Empty;
                if (!BL.AddContact(contact, ref message))
                    await DisplayAlert("Hata", message, "Tamam");
            }
        }

        private async void DeleteContactClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;
            if (contact == null)
                contact = lstContacts.SelectedItem as MyContact;

            var res = await DisplayAlert("Silmeyi onayla", "Silinsin mi", "Tamam", "İptal" );

            string message = string.Empty;
            if (res)
            {
               if(! BL.RemoveContact(contact, ref message))
                    DisplayAlert("Hata", message, "Tamam");
            }
        }

        private async void EditContactClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;
            if (contact == null)
                contact = lstContacts.SelectedItem as MyContact;

            ContactDetails page = new ContactDetails(contact){ PictureSelector = AddPicture};
            var saveTask = page.SaveTaskCompletion.Task;
            await Navigation.PushModalAsync(page);

            bool isOk = await saveTask; // Tamam tıkladıysam
            if (isOk)
            {
                string message = string.Empty;
                if (!BL.EditContact(contact, ref message))
                    await DisplayAlert("Hata", message, "Tamam");
            }
        }



        private async void AddPictureClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as MyContact;
            if(contact == null)
                contact = lstContacts.SelectedItem as MyContact;

            var path = await GetPicture();
            if (path != null)
            {
                contact.Picture = path;

                string message = string.Empty;
                if (!BL.EditContact(contact, ref message))
                    DisplayAlert("Hata", message, "Tamam");
            }

        }

        void  AddPicture(MyContact contact)
        {
            contact.Picture = GetPicture().Result;
        }

        async Task<string> GetPicture()
        {
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
                    result = await MediaPicker.Default.PickPhotoAsync();
                }

                return result.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Resim alınamadı: {ex.Message}", "Tamam");
            }

            return null;
        }
    }


}


