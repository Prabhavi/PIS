using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentInquiry
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginU_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string UserName = LoginU.UserName;
            string Password = LoginU.Password;
            Session["UserName"] = UserName;

            login.CheckLoginUserSoapClient loginClient = new login.CheckLoginUserSoapClient();

            ///////////////////LOGIN AUTHENTICATION REMOVE COMMENT////////////////////////////
            string ret = loginClient.checkUser(UserName, Password);
            //string ret = "1";

            if (ret == "1")
            {
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Invalid Credentials');", true);
            }
            
        }
    }
}