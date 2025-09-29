using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusBookMarket
{
    public partial class Main : System.Web.UI.MasterPage
    {
        bool trylogin = true;
        bool tryReg = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null) // ✅ user is logged in
            {
                loginBtn.Visible = false;
                registerBtn.Visible = false;
            }
            else
            {
                loginBtn.Visible = true;
                registerBtn.Visible = true;
            }
        }


        public Button LoginButton
        {
            get { return loginBtn; }
        }

        public Button RegisterButton
        {
            get { return registerBtn; }
        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("login.aspx");
            
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {

           Response.Redirect("Register.aspx");
        }

       
    }
}