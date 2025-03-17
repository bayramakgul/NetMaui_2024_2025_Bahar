namespace MauiAppLayouts;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
		cicek.Source = "https://cdn03.ciceksepeti.com/cicek/at5679-1/L/at5679-1-8dd24eadb2c6863-98eef42e.jpg";
    }
}