using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewTrialBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }


        private void BindGrid()
        {
            List<Models.MViewModels.MViewTrialBalance> TrialBalance = new List<Models.MViewModels.MViewTrialBalance>();
            Classes.CViewClasses.CViewTrialBalance cvt = new Classes.CViewClasses.CViewTrialBalance();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            TrialBalance = cvt.GetAll(Dates[0],Dates[1]);
            
            grdAccountTransaction.DataSource = TrialBalance;
            grdAccountTransaction.DataBind();
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            float DebitTotal = 0, CreditTotal = 0;
            for (int i = 0; i < grdAccountTransaction.Rows.Count; i++)
            {
                DebitTotal += Convert.ToSingle(grdAccountTransaction.Rows[i].Cells[2].Text);
                CreditTotal += Convert.ToSingle(grdAccountTransaction.Rows[i].Cells[3].Text);
            }
            decimal ConvertedDebit = decimal.Parse(DebitTotal.ToString(), System.Globalization.NumberStyles.Float);
            decimal ConvertedCredit = decimal.Parse(CreditTotal.ToString(), System.Globalization.NumberStyles.Float);
            grdAccountTransaction.FooterStyle.Font.Bold = true;
            grdAccountTransaction.FooterRow.Cells[2].Text = ConvertedDebit.ToString();
            grdAccountTransaction.FooterRow.Cells[3].Text = ConvertedCredit.ToString();
         
        }
    }
}