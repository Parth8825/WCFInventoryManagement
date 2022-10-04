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
    public partial class Salesman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int salesmanID = Convert.ToInt32(txtID.Text);
                string name = txtSalesmanName.Text;
                string city = txtCity.Text;
                float commision = float.Parse(txtCommission.Text);

                InventoryManagement.InventoryServiceReference.SalesmanBO newSalesman = new InventoryServiceReference.SalesmanBO()
                {
                    SalesmanId = salesmanID,
                    SalesmanName = name,
                    City = city,
                    Commision = commision
                };

                InventoryManagement.InventoryServiceReference.SalesmanServiceClient businessLogic = new InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
                var result = businessLogic.InsertNewSalesman(newSalesman);

                string message = "Salesman details have been saved successfully.";
                string key = "Success";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to insert new Salesman data.";
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
                int salesmanID = Convert.ToInt32(txtID.Text);
                string name = txtSalesmanName.Text;
                string city = txtCity.Text;
                float commision = float.Parse(txtCommission.Text);

                InventoryManagement.InventoryServiceReference.SalesmanBO salesman = new InventoryServiceReference.SalesmanBO()
                {
                    SalesmanId = salesmanID,
                    SalesmanName = name,
                    City = city,
                    Commision = commision
                };

                InventoryManagement.InventoryServiceReference.SalesmanServiceClient businessLogic = new InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
                var result = businessLogic.UpdateSalesman(salesman);

                string message = "Salesman details have been successfully updated.";
                string key = "Success";

                if (result == 0)
                {
                    message = "ERROR!!!!! failed to update salesman data. Data does not exists.";
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
                int salesmanID = Convert.ToInt32(txtDeleteId.Text);

                InventoryManagement.InventoryServiceReference.SalesmanBO salesman = new InventoryServiceReference.SalesmanBO()
                {
                    SalesmanId = salesmanID
                };

                InventoryManagement.InventoryServiceReference.SalesmanServiceClient businessLogic = new InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
                var result = businessLogic.DeleteSalesman(salesman);

                string message = "Salesman details have been successfully deleted.";
                string key = "Delete";
                if (result == 0)
                {
                    message = "ERROR!!!!! failed to delete salesman data.";
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
                InventoryManagement.InventoryServiceReference.SalesmanServiceClient businessLogic = new InventoryServiceReference.SalesmanServiceClient("BasicHttpBinding_ISalesmanService");
                gvSalesman.DataSource = businessLogic.GetSalesman();
                gvSalesman.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
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
        private void ClearFormFields()
        {
            txtSalesmanName.Text = "";
            txtID.Text = "";
            txtCommission.Text = "";
            txtCity.Text = "";
            txtDeleteId.Text = "";
            txtID.Focus();
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