using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailSystem.Classes
{
    public class MasterBaseClass : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            if (PageIsValid())
            {
               
            }
            else
            {
                Response.Redirect("~/Pages/LoginPage.aspx");
            }
            base.OnLoad(e);
        }

        private bool PageIsValid()
        {

            if (Session["User"] == null)
            {
                return false;
            }
            return true;
        }
       


      


    }
}