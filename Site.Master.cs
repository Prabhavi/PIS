using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentInquiry
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (Session["UserName"] != null)
                {                   
                    btnLogin.Visible = false;
                    btnLogOut.Visible = true;
                    lblLoginDet.Text = Session["UserName"].ToString();
                    lblLoginDet.Visible = true;
                }
                else
                {
                    //myBtn.Visible = true;
                    btnLogin.Visible = true;
                    btnLogOut.Visible = false;
                    lblLoginDet.Text = string.Empty;
                    lblLoginDet.Visible = false;
                }
           
            {
                LoadButtons();
            }         
        }

        protected void btnLogin__Click(object sender, ImageClickEventArgs e)
        {
            btnLogin.Attributes.Add("onclick", "return openPopup();");
        }

        protected void btnLogOut__Click(object sender, ImageClickEventArgs e)
        {
            Session["UserName"] = null;
            btnLogin.Visible = true;
            btnLogOut.Visible = false;
            lblLoginDet.Visible = false;
            Response.Redirect("~/ConsolidatedSuspensePayments.aspx");
        }

        private void LoadButtons()
        {
            try
            {
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);
                //uLvl = "A";
                //Label1.Text = uLvl;
                if (!string.IsNullOrEmpty(uLvl))
                {
                    if (uLvl == "A")
                    {
                        Button1.Visible = true;

                    }
                    else if (uLvl == "C")
                    {
                        Button1.Visible = true;
                    }
                    else if (uLvl == "E")
                    {
                        b1.Visible = true;

                    }
                }
                else
                {
                  //  ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Please Sign In First');", true);
                }
            }
          //  catch (DbException db)
           // {
           //     throw new DbException(db.Message);
            //}
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                //Label1.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('"+ex.Message+"');", true);
                
            }
        }
    }
}