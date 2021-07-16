using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EHI_API.Models;
namespace EHI_API.Db
{
    public class DatabaseManager
    {
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlCommand cmd;
        public DataTable dt;
        public int result;

        public SqlConnection GetConnection()
        {
            try {
                string cstr = ConfigurationManager.ConnectionStrings["cs"].ToString();
                conn = new SqlConnection(cstr);
                conn.Open();
                return conn;
            }
            catch (Exception ex) {
                conn = null;
                return conn;
            }
        }

        public DataTable getList()
        {
            try
            {
                conn = GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetContacts";
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex) {
                dt = null;
                return dt;
            }
        }

        public int Save(Contact contact)
        {
            try
            {
                conn = GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaveContact";
                cmd.Parameters.AddWithValue("@firstname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lastname",contact.LastName);
                cmd.Parameters.AddWithValue("@email", contact.FirstName);
                cmd.Parameters.AddWithValue("@phonenumber", contact.LastName);
                cmd.Parameters.AddWithValue("@status", contact.LastName);
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int Update(Contact contact)
        {
            try
            {
                conn = GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updatemployee";
                cmd.Parameters.AddWithValue("@firstname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lastname",contact.FirstName);
                cmd.Parameters.AddWithValue("@email", contact.FirstName);
                cmd.Parameters.AddWithValue("@phonenumber", contact.FirstName);
                cmd.Parameters.AddWithValue("@status", contact.FirstName);
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int Delete(Contact contact)
        {
            try
            {
                conn = GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "deleteemployee";
                cmd.Parameters.AddWithValue("@id", contact.Id);  
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}