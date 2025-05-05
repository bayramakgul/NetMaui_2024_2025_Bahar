#define FIREBASE

#if(MYSQL)
using MySql.Data.MySqlClient;
using DbConnection = MySql.Data.MySqlClient.MySqlConnection;
using DbCommand = MySql.Data.MySqlClient.MySqlCommand;
#elif(SQLSERVER)
using System.Data.SqlClient;
using DbConnection = System.Data.SqlClient.SqlConnection;
using DbCommand = System.Data.SqlClient.SqlCommand;

#elif FIREBASE
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;
#endif

using RehberEntity;

using System.Collections.ObjectModel;
using System.Xml.Linq;



namespace RehberDL
{
    public class DL
    {

#if (MYSQL)
        static string conString = new MySqlConnectionStringBuilder()
        {
            Database = "maui_rehber",
            Server = "localhost", // windows harici ise buraya server ip'si gelmeli
            UserID = "root",
            Password = "wfnxy123",
            Port = 3306,
            SslMode = MySqlSslMode.Disabled,
        }.ConnectionString;
#elif (SQLSERVER)
        static string conString = new SqlConnectionStringBuilder()
        {
            
            
        }.ConnectionString;

#elif (FIREBASE)
        static string conString = "https://mycontacts2025-2defa-default-rtdb.firebaseio.com/";
       static FirebaseClient client = new FirebaseClient(conString);

        static string apiKey = "AIzaSyAt9xTPUj2UKIugetMLerZsEKH8yiq0z9c";
        static string projectId => "mycontacts2025-2defa";
        static string AuthDomain = $"{projectId}.firebaseapp.com";

        static FirebaseAuthConfig authConfig = new FirebaseAuthConfig
        {
            ApiKey = apiKey,
            AuthDomain = AuthDomain,
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        };



