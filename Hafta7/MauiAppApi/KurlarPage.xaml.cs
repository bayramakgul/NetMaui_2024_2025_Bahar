using MauiAppApi.Services;

namespace MauiAppApi;

public partial class KurlarPage : ContentPage
{
	public KurlarPage()
	{
		InitializeComponent();
	}



	private async void RefreshView_Refreshing_KurBilgileri(object sender, EventArgs e)
	{
		var Kurlar = await KurServisi.GetKurBilgileri();
		lstKurlar.ItemsSource = Kurlar;
		refreshView.IsRefreshing = false;
	}
}