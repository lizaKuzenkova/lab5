using lab5.Views.Students;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace lab5.Data {
    internal class StudentDAO {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDBLab5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<StudentModel> FetchAll() {
            List<StudentModel> returnList = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlQuery = "select * from dbo.StudentsLab5";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        StudentModel student = new StudentModel();
                        student.Id = reader.GetInt32(0);
                        student.lastname = reader.GetString(1);
                        student.firstname = reader.GetString(2);
                        student.groupnum = reader.GetInt32(3);
                        student.missedhours = reader.GetInt32(4);

                        returnList.Add(student);
                    }
                }
            }
            return returnList;
        }

        internal int Delete(int id) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlQuery = "delete from dbo.StudentsLab5 " +
                         "where Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }
        }

        internal List<StudentModel> SerachForName(string searchPhrase) {
            List<StudentModel> returnList = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlQuery = "select * from dbo.StudentsLab5 " +
                    "where firstname like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = searchPhrase + "%";

                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        StudentModel student = new StudentModel();
                        student.Id = reader.GetInt32(0);
                        student.lastname = reader.GetString(1);
                        student.firstname = reader.GetString(2);
                        student.groupnum = reader.GetInt32(3);
                        student.missedhours = reader.GetInt32(4);

                        returnList.Add(student);
                    }
                }
            }
            return returnList;
        }

        internal List<StudentModel> SerachForLastname(string searchPhrase) {
            List<StudentModel> returnList = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlQuery = "select * from dbo.StudentsLab5 " +
                    "where lastname like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = searchPhrase + "%";


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        StudentModel student = new StudentModel();
                        student.Id = reader.GetInt32(0);
                        student.lastname = reader.GetString(1);
                        student.firstname = reader.GetString(2);
                        student.groupnum = reader.GetInt32(3);
                        student.missedhours = reader.GetInt32(4);

                        returnList.Add(student);
                    }
                }
            }
            return returnList;
        }

        public StudentModel FetchOne(int Id) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string sqlQuery = "select * from dbo.StudentsLab5 " +
                    "where Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                StudentModel student = new StudentModel();

                if (reader.HasRows) {
                    while (reader.Read()) {                       
                        student.Id = reader.GetInt32(0);
                        student.lastname = reader.GetString(1);
                        student.firstname = reader.GetString(2);
                        student.groupnum = reader.GetInt32(3);
                        student.missedhours = reader.GetInt32(4);
                    }
                }
                return student;
            }            
        }

        public int CreateOrUpdate(StudentModel studentModel) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {

                string sqlQuery = "";

                if (studentModel.Id <= 0) {
                    sqlQuery = "insert into dbo.StudentsLab5 " +
                        "values (@lastname, @firstname, @groupnum, @missedhours)";
                } else {
                    sqlQuery = "update dbo.StudentsLab5 " +
                        "set lastname = @lastname, " +
                        "firstname = @firstname, " +
                        "groupnum = @groupnum, " +
                        "missedhours = @missedhours " +
                        "where Id = @Id";

                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = studentModel.Id;
                command.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 1000).Value = studentModel.lastname;
                command.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 1000).Value = studentModel.firstname;
                command.Parameters.Add("@groupnum", System.Data.SqlDbType.Int).Value = studentModel.groupnum;
                command.Parameters.Add("@missedhours", System.Data.SqlDbType.Int).Value = studentModel.missedhours;

                connection.Open();
                int newID = command.ExecuteNonQuery();
                
                return newID;
            }
        }
    }
}