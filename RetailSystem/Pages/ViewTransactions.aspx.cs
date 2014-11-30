using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewInventoryProductWise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
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


        private void BindGrid() 
        {
            Classes.CViewClasses.CViewTransactions cv = new Classes.CViewClasses.CViewTransactions();
            List<Models.MViewModels.MViewTransactions> Get = new List<Models.MViewModels.MViewTransactions>();
            Get = cv.GetAll();

            Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            grdTransactions.DataSource = Get;
            grdTransactions.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Classes.CViewClasses.CViewTransactions cv = new Classes.CViewClasses.CViewTransactions();
            List<Models.MViewModels.MViewTransactions> Get = new List<Models.MViewModels.MViewTransactions>();
            Get = cv.GetAll();

            if (cbViewAll.Checked)
            {
                //do nothing
            }
            else
            {
                Get = Get.Where(o => o.WareHouseId == Session["WareHouse"].ToString()).ToList();
            }
            grdTransactions.DataSource = Get;
            grdTransactions.DataBind();
        }
    }
}