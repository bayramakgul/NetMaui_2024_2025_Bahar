using MauiAppTodo.Model;

using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppTodo
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<MyTask> myTasks = new (){
         new MyTask()
         {
            Title = "Çimler Sulanacak",
            Detail = "Çimler hergün akşam 17:00'dan 18:00'a kadar sulanmalıdır.",
            IsCompleted = false,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            FirstName = "John",
            LastName = "Doe"
         },
         new MyTask()
         {
            Title = "Ev Temizlenecek",
            Detail = "Ev hergün akşam 17:00'dan 18:00'a kadar temizlenmelidir.",
            IsCompleted = false,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            FirstName = "Alice",
            LastName = "Blue"
         },

         new MyTask()
         {
             Title = "Pazar Alışverişi",
             Detail = "Pazar alışverişi her hafta salı ve cuma günleri öğleden sonra 14:00'dan 16:00'a kadar yapılmalıdır.",
                IsCompleted = false,
                StartDate = new DateTime(2025,4,15),
                EndDate = new DateTime(2026,4,15),
                FirstName = "Bob",
                LastName = "Green"
         }
        };

        string fileName => Path.Combine(FileSystem.AppDataDirectory, "myTasks.json");

        public MainPage()
        {
            InitializeComponent();

            // Load myTask list from json file
            if (File.Exists(fileName))
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        myTasks = JsonSerializer.Deserialize<ObservableCollection<MyTask>>(json);
                    }
                }
            }

            listTasks.ItemsSource = myTasks;
        }

        private void ButtonDetail_Clicked(object sender, EventArgs e)
        {
            var task= (sender as Button).CommandParameter as MyTask; 

            var page = new TodoDetailPage(task);
            Navigation.PushAsync(page);
        }

        private void AddNewTask_Click(object sender, EventArgs e)
        {
            var task = new MyTask();
            var page = new TodoDetailPage(task);
            Navigation.PushAsync(page);
            myTasks.Add(task);

        }

        private void Save_Click(object sender, EventArgs e)
        {
            //save myTask list to json file
            var json = JsonSerializer.Serialize(myTasks);
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }

        }



        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            var task= (sender as Button).CommandParameter as MyTask;
            var res= await  DisplayAlert("Sil", "Görevi silmek istediğinize emin misiniz?", "Evet", "Hayır");

            if(res == true)
            {
                myTasks.Remove(task);
            }

        }

        private async void Share_Click(object sender, EventArgs e)
        {
            await Share.Default.RequestAsync(new ShareFileRequest
            {
                Title = "Görevlerim",
                File = new ShareFile(fileName)
            });

            //string text =  File.ReadAllText(fileName);

            //await Share.Default.RequestAsync(new ShareTextRequest() { 
            //    Title = "Görevlerim",
            //    Text = text,
            //   });
        }

        private async void ButtonShare_Clicked(object sender, EventArgs e)
        {
            var task= (sender as Button).CommandParameter as MyTask;
            await Share.Default.RequestAsync(new ShareTextRequest()
            {
                Title = "Görevlerim",
                Text = task.ToString(),
            });
        }
    }

}
