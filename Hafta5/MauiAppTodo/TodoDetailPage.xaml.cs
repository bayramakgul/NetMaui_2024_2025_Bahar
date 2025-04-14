using MauiAppTodo.Model;

namespace MauiAppTodo;

public partial class TodoDetailPage : ContentPage
{
	public TodoDetailPage(MyTask task)
	{
		InitializeComponent();

		this.Content.BindingContext = task;
    }
}