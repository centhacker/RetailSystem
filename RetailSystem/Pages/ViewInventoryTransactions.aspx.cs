using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewInventoryTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                divViewAll.Visible = false;
                if (isAdmin(Session["User"].ToString()) > 0)
                {
                    divViewAll.Visible = true;
                }
            }
        }
        public int isAdmin(string UserName)
        {
            Classes.CUsers cu = new Classes.CUsers();
            int UserId = cu.GetUserIdByName(UserName);
            List<string> Permissions = cu.ParsePermissions(UserId);
            if (Permissions.Contains("33") || Permissions.Contains("-33") || Permissions.Contains("33-"))
            {
                return 1;
            }
            return -1;

        }
        private void BindData()
        {
            List<Models.MInventoryBalance> InventoryBalance = new List<Models.MInventoryBalance>();
            Classes.CInventory ci = new Classes.CInventory();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            InventoryBalance = ci.GetInventoryBalance(Dates[0], Dates[1]);
            InventoryBalance = InventoryBalance.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())).ToList();
            repInventoryBalance.DataSource = InventoryBalance;
            repInventoryBalance.DataBind();

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<Models.MInventoryBalance> InventoryBalance = new List<Models.MInventoryBalance>();
            Classes.CInventory ci = new Classes.CInventory();
            int FiscalYearId = Convert.ToInt32(Session["FiscalYear"]);
            Classes.CFiscalYear cf = new Classes.CFiscalYear();
            List<DateTime> Dates = cf.GetDefaultDatesById(FiscalYearId);
            InventoryBalance = ci.GetInventoryBalance(Dates[0], Dates[1]);
            if (cbViewAll.Checked)
            {
                //do nothing
            }
            else
            {
                InventoryBalance = InventoryBalance.Where(o => o.WareHouseId == Convert.ToInt32(Session["WareHouse"].ToString())).ToList();
            }
            repInventoryBalance.DataSource = InventoryBalance;
            repInventoryBalance.DataBind();
        }
    }
}