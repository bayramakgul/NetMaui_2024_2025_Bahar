namespace MauiHaberApp
{
    public partial class HaberDetayPage : ContentPage
    {
        HaberApi.Item haber;


        public HaberDetayPage(HaberApi.Item haber)
        {
            InitializeComponent();
            haberDetay.Source = haber.link;
            this.haber = haber;
        }


        private async void HaberPaylas_Clicked(object sender, EventArgs e)
        {

            await ShareUri(haber.link, Share.Default);
        }
        public async Task ShareUri(string uri, IShare share)
        {
            await share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = haber.title
            });
        }
    }
}
