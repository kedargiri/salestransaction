using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.ProductRate;
using SalesTransaction.Application.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace SalesTransaction.Application.Service.ProductRate
{
   public class ProductRateService :IProductRateService
 {
        private readonly DataAccessHelper _da;
        private readonly int _commandTimeout;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;



        public ProductRateService(IConfiguration configuration)
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

        public dynamic AddProductRateDetails(MvAddProductRate productRate)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpAddProductRateIns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductRate", productRate.productRate);
                    cmd.Parameters.AddWithValue("@StartDate", productRate.startDate);
                    cmd.Parameters.AddWithValue("@EndDate", productRate.endDate);
                    
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

        public dynamic GetProductRateDetails()
        {
            using (var con = _da.GetConnection())
            {


                SqlCommand cmd = new SqlCommand("GetAllProductRate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //dynamic jsonnew = JsonConvert.DeserializeObject();
                //cmd.Parameters.AddWithValue("@UserId", Convert.ToString(jsonnew.UserId));


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

        public dynamic UpdateProductRateDetails(MvUpdateProductRate productRate)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpEditProductRateIns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ProductRateId", productRate.productRateId);
                    cmd.Parameters.AddWithValue("@ProductRate", productRate.productRate);
                    cmd.Parameters.AddWithValue("@StartDate", productRate.startDate);
                    cmd.Parameters.AddWithValue("@EndDate", productRate.endDate);

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
