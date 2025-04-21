using RehberDL;

using RehberEntity;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RehberBL
{
    public static class BL
    {
        public static ObservableCollection<MyContact> Contacts;

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

        public static bool LoadContacts(ref string message)
        {
            if (Contacts == null)
                Contacts = new ObservableCollection<MyContact>();

            if (DL.LoadContacts(Contacts, ref message))
                return true;

            return false;
            
        }
    }
}
