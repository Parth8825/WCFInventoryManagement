using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class SalesmanDA
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        public List<SalesmanBO> GetSalesmanData()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            List<SalesmanBO> salesman = new List<SalesmanBO>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SelectSalesman", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SalesmanBO salesmans = new SalesmanBO();
                        salesmans.SalesmanId = Convert.ToInt32(dr["salesman_id"]);
                        salesmans.SalesmanName = (dr["name"]).ToString();
                        salesmans.City = (dr["city"]).ToString();
                        salesmans.Commision = Convert.ToDouble(dr["commission"]);
                        salesman.Add(salesmans);
                    }
                }
                return salesman;
            }
            catch
            {
                return salesman;
            }
            finally
            {
                connection.Close();
            }
        }

        public int InsertSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertSalesman", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = salesman.SalesmanName;
                cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = salesman.City;
                cmd.Parameters.Add("@commission", SqlDbType.Decimal).Value = salesman.Commision;
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

        public int UpdateSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateSalesman", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = salesman.SalesmanName;
                cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = salesman.City;
                cmd.Parameters.Add("@commission", SqlDbType.Decimal).Value = salesman.Commision;
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

        public int DeleteSalesman(SalesmanBO salesman)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteSalesman", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@salesmanId", SqlDbType.Int).Value = salesman.SalesmanId;
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