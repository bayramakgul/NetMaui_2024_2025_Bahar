
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiAppTodo.Model
{
    public class MyTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private string id, title, detail, firstName, lastName;
        private bool isCompleted;
        public DateTime startDate;
        public DateTime endDate;

        public string ID
        {
            get{if (string.IsNullOrEmpty(id))
                    id = Guid.NewGuid().ToString();

                return id;
            } 
            set{ id = value;
                NotifyPropertyChanged();
            }
        }

        public string Title {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value;
                NotifyPropertyChanged();
            }
        }

        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                NotifyPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FullName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FullName");
            }
        }

        [JsonIgnore]
        public string FullName => FirstName + " " + LastName;

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("DateInterval");

            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("DateInterval");
            }
        }

        [JsonIgnore]
        public string DateInterval =>
            "📅 " + StartDate.ToString("dd/MM/yyyy") + " - " + EndDate.ToString("dd/MM/yyyy");

        public string ToString()
        {
            return $"Task: {Title}\n" +
                $"Details: {Detail}\n" +
                $"Assigned To: {FullName}\n" +
            $"Interval: {StartDate.ToString("dd/MM/yyyy")} - {EndDate.ToString("dd/MM/yyyy")}\n" +
            $"Completed: {IsCompleted}\n";
        }

    }
}
