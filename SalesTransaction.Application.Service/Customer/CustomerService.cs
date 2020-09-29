using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.Customer;
using SalesTransaction.Application.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace SalesTransaction.Application.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly DataAccessHelper _da;
        private readonly int _commandTimeout;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;

            dynamic connectionString = _configuration.GetSection("ConnectionStrings");
            _connectionString = connectionString["DefaultConnection"];

            if (_connectionString != null)
            {
                _da = new DataAccessHelper(_connectionString);
            }
            _commandTimeout = Convert.ToInt32(connectionString["ConnectionTimeOut"]);
        }

        public dynamic AddCustomerDetail(MvAddCustomer customer)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpAddCusctomerIns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", customer.firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", customer.middleName);
                    cmd.Parameters.AddWithValue("@LastName", customer.lastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", customer.email);

                    //dynamic jsonew = JsonConvert.SerializeObject(customer);
                    //cmd.Parameters.Add("@Json", SqlDbType.NChar).Value = json;
                    //var cus = Convert.ToString(jsonew);
                    //cmd.Parameters.Add(new SqlParameter("@Json", customer));

                    // cmd.Parameters.AddWithValue("@Json",jsonew);
                    //cmd.Parameters.AddWithValue("@UserId", Convert.ToString(jsonnew.UserId));
                    // cmd.Parameters.AddWithValue("@UserName",login.UserName);
                    //cmd.Parameters.AddWithValue("@Password", login.Password);
                    //cmd.Parameters.AddWithValue("@Json", Json.ToString());

                    cmd.CommandTimeout = _commandTimeout;

                    result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { con.Close(); }
                //SqlDataReader dr = cmd.ExecuteReader();

                //dt.Load(dr);
                //return _da.GetJson(dr);
                //using (var dr = cmd.ExecuteReader())
                //{
                //    try
                //    {
                //        if (dr.HasRows)
                //        {
                //            return _da.GetJson(dr);
                //        }
                //        else
                //        {
                //            return null;
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //        throw ex;
                //    }
                //}

            }
        }

        public dynamic UpdateCustomerDetail(MvUpdateCustomer customer)
        {

            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpEditCustomerUpd", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@FirstName", customer.firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", customer.middleName);
                    cmd.Parameters.AddWithValue("@LastName", customer.lastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", customer.email);

                    cmd.CommandTimeout = _commandTimeout;

                    result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { con.Close(); }


            }
        }
    }
}
