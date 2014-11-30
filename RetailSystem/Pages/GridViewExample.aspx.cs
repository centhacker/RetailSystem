using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetailSystem.Pages
{
    public partial class GridViewExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = GridView1.Rows[index];
                lblCountryCode.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                // txtPopulation.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
                txtName.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                txtContinent1.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

            }

        }

        public void BindGrid()
        {
            List<BindData> Get = new List<BindData>();
            for (int i = 0; i < 10; i++)
            {
                BindData obj = new BindData();
                obj.Code = "Code" + i;
                obj.Continent = "Continent" + i;
                obj.IndepYear = "IndepYear" + i;
                obj.Name = "Name" + i;
                obj.Population = "Population" + i;
                obj.Region = "Region" + i;
                Get.Add(obj);


            }
            GridView1.DataSource = Get;
            GridView1.DataBind();
            //try
            //{
            //    //Fetch data from mysql database
            //    string connString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ConnectionString;
            //    MySqlConnection conn = new MySqlConnection(connString);
            //    conn.Open();
            //    string cmd = "select * from tblCountry limit 10";
            //    MySqlDataAdapter dAdapter = new MySqlDataAdapter(cmd, conn);
            //    DataSet ds = new DataSet();
            //    dAdapter.Fill(ds);
            //    dt = ds.Tables[0];
            //    //Bind the fetched data to gridview
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();

            //}
            //catch (MySqlException ex)
            //{
            //    System.Console.Error.Write(ex.Message);

            //}  

        }
    }
    class BindData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public string Population { get; set; }
        public string IndepYear { get; set; }
       

    }
}