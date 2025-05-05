using MauiAppApi.Services;

using System.Collections.ObjectModel;

namespace MauiAppApi;

public partial class HavaDurumuPage : ContentPage
{
	public HavaDurumuPage()
	{
		InitializeComponent();
	}

	public ObservableCollection<SehirHavaDurumu> Sehirler { get; set; } 
        = new ();

    private async void SehirEkle_Clicked(object sender, EventArgs e)
    {
		var sehir = await DisplayPromptAsync("Þehir Ekle", "Lütfen þehir ismini giriniz", "Tamam", "Ýptal");

		Sehirler.Add(new SehirHavaDurumu(sehir));

        lstSehirler.ItemsSource = Sehirler;
    }

    private void Update_Clicked(object sender, EventArgs e)
    {
        var seh = (sender as Button).CommandParameter as SehirHavaDurumu;
        // update buraya;
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var seh = (sender as Button).CommandParameter as SehirHavaDurumu;
        Sehirler.Remove(seh);
    }
}