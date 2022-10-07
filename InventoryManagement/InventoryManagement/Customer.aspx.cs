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
    public partial class Customer : System.Web.UI.Page
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
            InventoryManagement.InventoryServiceReference.SalesmanServiceClient businessLogic = new InventoryManagement.InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
            dlSalesmanId.DataSource = businessLogic.GetSalesman();
            dlSalesmanId.DataTextField = "SalesmanId";
            dlSalesmanId.DataValueField = "SalesmanId";
            dlSalesmanId.DataBind();
            dlSalesmanId.Items.Insert(0, new ListItem("Please Select ID", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int custId = int.Parse(txtCustID.Text);
                string custName = txtCustName.Text;
                string city = txtCity.Text;
                double grade = double.Parse(txtGrade.Text);
                int salesId = int.Parse(dlSalesmanId.Text);

                InventoryManagement.InventoryServiceReference.CustomerBO newCustomer = new InventoryServiceReference.CustomerBO()
                {
                    CustomerId = custId,
                    CustomerName = custName,
                    City = city,
                    Grade = grade,
                    SalesId = salesId
                };

                InventoryManagement.InventoryServiceReference.CustomerServiceClient businessLogic = new InventoryServiceReference.CustomerServiceClient("BasicHttpBinding_ICustomerService");
                var result = businessLogic.InsertNewCustomer(newCustomer);

                string message = "Customer details have been saved successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Customer data.";
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
                int custId = int.Parse(txtCustID.Text);
                string custName = txtCustName.Text;
                string city = txtCity.Text;
                double grade = double.Parse(txtGrade.Text);
                int salesId = int.Parse(dlSalesmanId.Text);

                InventoryManagement.InventoryServiceReference.CustomerBO customer = new InventoryServiceReference.CustomerBO()
                {
                    CustomerId = custId,
                    CustomerName = custName,
                    City = city,
                    Grade = grade,
                    SalesId = salesId
                };

                InventoryManagement.InventoryServiceReference.CustomerServiceClient businessLogic = new InventoryServiceReference.CustomerServiceClient("BasicHttpBinding_ICustomerService");
                var result = businessLogic.UpdateCustomer(customer);

                string message = "Customer details have been updated successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Customer data.";
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
                int custId = int.Parse(txtDeleteId.Text);

                InventoryManagement.InventoryServiceReference.CustomerBO customer = new InventoryServiceReference.CustomerBO()
                {
                    CustomerId = custId
                };

                InventoryManagement.InventoryServiceReference.CustomerServiceClient businessLogic = new InventoryServiceReference.CustomerServiceClient("BasicHttpBinding_ICustomerService");
                var result = businessLogic.DeleteCustomer(customer);

                string message = "Customer details have been deleted successfully.";
                string key = "Delete";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Customer data.";
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
                InventoryManagement.InventoryServiceReference.CustomerServiceClient businessLogic = new InventoryServiceReference.CustomerServiceClient("BasicHttpBinding_ICustomerService");
                gvCustomer.DataSource = businessLogic.GetCustomer();
                gvCustomer.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }

        }
        private void ClearFormFields()
        {
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtCity.Text = "";
            txtGrade.Text = "";
            dlSalesmanId.SelectedIndex = 0;
            txtDeleteId.Text = "";
            txtCustID.Focus();

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