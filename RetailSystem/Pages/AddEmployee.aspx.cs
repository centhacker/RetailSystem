using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void ShowSuccessMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalSuccess').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);

        }
        private void ShowFailMessage()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalDanger').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientTypesModal", sb.ToString(), false);
        }

        protected void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (Session["WareHouse"] != null)
            {
                string WareHouseId = Session["WareHouse"].ToString();
                if (Page.IsValid)
                {
                    string FirstName = txtEmployeeFirstName.Text;
                    string LastName = txtEmployeeLastName.Text;
                    string Dob = txtEmployeeDateOfBirth.Text;
                    string Gender = txtEmployeeGender.Text;
                    string Address = txtEmployeeAddress.Text;
                    string City = txtEmployeeCity.Text;
                    string HomePhone = txtEmployeeHomePhone.Text;
                    string CellNo = txtEmployeeCellNo.Text;
                    string Email = txtEmployeeEmail.Text;
                    string EmergencyContactNo = txtEmployeeEmergencyContactNo.Text;
                    Models.MEmployees me = new Models.MEmployees();
                    me.DesignationId = "1";
                    me.FirstName = FirstName;
                    me.LastName = LastName;
                    me.DateOfBirth = Dob;
                    me.Address = Address;
                    me.City = City;
                    me.HomePhone = HomePhone;
                    me.CellNo = CellNo;
                    me.Email = Email;
                    me.EmergencyContactNo = EmergencyContactNo;
                    me.WareHouseId = WareHouseId;
                    Classes.CEmployees ce = new Classes.CEmployees();
                    if (ce.Save(me) < 0)
                    {

                        ShowFailMessage();
                    }
                    else
                    {
                        ShowSuccessMessage();
                        ClearTextBoxes(Page);
                    }
                }
            }
            else
            {
                ShowErrorModal("Cannot Save, No Warehouse associated with current user");
            }
        }

        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        private void ShowErrorModal(string Error)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Font.Bold = true;
            lblError.Text = Error;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#modalError').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }


    }
}