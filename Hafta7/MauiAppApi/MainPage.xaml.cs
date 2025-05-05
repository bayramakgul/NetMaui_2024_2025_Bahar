using MauiAppApi.Services;

namespace MauiAppApi
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var data = await KurServisi.GetKurBilgileri();

        }
    }

}
