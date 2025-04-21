using RehberEntity;

using System.Threading.Tasks;

namespace MauiRehberUI;

public partial class ContactDetails : ContentPage
{
    public Action<MyContact> PictureSelector;
    public TaskCompletionSource<bool> SaveTaskCompletion { get; } = new TaskCompletionSource<bool>();
    public MyContact Contact => BindingContext as MyContact;

	public ContactDetails(MyContact contact)
	{
		InitializeComponent();
		this.BindingContext = contact;
    }

    private void OkClicked(object sender, EventArgs e)
    {
        SaveTaskCompletion.SetResult(true); // or false if cancelled
        Navigation.PopModalAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        SaveTaskCompletion.SetResult(false); // or false if cancelled
        Navigation.PopModalAsync();
    }

    private async void AddImage_Clicked(object sender, EventArgs e)
    {
        PictureSelector(Contact);
    }
}