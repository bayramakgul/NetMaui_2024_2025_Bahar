using System.ComponentModel;

namespace RehberEntity
{
    public class MyContact : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private string _email;
        private string _picture;
        private string _address;
        private DateTime _birthday;

        public MyContact() { }

        public MyContact(string name, string surname, string phoneNumber, string email=null, string picture="user.png", string address=null )
        {
            _name = name;
            _surname = surname;
            _phoneNumber = phoneNumber;
            _email = email;
            _picture = picture;
            _address = address;
            _birthday = DateTime.Now;
        }

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                    _id = Guid.NewGuid().ToString();

                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }

        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string FullName => Name + " " + Surname;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Picture
        {
            get { return _picture; }
            set
            {
                if (_picture != value)
                {
                    _picture = value;
                    OnPropertyChanged(nameof(Picture));
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public DateTime BirthDay
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged(nameof(BirthDay));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
