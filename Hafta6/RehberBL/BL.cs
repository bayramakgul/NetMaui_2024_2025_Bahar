using RehberDL;

using RehberEntity;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RehberBL
{
    public static class BL
    {
        public static ObservableCollection<MyContact> Contacts = new ObservableCollection<MyContact>
        {
            new MyContact("Ali", "Kara", "045565665", "alikara@mail.com" ),
            new MyContact("Ayşe", "Sarı", "646546546", "aysesari@mail.com"),
            new MyContact("Veli", "Beyaz", "056655445", "velibeyaz@mail.com"),
        };

        public static bool AddContact(MyContact contact, ref string message)
        {
            if (DL.AddContact(contact, ref message))
            {
                Contacts.Add(contact);
                return true;
            }

            return false;
        }

        public static bool EditContact(MyContact contact, ref string message)
        {
            if (DL.EditContact(contact, ref message))
            {
                //Contacts.Add(contact);
                return true;
            }

            return false;
        }

        public static bool RemoveContact(MyContact contact, ref string message)
        {
            if (DL.RemoveContact(contact, ref message))
            {
                Contacts.Remove(contact);
                return true;
            }

            return false;

        }
    }
}
