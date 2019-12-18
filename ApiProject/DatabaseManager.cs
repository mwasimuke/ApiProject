using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ApiProject
{
    public class DatabaseManager
    {
        public SqlConnection connect;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public SqlDataReader reader;

        public  static string showName;
        public static int showAge;
        public static string showLocation;
        public static string showCountry;

        public void ConnectDB()
        {
            connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApiDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        public string InsertIdentities(string name, int age, string location ,string country)
        {

            connect.Open();

            command = new SqlCommand("INSERT INTO ApiTable (Name,Age,Location ,Country) values ('" + name + "' , '" + age + "' , '" + location + "', '" + country + "')", connect);
            if (command.ExecuteNonQuery() == 1)
            {
                command.Dispose();
                connect.Close();
                return "Saved";

            }
            else
            {
                command.Dispose();
                connect.Close();
                return "Data not Saved";
            }
        }

        public string ShowIdentities(int id)
        {
            connect.Open();
            command = new SqlCommand("select * FROM ApiTable where id = '" + id + "' ", connect);

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                showName = reader.GetString(1);
                showAge = reader.GetInt32(2);
                showLocation = reader.GetString(3);
                showCountry = reader.GetString(3);

                command.Dispose();
                connect.Close();
                return "Data is set";
            }




            command.Dispose();
            connect.Close();
            return "Data not set";

        }

    }
}