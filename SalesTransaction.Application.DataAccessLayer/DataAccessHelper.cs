using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace SalesTransaction.Application.DataAccessLayer
{
   
 
  public  class DataAccessHelper
    {
        SqlConnection conn = new SqlConnection(ConnectionClass.ConnectionString);

        public DataTable Login(string UserName, string Password)
        {
            try
            {
                conn.Close();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from UserTable where UserName=@UserName and Password=@Password", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            }


        }

    }

