using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace RetailSystem.Pages
{
    public partial class ManualGeneralJournal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                FirstGridViewRow(); 

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "DatePickerInit();", true);
        }

        protected void grdJournal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grdJournal.DataSource = dt;
                    grdJournal.DataBind();

                    for (int i = 0; i < grdJournal.Rows.Count - 1; i++)
                    {
                        grdJournal.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }



        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(string)));
            dt.Columns.Add(new DataColumn("Accounts", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Debit", typeof(string)));
            dt.Columns.Add(new DataColumn("Credit", typeof(string)));
            
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Date"] = string.Empty;
            dr["Accounts"] = string.Empty;
            dr["Description"] = string.Empty;
            dr["Debit"] = string.Empty;
            dr["Credit"] = string.Empty;
            
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grdJournal.DataSource = dt;
            grdJournal.DataBind();
        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextBoxDate =
                          (TextBox)grdJournal.Rows[rowIndex].Cells[1].FindControl("txtDate");
                        DropDownList ddlAccounts =
                          (DropDownList)grdJournal.Rows[rowIndex].Cells[2].FindControl("ddlAccounts");
                        TextBox txtDescription =
                         (TextBox)grdJournal.Rows[rowIndex].Cells[3].FindControl("txtDescription");
                        TextBox txtDebit =
                          (TextBox)grdJournal.Rows[rowIndex].Cells[4].FindControl("txtDebit");
                        TextBox txtCredit =
                         (TextBox)grdJournal.Rows[rowIndex].Cells[5].FindControl("txtCredit");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Date"] = TextBoxDate.Text;
                        dtCurrentTable.Rows[i - 1]["Accounts"] = ddlAccounts.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Description"] = txtDescription.Text;
                        dtCurrentTable.Rows[i - 1]["Debit"] = txtDebit.Text;
                        dtCurrentTable.Rows[i - 1]["Credit"] = txtCredit.Text;
                       
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grdJournal.DataSource = dtCurrentTable;
                    grdJournal.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtDate = (TextBox)grdJournal.Rows[rowIndex].Cells[1].FindControl("txtDate");
                        DropDownList ddlAccounts =
                          (DropDownList)grdJournal.Rows[rowIndex].Cells[2].FindControl("ddlAccounts");
                        TextBox txtDescription = (TextBox)grdJournal.Rows[rowIndex].Cells[3].FindControl("txtDescription");
                        TextBox txtDebit = (TextBox)grdJournal.Rows[rowIndex].Cells[4].FindControl("txtDebit");
                        TextBox txtCredit = (TextBox)grdJournal.Rows[rowIndex].Cells[5].FindControl("txtCredit");
                        
                        //Added these lines

                       

                        //****************
                        txtDate.Text = dt.Rows[i]["Date"].ToString();
                        ddlAccounts.SelectedValue = dt.Rows[i]["Accounts"].ToString();
                        txtDescription.Text = dt.Rows[i]["Description"].ToString();
                        txtDebit.Text = dt.Rows[i]["Debit"].ToString();
                        txtCredit.Text = dt.Rows[i]["Credit"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtDate = (TextBox)grdJournal .Rows[rowIndex].Cells[1].FindControl("txtDate");
                        DropDownList ddlAccounts =
                            (DropDownList)grdJournal.Rows[rowIndex].Cells[2].FindControl("ddlAccounts");
                        TextBox txtDescription = (TextBox)grdJournal.Rows[rowIndex].Cells[3].FindControl("txtDescription");
                        TextBox txtDebit = (TextBox)grdJournal.Rows[rowIndex].Cells[4].FindControl("txtDebit");
                        TextBox txtCredit = (TextBox)grdJournal.Rows[rowIndex].Cells[5].FindControl("txtCredit");
                       
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Date"] = txtDate.Text;
                        dtCurrentTable.Rows[i - 1]["Accounts"] = ddlAccounts.Text;
                        dtCurrentTable.Rows[i - 1]["Description"] = txtDescription.Text;
                        dtCurrentTable.Rows[i - 1]["Debit"] = txtDebit.Text;
                        dtCurrentTable.Rows[i - 1]["Credit"] = txtCredit.Text;
                       
                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void ButtonAdd_Click1(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
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