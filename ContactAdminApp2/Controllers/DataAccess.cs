using ContactAdminApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public static class DataAccess
    {

        static string connStr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        public static DataTable GetDataTable(int id = -1)
        {
            //DataSet ds1 = new DataSet();
            DataTable table1 = new DataTable();
            // table1.PrimaryKey = new DataColumn[] { table1.Columns["Id"] };
            //ds1.Tables.Add(table1);
            String SqlScript = "";
            if (id == -1)
                SqlScript = "Select Id,FirstName, LastName, Email, Phone, BirthDate, ProfilePictureUrl, IsFamily, IsFriend, IsColleague, IsAssociate, Comments from Contacts";
            else
                SqlScript = "Select Id,FirstName, LastName, Email, Phone, BirthDate, ProfilePictureUrl, IsFamily, IsFriend, IsColleague, IsAssociate, Comments from Contacts where Id ="
                    + id.ToString(); ;

            // String SqlScript = "Select * from Contacts";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(SqlScript, con);

                try
                {
                    adapter.Fill(table1);
                }
                catch (SqlException ex)
                {

                    string sError = ex.Message;
                }
                finally
                {
                    con.Close();
                    adapter.Dispose();
                }

                return table1;

            }

        }

        public static int Update(ContactVM contact)
        {
            String SqlScript   = "update Contacts set FirstName = '" + contact.FirstName
                       + "', LastName ='"  + contact.LastName
                       + "', Email = '" + contact.Email
                       + "', Phone = '" + contact.Phone
                       + "', BirthDate ='" + contact.BirthDate
                       + "', ProfilePictureUrl ='" + contact.ProfilePictureUrl
                       + "', IsFamily ='" + contact.IsFamily
                       + "', IsFriend ='" + contact.IsFriend
                       + "', IsColleague ='" + contact.IsColleague
                       + "', IsAssociate ='" + contact.IsAssociate
                       + "', Comments ='" + contact.Comments
                       + "' where Id = " + contact.Id;

            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand thisCommand = con.CreateCommand();

            thisCommand.CommandText = SqlScript;
            int success = thisCommand.ExecuteNonQuery();

            con.Close();
            return success;
        }

        public static int Insert (ContactVM contact)
        {
            String SqlScript = "Insert Into Contacts ( FirstName,LastName ,Email,Phone,BirthDate,ProfilePictureUrl,isFamily, isFriend, isColleague, isAssociate,Comments) values ('"
                       + contact.FirstName
                       + "','"  + contact.LastName
                       + "','" + contact.Email
                       + "','" + contact.Phone
                       + "','" + contact.BirthDate
                       + "','" + contact.ProfilePictureUrl
                       + "','"  + contact.IsFamily
                       + "','" + contact.IsFriend
                       + "','" + contact.IsColleague
                       + "','" + contact.IsAssociate
                       + "','" + contact.Comments
                       +"');" ;
        
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand thisCommand = con.CreateCommand();

            thisCommand.CommandText = SqlScript;
            int success = thisCommand.ExecuteNonQuery();

            con.Close();
            return success;
        }

        public static int Delete(int Id)
        {
            String SqlScript = "Delete from  Contacts where Id = " + Id.ToString();
                     

            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand thisCommand = con.CreateCommand();

            thisCommand.CommandText = SqlScript;
            int success = thisCommand.ExecuteNonQuery();

            con.Close();
            return success;
        }
    }
}