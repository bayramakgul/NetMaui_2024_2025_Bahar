using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MauiAppEmlak
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<EmlakIlan> Ilanlar = new ();
        public MainPage()
        {
            Ilanlar = DataGenerator.RastgeleUret(20);

            InitializeComponent();
            lstIlanlar.ItemsSource = Ilanlar;

        }



        private async void lstIlanlar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //await Navigation.PushAsync(new IlanDetayPage((EmlakIlan)e.CurrentSelection[0]));

        }


        private async void SwipeItem_LeftClicked(object sender, EventArgs e)
        {
            var ilan = (EmlakIlan)lstIlanlar.SelectedItem;
            if (ilan == null)
                return;
            var a = await DisplayActionSheet("İletişim", "İptal", null,
                $"Telefon: 📞 {ilan.IletisimTelefon}",
                $"Email: 📧 {ilan.IletisimEmail}");

            await DisplayAlert("iletişime geçiliyor", a, "İptal");
        }

        private async void SwipeItem_RightClicked(object sender, EventArgs e)
        {
            var ilan = (EmlakIlan)lstIlanlar.SelectedItem;
            if (ilan == null)
                return;
            await Navigation.PushAsync(new IlanDetayPage(ilan));

        }


        private async void ButtonPhone_Clicked(object sender, EventArgs e)
        {
            var ilan = (EmlakIlan)lstIlanlar.SelectedItem;
            if (ilan == null)
                return;
            await DisplayAlert("iletişime geçiliyor", $"Telefon: 📞 {ilan.IletisimTelefon}", "İptal");

        }

        private async void ButtonEmail_Clicked(object sender, EventArgs e)
        {
            var ilan = (EmlakIlan)lstIlanlar.SelectedItem;
            if (ilan == null)
                return;
            await DisplayAlert("iletişime geçiliyor", $"Email: 📧 {ilan.IletisimEmail}", "İptal");
        }

        private async void ButtonDetail_Clicked(object sender, EventArgs e)
        {
            var ilan = (EmlakIlan)lstIlanlar.SelectedItem;
            if (ilan == null)
                return;
            await Navigation.PushAsync(new IlanDetayPage(ilan));

        }
    }

}
