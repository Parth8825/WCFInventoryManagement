using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class CustomerDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        public List<CustomerBO> GetCustomerData()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            List<CustomerBO> customer = new List<CustomerBO>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SelectCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CustomerBO customers = new CustomerBO();
                        customers.CustomerId = Convert.ToInt32(dr["customer_id"]);
                        customers.CustomerName = (dr["cust_name"]).ToString();
                        customers.City = (dr["city"]).ToString();
                        customers.Grade = Convert.ToDouble(dr["grade"]);
                        customers.SalesId = Convert.ToInt32(dr["salesman_id"]);
                        customer.Add(customers);
                    }
                }
                return customer;
            }
            catch
            {
                return customer;
            }
            finally
            {
                connection.Close();
            }
        }

        public int InsertCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
                cmd.Parameters.Add("@custName", SqlDbType.VarChar).Value = customer.CustomerName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = customer.City;
                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = customer.Grade;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = customer.SalesId;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                //cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int UpdateCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
                cmd.Parameters.Add("@custName", SqlDbType.VarChar).Value = customer.CustomerName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = customer.City;
                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = customer.Grade;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = customer.SalesId;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                //cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int DeleteCustomer(CustomerBO customer)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customer.CustomerId;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                //cmd.Dispose();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}