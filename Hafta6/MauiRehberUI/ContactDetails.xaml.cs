using RehberEntity;

namespace MauiRehberUI;

public partial class ContactDetails : ContentPage
{
	public ContactDetails(MyContact contact)
	{
		InitializeComponent();
		this.BindingContext = contact;
    }

    public bool Result = false;

    private void OkClicked(object sender, EventArgs e)
    {
        Result = true;
        Navigation.PopModalAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Result = false;
        Navigation.PopModalAsync();
    }
}