using RehberBL;

namespace MauiRehberUI;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}



	private void ShowOtherStack_Clicked(object sender, EventArgs e)
	{
		if(loginStack.IsVisible)
		{
			loginStack.IsVisible = false;
			registerStack.IsVisible = true;
		}
		else
		{
			loginStack.IsVisible = true;
			registerStack.IsVisible = false;
		}
	}

	private async void Register_Clicked(object sender, EventArgs e)
	{
		var res = await BL.Register(EmailRegister.Text, PasswordRegister.Text, DisplayNameRegister.Text);


		DisplayAlert(Title, res.message, "Tamam");

	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		var res = await BL.Login(EmailLogin.Text, PasswordLogin.Text);

		if (!res.ok)
			DisplayAlert(Title, res.message, "Tamam");

		else
			Navigation.PushModalAsync(new MainPage());

	}
}