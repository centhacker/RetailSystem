using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class ViewInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BuildInventoryData();
                BindDropDowns();
                createAccordianUsingRepeater();
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

        public List<Models.MInventory> InventoryData = new List<Models.MInventory>();

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///   All 0
        //    All Dates All WareHouse Selected Product -2
        //    All Dates All Products Selected Warehouse -3
        //    All Products Date Selected WareHouse Selected -4
        //    All WareHouse Date Selected Products Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string ddlProductId = ddlProducts.SelectedValue.ToString();
            //    string ddlWareHouseId = ddlWareHouse.SelectedValue.ToString();

                string Filteration = string.Empty;

                string WareHouseId = Session["WareHouse"].ToString();
                InventoryData.Clear();
                if (cbViewAll.Checked)
                {
                    ParseAndBindList(ddlProductId, "-1");
                }
                else
                {
                    ParseAndBindList(ddlProductId, WareHouseId);
                }
                



            }
        }

        #region Private Methods

        private void ParseAndBindList(string ProductsId, string WareHouseid)
        {
            List<Models.MInventory> DataToBind = new List<Models.MInventory>();
            InventoryData = (List<Models.MInventory>)HttpContext.Current.Cache["InventoryData"];
            var query = from o in InventoryData select o;
            if (InventoryData.Count > 0)
            {
                if (ProductsId != "-1")
                {
                    InventoryData = (from o in InventoryData
                                     where o.ProductId == ProductsId
                                     select o).ToList();
                }
                if (WareHouseid != "-1")
                {
                    InventoryData = (from o in InventoryData
                                     where o.WareHouseld == WareHouseid
                                     select o).ToList();
                }

                foreach (var item in InventoryData)
                {
                    Models.MInventory mi = new Models.MInventory();
                    mi.ProductId = item.ProductId;
                    mi.WareHouseName = item.WareHouseName;
                    mi.ProductCode = item.ProductCode;
                    mi.ProductName = item.ProductName;
                    mi.Quantity = item.Quantity;
                    mi.Cost = item.Cost;
                    mi.TotalCost = item.TotalCost;
                    DataToBind.Add(mi);
                }

                repInventory.DataSource = DataToBind;
                repInventory.DataBind();
            }
        }

        private string ReturnWareHouseId(string UserId)
        {
            string WareHouse = string.Empty;
            Classes.CUserWareHouseContainer cw = new Classes.CUserWareHouseContainer();
            WareHouse = cw.GetWareHouseIdByUserId(UserId);
            return WareHouse;
        }

        private void BindDropDowns()
        {
            BindProductsDdl(); BindWareHouseddl();
        }

        private void BindProductsDdl()
        {
            Dictionary<int, string> Get = new Dictionary<int, string>();

            Get.Add(-1, "All Products");
            List<Models.MProducts> Products = new List<Models.MProducts>();
            Classes.CProducts cp = new Classes.CProducts();
            Products = cp.GetAll();
            for (int i = 0; i < Products.Count; i++)
            {
                int id = Convert.ToInt32(Products[i].id);
                string name = Products[i].Name + "-" + Products[i].ProductCode;
                Get.Add(id, name);
            }

            ddlProducts.DataValueField = "Key";
            ddlProducts.DataTextField = "Value";
            ddlProducts.DataSource = Get;
            ddlProducts.DataBind();
        }

        private void BindWareHouseddl()
        {
            //Dictionary<int, string> Get = new Dictionary<int, string>();

            //Get.Add(-1, "All Products");
            //List<Models.MwareHouse> WareHouse = new List<Models.MwareHouse>();
            //Classes.CWareHouse cp = new Classes.CWareHouse();
            //WareHouse = cp.GetAll();
            //for (int i = 0; i < WareHouse.Count; i++)
            //{
            //    int id = Convert.ToInt32(WareHouse[i].id);
            //    string name = WareHouse[i].Name;
            //    Get.Add(id, name);
            //}

            //ddlWareHouse.DataValueField = "Key";
            //ddlWareHouse.DataTextField = "Value";
            //ddlWareHouse.DataSource = Get;
            //ddlWareHouse.DataBind();
        }

        private string BuildInventoryData()
        {
            string Data = string.Empty;
            Classes.CInventory ci = new Classes.CInventory();
            InventoryData = ci.GetInventoryData();
            InventoryData = InventoryData.Where(o => o.WareHouseld == Session["WareHouse"].ToString()).ToList();
            HttpContext.Current.Cache["InventoryData"] = InventoryData;
            return Data;
        }

        public void createAccordianUsingRepeater()
        {
            repInventory.DataSource = InventoryData;

            repInventory.DataBind();

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

        #endregion




    }
}