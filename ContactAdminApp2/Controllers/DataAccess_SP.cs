using ContactAdminApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using log4net;

namespace DAL
{
    public class DataAccess_SP
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        private static ILog logger = LogManager.GetLogger("SystemLog");

        public static DataTable GetDataTable(int id = -1)
        {
               
            logger.Info("come to ataAccess_SP --- GetDataTable");
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    // Create the command and set its properties.
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "getContact";
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the input parameter and set its properties.
                    if (id != -1)
                    {
                        SqlParameter parameter = new SqlParameter();
                        parameter.ParameterName = "@id";
                        parameter.SqlDbType = SqlDbType.Int;
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = id;
                        command.Parameters.Add(parameter);
                    }

                    // Open the connection and execute the reader.
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    dt.Load(dr);
                    dr.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public static DataTable SearchDataTable(string searchText = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "searchContacts";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties.
                if (searchText != "")
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@searchFirstName";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = searchText;
                    command.Parameters.Add(parameter);
                }

                // Open the connection and execute the reader.
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            return dt;
        }


        public static int Update(ContactVM contact)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "updateContact";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@firstName";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.FirstName;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@lastName";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.LastName;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@email";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.Email;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@phone";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.Phone == null) parameter.Value = DBNull.Value;
                else parameter.Value = contact.Phone;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@birthDate";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                parameter.Value = contact.BirthDate;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@profilePictureUrl";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.ProfilePictureUrl == null) parameter.Value = DBNull.Value;
                else
                    parameter.Value = contact.ProfilePictureUrl;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isFamily";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsFamily;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isFriend";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsFriend;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isColleague";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsColleague;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isAssociate";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsAssociate;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@comments";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.Comments == null) parameter.Value = DBNull.Value;
                else
                    parameter.Value = contact.Comments;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = contact.Id;
                command.Parameters.Add(parameter);

                // thisCommand.CommandText = SqlScript;
                int success = command.ExecuteNonQuery();

                con.Close();
                return success;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }


        public static int Insert(ContactVM contact)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "insertContact";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@firstName";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.FirstName;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@lastName";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.LastName;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@email";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = contact.Email;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@phone";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.Phone == null) parameter.Value = DBNull.Value;
                else parameter.Value = contact.Phone;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@birthDate";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                parameter.Value = contact.BirthDate;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@profilePictureUrl";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.ProfilePictureUrl == null) parameter.Value = DBNull.Value;
                else
                    parameter.Value = contact.ProfilePictureUrl;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isFamily";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsFamily;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isFriend";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsFriend;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isColleague";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsColleague;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@isAssociate";
                parameter.SqlDbType = SqlDbType.Bit;
                parameter.Value = contact.IsAssociate;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@comments";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.IsNullable = true;
                if (contact.Comments == null) parameter.Value = DBNull.Value;
                else
                    parameter.Value = contact.Comments;

                command.Parameters.Add(parameter);

                // thisCommand.CommandText = SqlScript;
                int success = command.ExecuteNonQuery();

                con.Close();
                return success;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public static int Delete(int Id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "deleteContact";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = Id;
                command.Parameters.Add(parameter);

                int success = command.ExecuteNonQuery();

                con.Close();
                return success;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }

        }

  }
}