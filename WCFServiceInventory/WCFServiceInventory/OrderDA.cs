using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class OrderDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        public List<OrderBO> GetOrderData()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            List<OrderBO> order = new List<OrderBO>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SelectOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        OrderBO orders = new OrderBO();
                        orders.OrderNo = Convert.ToInt32(dr["order_no"]);
                        orders.PurchAmt = Convert.ToDouble(dr["purch_amt"]);
                        orders.OrderDate = Convert.ToDateTime(dr["ord_date"]);
                        orders.CustomerId = Convert.ToInt32(dr["customer_id"]);
                        orders.SalesmanId = Convert.ToInt32(dr["salesman_id"]);
                        order.Add(orders);
                    }
                }
                return order;
            }
            catch
            {
                return order;
            }
            finally
            {
                connection.Close();
            }
        }

        public int InsertOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderno", SqlDbType.Int).Value = order.OrderNo;
                cmd.Parameters.Add("@purchAmt", SqlDbType.Decimal).Value = order.PurchAmt;
                cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = order.OrderDate;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = order.CustomerId;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = order.SalesmanId;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
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

        public int UpdateOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderNo", SqlDbType.Int).Value = order.OrderNo;
                cmd.Parameters.Add("@purchAmt", SqlDbType.Decimal).Value = order.PurchAmt;
                cmd.Parameters.Add("@orderDate", SqlDbType.Date).Value = order.OrderDate;
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = order.CustomerId;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = order.SalesmanId;
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

        public int DeleteOrder(OrderBO order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderNo", SqlDbType.Int).Value = order.OrderNo;
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