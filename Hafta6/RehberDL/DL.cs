#define MYSQL

#if(MYSQL)
using MySql.Data.MySqlClient;
using DbConnection = MySql.Data.MySqlClient.MySqlConnection;
using DbCommand = MySql.Data.MySqlClient.MySqlCommand;
#elif(SQLSERVER)
using System.Data.SqlClient;
using DbConnection = System.Data.SqlClient.SqlConnection;
using DbCommand = System.Data.SqlClient.SqlCommand;
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
#else
        static string conString = new SqlConnectionStringBuilder()
        {
            
            
        }.ConnectionString;
#endif


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
    }
}