        public static bool AddContact(MyContact contact, ref string message)
        {

            try
            {
                var result = client
                    .Child($"contacts/{contact.ID}")
                    .PutAsync(contact);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool EditContact(MyContact contact, ref string message)
        {
            try
            {
                var result = client
                    .Child($"contacts/{contact.ID}")
                    .PutAsync(contact);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool RemoveContact(MyContact contact, ref string message)
        {
            try
            {
                var result = client
                    .Child($"contacts/{contact.ID}")
                    .DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool LoadContacts(ObservableCollection<MyContact> contacts, ref string message)
        {
            try
            {
                var result = client
                    .Child("contacts")
                    .OnceAsync<MyContact>().Result;
                foreach (var item in result)
                {
                    contacts.Add(item.Object);
                }
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }


        //public static bool Register(string email, string password, string displayName, ref string message)
        //{
        //    var client = new FirebaseAuthClient(authConfig);
        //    try
        //    {
        //        var res = client.CreateUserWithEmailAndPasswordAsync(email, password, displayName);
        //        if (res.Exception != null)
        //        {
        //            message = res.Exception.Message;
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool Login(string email, string password, ref string message)
        //{
        //    try
        //    {
        //        var client = new FirebaseAuthClient(authConfig);
        //        var res = client.SignInWithEmailAndPasswordAsync(email, password);
        //        return res.Result.User != null;
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //        return false;
        //    }
        //}


        public static async Task<(bool ok, string message)> Register(string email, string password, string displayName)
        {
            try
            {
                var client = new FirebaseAuthClient(authConfig);
                var result = await client.CreateUserWithEmailAndPasswordAsync(email, password, displayName);

                // Kullanıcının ismi güncellenmemiş olabilir, gerekirse tekrar ayarla
                var user = result.User;
                string message = "Kayıt başarılı.";
                return (true, message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public static async Task<(bool ok, string message)> Login(string email, string password)
        {
            try
            {
                var client = new FirebaseAuthClient(authConfig);
                var result = await client.SignInWithEmailAndPasswordAsync(email, password);
                string message = "";

                if (result.User != null)
                {
                    message = "Giriş başarılı.";
                    return (true, message);
                }

                message = "Giriş başarısız.";
                return (false, message);
            }
            catch (Exception ex)
            {
                return (false,  ex.Message);
            }
        }




#endif


#if (FIREBASE)


#else

        public static bool AddContact(MyContact contact, ref string message)
        {
            using (DbConnection connection = new DbConnection(conString))
            {
                connection.Open();
                string query = "INSERT INTO " +
                    "myContacts (cid, cname, csurname, cphone, cemail, cpicture, caddress, cbirthday) " +
                    "VALUES (@id, @nm, @sr, @ph, @em, @pc, @ad, @br)";
                DbCommand command = new DbCommand(query, connection);

                command.Parameters.AddWithValue("@id", contact.ID);
                command.Parameters.AddWithValue("@nm", contact.Name);
                command.Parameters.AddWithValue("@sr", contact.Surname);
                command.Parameters.AddWithValue("@ph", contact.PhoneNumber);
                command.Parameters.AddWithValue("@em", contact.Email);
                command.Parameters.AddWithValue("@pc", contact.Picture);
                command.Parameters.AddWithValue("@ad", contact.Address);
                command.Parameters.AddWithValue("@br", contact.BirthDay);
                try
                {
                    int ret = command.ExecuteNonQuery();
                    return ret > 0;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }

        }

        public static bool EditContact(MyContact contact, ref string message)
        {
            using (DbConnection connection = new DbConnection(conString))
            {
                connection.Open();
                string query = 
                    "UPDATE myContacts SET " +
                            " cname=@nm, " +
                            " csurname=@sr, " +
                            " cphone=@ph, " +
                            " cemail=@em, " +
                            " cpicture=@pc, " +
                            " caddress=@ad, " +
                            " cbirthday=@br " +
                    "WHERE cid=@id";
                DbCommand command = new DbCommand(query, connection);

                command.Parameters.AddWithValue("@nm", contact.Name);
                command.Parameters.AddWithValue("@sr", contact.Surname);
                command.Parameters.AddWithValue("@ph", contact.PhoneNumber);
                command.Parameters.AddWithValue("@em", (object)contact.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@pc", (object)contact.Picture ?? DBNull.Value);
                command.Parameters.AddWithValue("@ad", (object)contact.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@br", contact.BirthDay);
                command.Parameters.AddWithValue("@id", contact.ID);
                try
                {
                    int ret = command.ExecuteNonQuery();
                    return ret > 0;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public static bool LoadContacts( ObservableCollection<MyContact> contacts, ref string message)
        {
            using (DbConnection connection = new DbConnection(conString))
            {
                connection.Open();
                string query = "SELECT * FROM  myContacts";
                DbCommand command = new DbCommand(query, connection);

                try
                {
                    var dr = command.ExecuteReader();
                    while (dr.Read())
                    {

                        /*
                         Table: mycontacts
                        Columns:
                        cid         varchar(64) PK 
                        cname       varchar(100) 
                        csurname    varchar(100) 
                        cphone      varchar(25) 
                        cemail      varchar(250) 
                        cpicture    varchar(250) 
                        caddress    varchar(250) 
                        cbirthday   datetime
                         */
                        contacts.Add(new MyContact()
                        {
                            ID          = dr["cid"].ToString(),
                            Name        = dr["cname"].ToString(),
                            Surname     = dr["csurname"].ToString(),
                            PhoneNumber = dr["cphone"].ToString(),
                            Email       = dr["cemail"].ToString(),
                            Picture     = dr["cpicture"].ToString(),
                            Address     = dr["caddress"].ToString(),
                            BirthDay    = DateTime.Parse(dr["cbirthday"].ToString()),
                        });

                    }
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public static bool RemoveContact(MyContact contact, ref string message)
        {
            using (DbConnection connection = new DbConnection(conString))
            {
                connection.Open();
                string query =
                    "DELETE FROM myContacts WHERE cid=@id";
                DbCommand command = new DbCommand(query, connection);

                command.Parameters.AddWithValue("@id", contact.ID);
                try
                {
                    int ret = command.ExecuteNonQuery();
                    return ret > 0;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }
#endif

    }
}
