namespace MauiAppEmlak;

public partial class IlanDetayPage : ContentPage
{
	public IlanDetayPage(EmlakIlan ilan )
	{
		InitializeComponent();
		this.BindingContext = ilan;
		lstResim.ItemsSource = ilan.ResimLinkleri;

		if (lstResim.ItemsSource != null && ilan.ResimLinkleri.Count > 0)
			lstResim.SelectedItem = ilan.ResimLinkleri[0];
    }
}