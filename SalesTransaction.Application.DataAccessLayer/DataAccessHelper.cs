using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SalesTransaction.Application.DataAccessLayer
{


    public class DataAccessHelper
    {

        private SqlConnection _cn;
        private string _cnString;
        public DataAccessHelper(string connectionString)
        {
            _cnString = connectionString;
        }



        public SqlConnection GetConnection()
        {
            try
            {
                setConnection();
                return _cn;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void setConnection()
        {
            _cn = new SqlConnection(_cnString);
            if (_cn.State == ConnectionState.Closed)
            {
                _cn.Close();
            }
            else
            {
                _cn.Close();
                _cn.Open();
            }
        }



        public dynamic GetJson(SqlDataReader reader)
        {
            var datatable = new DataTable();
            datatable.Load(reader);

            if (datatable.Rows[0] != null && datatable.Rows[0]["Json"].ToString() != "")
            {
                return JsonConvert.DeserializeObject(datatable.Rows[0]["Json"].ToString());
            }
            else
            {
                return null;
            }

        }
    }
}






            //SqlConnection conn = new SqlConnection("Data Source=10.6.0.246;Initial Catalog=Kedar;Persist Security Info=True;User ID=intern;Password=intern001");




            //public DataTable Login(string UserName, string Password)
            //{
            //    try
            //    {
            //        conn.Close();
            //        DataTable dt = new DataTable();
            //        SqlCommand cmd = new SqlCommand("select * from UserTable where UserName=@UserName and Password=@Password", conn);
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@UserName", UserName);
            //        cmd.Parameters.AddWithValue("@Password", Password);
            //        conn.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        dt.Load(dr);
            //        conn.Close();
            //        return dt;
            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }

            //    }


            //}

        

