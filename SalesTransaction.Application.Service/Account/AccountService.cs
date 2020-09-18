using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SalesTransaction.Application.DataAccessLayer;
using SalesTransaction.Application.Model.Account;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SalesTransaction.Application.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly DataAccessHelper _da;
        private readonly int _commandTimeout;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        

        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;

            dynamic connectionString = _configuration.GetSection("ConnectionString");
            _connectionString = connectionString["DefaultConnection"];

            if (_connectionString != null)
            {
                _da = new DataAccessHelper(_connectionString);
            }
            _commandTimeout = Convert.ToInt32(connectionString["ConnectionTimeOut"]);
        }





        public dynamic GetLogin(MvLogin login)
        {
            using(var con = _da.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SpUserTableSel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", login.UserName);
                cmd.Parameters.AddWithValue("@Password", login.Password);
                cmd.CommandTimeout = _commandTimeout;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    try
                    {
                        if(dr.HasRows)
                        {
                            return _da.GetJson(dr);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }



           
        }

        public dynamic GetUserDetail(string Json)
        {

            using (var con = _da.GetConnection())
            {
                dynamic jsonnew = JsonConvert.DeserializeObject(Json);

                SqlCommand cmd = new SqlCommand("SpCustomerSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Json",Json.ToString());


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    try
                    {
                        if (dr.HasRows)
                        {
                            return _da.GetJson(dr);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }



            
        }
    }
}
