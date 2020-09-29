using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.Product;
using SalesTransaction.Application.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
namespace SalesTransaction.Application.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly DataAccessHelper _da;
        private readonly int _commandTimeout;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;



        public ProductService(IConfiguration configuration)
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

        public dynamic AddProductDetails(MvAddProduct product)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpAddProductIns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    cmd.Parameters.AddWithValue("@ProductRateId", product.ProductRateId);
                    cmd.Parameters.AddWithValue("@QuantityStock", product.QuantityStock);
                   

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

        public dynamic GetProductDetails()
        {
            using (var con = _da.GetConnection())
            {


                SqlCommand cmd = new SqlCommand("GetAllProduct", con);
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

        public dynamic UpdateProductDetails(MvUpdateProduct product)
        {
            using (var con = _da.GetConnection())
            {
                try
                {
                    int result = 0;
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SpEditProductUpd", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    cmd.Parameters.AddWithValue("@ProductRateId", product.ProductRateId);
                    cmd.Parameters.AddWithValue("@QuantityStock", product.QuantityStock);


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
