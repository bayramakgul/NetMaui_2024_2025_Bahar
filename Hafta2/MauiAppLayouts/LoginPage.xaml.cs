namespace MauiAppLayouts;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	// login olma i�lemleri buraya yaz�lacak
    private void Login_Clicked(object sender, EventArgs e)
    {

    }

    // kaydolma i�lemleri burada yap�lacak
    private void Register_Clicked(object sender, EventArgs e)
    {

    }

    private void ShowRegisterStack_Clicked(object sender, EventArgs e)
    {
        registerStack.IsVisible = true;
        loginStack.IsVisible = false;
    }

    private void ShowLoginStack_Clicked(object sender, EventArgs e)
    {
        registerStack.IsVisible = false;
        loginStack.IsVisible = true;

    }
}