namespace MauiAppLayouts;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	// login olma iþlemleri buraya yazýlacak
    private void Login_Clicked(object sender, EventArgs e)
    {

    }

    // kaydolma iþlemleri burada yapýlacak
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