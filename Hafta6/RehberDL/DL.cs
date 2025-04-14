using RehberEntity;

namespace RehberDL
{
    public class DL
    {
        public static bool AddContact(MyContact contact, ref string message)
        {
            return true;
        }

        public static bool EditContact(MyContact contact, ref string message)
        {
            return true;
        }

        public static bool RemoveContact(MyContact contact, ref string message)
        {
            message = "veritabanı bağlantı hatası!";
            return false;
        }
    }
}
