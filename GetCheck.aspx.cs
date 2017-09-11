using beans.exceptions.db;
using PaymentInquiry.Beans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace PaymentInquiry
{
    public partial class GetCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataToJournal[] dtJnl = new DataToJournal[1];
            try
            {
                //lblErrMessage.Text = string.Empty;
                if (!IsPostBack)
                {
                   // string uid = (string)Session["UserName"];
                   // DbConnection dbCon = new DbConnection();
                   // string uLvl = dbCon.UserLevel(uid);

                    //DbConnection dbCon = new PaymentInquiry.DbConnection();
                  //  DataSet dt = dbCon.Get_Check(uLvl);
                   // if (dt.Tables[0].Rows.Count != 0)
                   // {
                        //Session["Bulk"] = dt;
                        //Response.Write("this");
                     //   getcheck.DataSource = dt;
                     //   getcheck.DataBind();
                   // }
                    Load_getcheck(dtJnl[0]);
                }
              }
            catch (DbException db)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + db.Message + ");", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }
        }

        /*protected void btnSearch__Click(object sender, ImageClickEventArgs e)
        {
            try {
               
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);

                //DbConnection dbCon = new PaymentInquiry.DbConnection();
                DataSet dt = dbCon.Get_Check(uLvl);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    //Session["Bulk"] = dt;
                    //Response.Write("this");
                    getcheck.DataSource = dt;
                    getcheck.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Please Sign In First');", true);
                }
            }




            catch (DbException db)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + db.Message + ");", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }
        }
        */
        protected void btnTick_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);
                DataToJournal dtJnl = new DataToJournal();

                dtJnl.Uname = Session["UserName"].ToString();
                dtJnl.Udate = DateTime.Now.ToString("dd/MM/yyyy");
                //get selected ro4w id
                string ID = (sender as ImageButton).CommandArgument;
                dtJnl.ID = ID;
                //Response.Write(ID);
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];
                if (uLvl == "C")
                {
                    dbCon.UpdateCheckedDetail(dtJnl, dtInqDet);
                    dtJnl = (DataToJournal)Session["InquireDetails"];
                    //Load_getcheck(dtJnl);
                }
                else if (uLvl == "A")
                {
                    dbCon.UpdateApprovedDetail(dtJnl, dtInqDet);
                    //Load_getcheck(dtJnl);
                }
                Load_getcheck(dtJnl);
            }
            catch (DbException db)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + db.Message + ");", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }

        }

        protected void btnDisagree_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);
                DataToJournal dtJnl = new DataToJournal();

                dtJnl.Uname = Session["UserName"].ToString();
                dtJnl.Udate = DateTime.Now.ToString("dd/MM/yyyy");
                //get selected row id
                string ID = (sender as ImageButton).CommandArgument;
                dtJnl.ID = ID;
                //Response.Write(ID);
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];
                if (uLvl == "C")
                {
                                 dbCon.Reject_C(dtJnl, dtInqDet);
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                    //Load_getcheck(dtJnl);

                    //lblErrMessage.Text = "Sucessfully Deleted";

                }
                else if (uLvl == "A")
                {
                    dbCon.Reject_A(dtJnl, dtInqDet);
                    //Load_getcheck(dtJnl);
                }
                Load_getcheck(dtJnl);
            }
            catch (DbException db)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + db.Message + ");", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }

        }

      /*  protected void btnUndo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);
                DataToJournal dtJnl = new DataToJournal();

                dtJnl.Uname = Session["UserName"].ToString();
                dtJnl.Udate = DateTime.Now.ToString("dd/MM/yyyy");
                //get selected row id
                string ID = (sender as ImageButton).CommandArgument;
                dtJnl.ID = ID;
                //Response.Write(ID);
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];
                if (uLvl == "C")
                {
                    dbCon.UpdateCheckedDetail(dtJnl, dtInqDet);
                    dtJnl = (DataToJournal)Session["InquireDetails"];
                    dbCon.Load_grdSearchFromCorrectionBulk(dtJnl);
                }
                else if (uLvl == "A")
                {
                    dbCon.UpdateApprovedDetail(dtJnl, dtInqDet);
                    dbCon.Load_grdSearchFromCorrectionBulk(dtJnl);
                }
            }
            catch (DbException db)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + db.Message + ");", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }

        }
        */
        private void Load_getcheck(DataToJournal dtJnl)
        {
            DbConnection dbcon = new DbConnection();
            string uid = (string)Session["UserName"];
            DbConnection dbCon = new DbConnection();
            string uLvl = dbCon.UserLevel(uid);

            //DbConnection dbCon = new PaymentInquiry.DbConnection();
         //   DataSet dt = dbCon.Get_Check(uLvl);

            try
            {
                DataSet dt = dbCon.Get_Check(uLvl);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    getcheck.DataSource = dt;
                    getcheck.DataBind();
                    lblMessage.Visible = false;
                }
                else if(dt.Tables[0].Rows.Count==0)
                {
                    getcheck.DataSource = dt;
                    getcheck.DataBind();
                    lblMessage.Text = "There is no record";
                    lblMessage.Visible = true;
                }

                else
                {
                    if (uLvl==null)
                    {
                        lblMessage.Text = "Please SignIn First ";
                        lblMessage.Visible = true;
                    }
                    else{
                        lblMessage.Text = "There is no record";
                        lblMessage.Visible = true;
                        }
                }

            }
            catch (DbException db)
            {
                throw new DbException(db.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
