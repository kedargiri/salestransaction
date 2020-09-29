using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.SalesTransaction;
using SalesTransaction.Application.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using SalesTransaction.Application.Service.SalesTransaction;


namespace SalesTransaction.Application.Service.Sales
{
    public class SalesTransactionService : ISalesTransactionService
    {

        private readonly DataAccessHelper _da;
        private readonly int _commandTimeout;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public SalesTransactionService(IConfiguration configuration)
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






        public dynamic AddSalesTransaction(AddSalesTransaction sales)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpAddSalesTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", sales.customerId);
                    cmd.Parameters.AddWithValue("@ProductId", sales.productId);
                    cmd.Parameters.AddWithValue("@ProductRateId", sales.productRateId);
                    cmd.Parameters.AddWithValue("@Quantity", sales.Quantity);
                    cmd.Parameters.AddWithValue("@Rate", sales.rate);
                    

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

        public dynamic GetAllSalesTransaction()
        {
            throw new NotImplementedException();
        }

        public dynamic UpdateSalesTransaction(UpdateSalesTransaction sales)
        {

            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpUpdateSalesTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalesTransactionId", sales.SalesTransactionId);
                    cmd.Parameters.AddWithValue("@CustomerId", sales.customerId);
                    cmd.Parameters.AddWithValue("@ProductId", sales.productId);
                    cmd.Parameters.AddWithValue("@ProductRateId", sales.productRateId);
                    cmd.Parameters.AddWithValue("@Quantity", sales.Quantity);
                    cmd.Parameters.AddWithValue("@Rate", sales.rate);


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
