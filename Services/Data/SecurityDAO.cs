using lab5.Models;
using System;
using System.Data.SqlClient;

namespace lab5.Services.Data {
    public class SecurityDAO {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user) {
            bool success = false;

            string queryString = "select * from dbo.Users " +
                "where username = @Username and password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
            
                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) {
                        success = true;
                    } else {
                        success = false;
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}