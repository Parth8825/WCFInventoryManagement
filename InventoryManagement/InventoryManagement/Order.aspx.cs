using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
                DropDownListData();
            }
        }
        private void DropDownListData()
        {
            InventoryManagement.InventoryServiceReference.SalesmanServiceClient salesmanBusinessLogic = new InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
            dlSalesmanId.DataSource = salesmanBusinessLogic.GetSalesman();
            dlSalesmanId.DataTextField = "SalesmanId";
            dlSalesmanId.DataValueField = "SalesmanId";
            dlSalesmanId.DataBind();
            dlSalesmanId.Items.Insert(0, new ListItem("Please Select ID", "0"));

            InventoryManagement.InventoryServiceReference.CustomerServiceClient customerBusinessLogic = new InventoryServiceReference.CustomerServiceClient("BasicHttpBinding_ICustomerService");
            dlCustomerId.DataSource = customerBusinessLogic.GetCustomer();
            dlCustomerId.DataTextField = "CustomerId";
            dlCustomerId.DataValueField = "CustomerId";
            dlCustomerId.DataBind();
            dlCustomerId.Items.Insert(0, new ListItem("Please Select ID", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtOrderNo.Text);
                double purchAmt = double.Parse(txtPurchAmt.Text);
                DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
                int customerId = int.Parse(dlCustomerId.Text);
                int salesmanId = int.Parse(dlSalesmanId.Text);

                InventoryManagement.InventoryServiceReference.OrderBO newOrder = new InventoryServiceReference.OrderBO()
                {
                    OrderNo = orderNo,
                    PurchAmt = purchAmt,
                    OrderDate = orderDate,
                    CustomerId = customerId,
                    SalesmanId = salesmanId,
                };

                InventoryManagement.InventoryServiceReference.OrderServiceClient businessLogic = new InventoryServiceReference.OrderServiceClient("BasicHttpBinding_IOrderService");
                var result = businessLogic.InsertNewOrder(newOrder);

                string message = "Order details have been saved successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Order data.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtOrderNo.Text);
                double purchAmt = double.Parse(txtPurchAmt.Text);
                DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
                int customerId = int.Parse(dlCustomerId.Text);
                int salesmanId = int.Parse(dlSalesmanId.Text);

                InventoryManagement.InventoryServiceReference.OrderBO order = new InventoryServiceReference.OrderBO()
                {
                    OrderNo = orderNo,
                    PurchAmt = purchAmt,
                    OrderDate = orderDate,
                    CustomerId = customerId,
                    SalesmanId = salesmanId,
                };

                InventoryManagement.InventoryServiceReference.OrderServiceClient businessLogic = new InventoryServiceReference.OrderServiceClient("BasicHttpBinding_IOrderService");
                var result = businessLogic.UpdateOrder(order);

                string message = "Order details have been successfully updated.";
                string key = "Success";

                if (result == 0)
                {
                    message = "ERROR!!!!! failed to update Order data. Data does not exists.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNo = int.Parse(txtDeleteId.Text);
                InventoryManagement.InventoryServiceReference.OrderBO order = new InventoryServiceReference.OrderBO()
                {
                    OrderNo = orderNo
                };


                InventoryManagement.InventoryServiceReference.OrderServiceClient businessLogic = new InventoryServiceReference.OrderServiceClient("BasicHttpBinding_IOrderService");
                var result = businessLogic.DeleteOrder(order);

                string message = "Order details have been successfully deleted.";
                string key = "Delete";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to delete Order data.";
                    key = "Error";
                }
                IfCondition(result, message, key);
            }
            catch (FormatException)
            {
                string emptyMessage = "Please enter the value";
                string emptyKey = "Warning";
                MessageBox(emptyMessage, emptyKey);
            }
        }

        private void BindGridView()
        {
            try
            {
                InventoryManagement.InventoryServiceReference.OrderServiceClient businessLogic = new InventoryServiceReference.OrderServiceClient("BasicHttpBinding_IOrderService");
                gvOrder.DataSource = businessLogic.GetOrder();
                gvOrder.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }

        }
        private void ClearFormFields()
        {
            dlCustomerId.SelectedIndex = 0;
            txtOrderDate.Text = "";
            txtOrderNo.Text = "";
            txtPurchAmt.Text = "";
            dlSalesmanId.SelectedIndex = 0;
            txtDeleteId.Text = "";
            txtOrderNo.Focus();
        }

        private void IfCondition(int ifResult, string ifMessage, string messageKey)
        {
            if (ifResult > 0)
            {
                BindGridView();
                MessageBox(ifMessage, messageKey);
                ClearFormFields();
            }
            else
            {
                MessageBox(ifMessage, messageKey);
                ClearFormFields();
            }
        }
        private void MessageBox(string message, string key)
        {
            //Display success message.

            if (key == "Success")
            {
                string script = "swal('Saved','";
                script += message;
                script += "', 'success')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Delete")
            {
                string script = "swal('Deleted','";
                script += message;
                script += "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Error")
            {
                string script = "swal('Sorry!!','";
                script += message;
                script += "', 'error')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
            else if (key == "Warning")
            {
                string script = "swal('Empty!!','";
                script += message;
                script += "', 'warning')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);

            }
        }
    }
}