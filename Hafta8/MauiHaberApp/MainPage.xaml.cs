using MauiHaberApp.HaberApi;

using System.Collections.ObjectModel;

namespace MauiHaberApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<HaberKategori> HaberKategorileri { get; set; } = HaberServisi.HaberKategorileri;

        public MainPage()
        {
            InitializeComponent();
            lstKategoriler.ItemsSource = HaberKategorileri;
        }

        private async void Kategori_Clicked(object sender, EventArgs e)
        {
            var kategori = (sender as Button).CommandParameter as HaberKategori;
            var haberler = await HaberServisi.GetHaberler(kategori);

            lstHaberler.ItemsSource = haberler;
        }

        private void lstHaberler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var haber = lstHaberler.SelectedItem as HaberApi.Item;

            var page = new HaberDetayPage(haber);
            Navigation.PushAsync(page);

        }
    }
}
