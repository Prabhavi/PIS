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
    public partial class SendToledger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataToJournal[] dtJnl = new DataToJournal[1];
            try
            {
                lblErrMessage.Text = string.Empty;
                if (!IsPostBack)
                {
                    gridClear();
                    if (Session["DataToJournalConsolidated"] != null)
                    {
                        dtJnl[0] = (DataToJournal)Session["DataToJournalConsolidated"];
                        Session["InquireDetails"] = dtJnl[0];
                        grdSearchDetailsC.DataSource = dtJnl;
                        grdSearchDetailsC.DataBind();

                        Load_grdSearchFromCorrection(dtJnl[0]);
                        LoadButtons();
                    }
                    
                    else if (Session["DataToJournalProvincial"] != null)
                    {
                        dtJnl[0] = (DataToJournal)Session["DataToJournalProvincial"];
                        Session["InquireDetails"] = dtJnl[0];
                        grdSearchDetailsP.DataSource = dtJnl;
                        grdSearchDetailsP.DataBind();

                        Load_grdSearchFromCorrection(dtJnl[0]);
                        LoadButtons();
                    }
                    else if (Session["DataToJournalOffline"] != null)
                    {
                        dtJnl[0] = (DataToJournal)Session["DataToJournalOffline"];
                        Session["InquireDetails"] = dtJnl[0];
                        grdSearchDetailsOff.DataSource = dtJnl;
                        grdSearchDetailsOff.DataBind();

                        Load_grdSearchFromCorrection(dtJnl[0]);
                        LoadButtons();
                    }
                    else if (Session["DataToJournalOnline"] != null)
                    {
                        dtJnl[0] = (DataToJournal)Session["DataToJournalOnline"];
                        Session["InquireDetails"] = dtJnl[0];
                        grdSearchDetailsOn.DataSource = dtJnl;
                        grdSearchDetailsOn.DataBind();

                        Load_grdSearchFromCorrection(dtJnl[0]);
                        LoadButtons();
                    }
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

        protected void btnEnter__Click(object sender, ImageClickEventArgs e)
        {
            DbConnection dbcon = new DbConnection();
            DataToJournal dtJnl = new DataToJournal();
            try
            {
                bool success = false;
                DataToJournal dtj = new DataToJournal();
                if (!string.IsNullOrEmpty(lblHidden.Text)) { dtj.ID = lblHidden.Text; }

                dtj.RefNo = txtRefNo.Text;
                dtj.Comment = txtComment.Text;
                dtj.cmbJourneleType = cmbJourneleTy.SelectedItem.Text;
                dtj.AccNo = txtAccountNo.Text;
                dtj.txtJnlNo = txtJnlNo.Text;
                dtj.PayDate = txtFromDate.Text;
                dtj.Uname = Session["UserName"].ToString();
                dtj.Udate = DateTime.Now.ToString("dd/MM/yyyy");
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];

                if (!string.IsNullOrEmpty(lblHidden.Text))
                {
                    if ((lblStatus.Text.Trim() == "E") || (lblStatus.Text.Trim() == "NC") || (lblStatus.Text.Trim() == "NA"))
                    {
                        success = dbcon.UpdateEnteredDetail(dtj, dtInqDet);
                        if (success)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Updated');", true);
                            lblErrMessage.Text = "Sucessfully Updated";
                            dtJnl=(DataToJournal)Session["InquireDetails"] ;
                            Load_grdSearchFromCorrection(dtJnl);
                            clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Enter All The Data And Try Again');", true);
                            lblErrMessage.Text = "Error Please try again";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('You Can't Edit at This Moment');", true);
                        lblErrMessage.Text = "You Can't Edit at This Moment";
                    }
                }
                else
                {
                    success = dbcon.InsertEnteredDetail(dtj, dtInqDet);
                    if (success)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Inserted');", true);
                        lblErrMessage.Text = "Sucessfully Inserted";
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Enter All The Data And Try Again');", true);
                        lblErrMessage.Text = "Error Please try again";
                    }
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

        protected void btnCheck__Click(object sender, ImageClickEventArgs e)
        {
            DbConnection dbcon = new DbConnection();
            DataToJournal dtJnl = new DataToJournal();
            try
            {
                bool success = false;
                DataToJournal dtj = new DataToJournal();
                if (!string.IsNullOrEmpty(lblHidden.Text)) { dtj.ID = lblHidden.Text; }

                dtj.RefNo = txtRefNo.Text;
                dtj.Comment = txtComment.Text;
                dtj.cmbJourneleType = cmbJourneleTy.SelectedItem.Text;
                dtj.AccNo = txtAccountNo.Text;
                dtj.txtJnlNo = txtJnlNo.Text;
                dtj.PayDate = txtFromDate.Text;
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];

                if (!string.IsNullOrEmpty(lblHidden.Text))
                {
                    if (lblStatus.Text.Trim() != "A")
                    {
                        success = dbcon.UpdateCheckedDetail(dtj, dtInqDet);
                        if (success)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Updated');", true);
                            lblErrMessage.Text = "Sucessfully Updated";
                            dtJnl = (DataToJournal)Session["InquireDetails"];
                            Load_grdSearchFromCorrection(dtJnl);
                            clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Error Please try again');", true);
                            lblErrMessage.Text = "Error Please try again";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('You Can't Edit at This Moment');", true);
                        lblErrMessage.Text = "You Can't Edit at This Moment";
                    }
                    
                }
                else
                {
                    success = dbcon.InsertCheckedDetail(dtj, dtInqDet);
                    if (success)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Checked');", true);
                        lblErrMessage.Text = "Sucessfully Checked";
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Select Entered Data.You can Check Only The Entered Data');", true);
                        lblErrMessage.Text = "Error Please try again";
                    }
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

        protected void btnApprove__Click(object sender, ImageClickEventArgs e)
        {
            DbConnection dbcon = new DbConnection();
            DataToJournal dtJnl = new DataToJournal();
            try
            {
                bool success = false;
                DataToJournal dtj = new DataToJournal();
                if (!string.IsNullOrEmpty(lblHidden.Text)) { dtj.ID = lblHidden.Text; }

                dtj.RefNo = txtRefNo.Text;
                dtj.Comment = txtComment.Text;
                dtj.cmbJourneleType = cmbJourneleTy.SelectedItem.Text;
                dtj.AccNo = txtAccountNo.Text;
                dtj.txtJnlNo = txtJnlNo.Text;
                dtj.PayDate = txtFromDate.Text;
                dtj.Uname = Session["UserName"].ToString();
                dtj.Udate = DateTime.Now.ToString("dd/MM/yyyy");
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];

                if (!string.IsNullOrEmpty(lblHidden.Text))
                {
                    success = dbcon.UpdateApprovedDetail(dtj, dtInqDet);
                    if (success)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Updated');", true);
                        lblErrMessage.Text = "Sucessfully Approved";
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Error Please try again');", true);
                        lblErrMessage.Text = "Error Please try again";
                    }
                }
                else
                {
                    success = dbcon.InsertApprovedDetail(dtj, dtInqDet);
                    if (success)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Approved');", true);
                        lblErrMessage.Text = "Sucessfully Approved";
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sellect Checked Data.You Can Approve Only The Checked Data');", true);
                        lblErrMessage.Text = "Error Please try again";
                    }
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

        protected void btn_Delete(object sender, ImageClickEventArgs e)
        {
            DbConnection dbcon = new DbConnection();
            DataToJournal dtJnl = new DataToJournal();
            try
            {
                DataToJournal dtj = new DataToJournal();
                dtj.ID = (sender as ImageButton).CommandArgument;
                // dtj.ID= grdSearchFromCorrection.SelectedDataKey.Values[0].ToString();
                Response.Write(dtj.ID);
                //  if (!string.IsNullOrEmpty(lblHidden.Text)) { dtj.ID = lblHidden.Text; }

                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];

                if (!string.IsNullOrEmpty(dtj.ID))
                {
                    dbcon.Delete_Row(dtj);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Deleted');", true);
                    lblErrMessage.Text = "Sucessfully Deleted";
                    dtJnl = (DataToJournal)Session["InquireDetails"];
                    Load_grdSearchFromCorrection(dtJnl);
                    clear();
                    Response.Redirect("SendToledger.aspx");


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

        private void LoadButtons()
        {
            try
            {
                string uid = (string)Session["UserName"];
                DbConnection dbCon = new DbConnection();
                string uLvl = dbCon.UserLevel(uid);
                //uLvl = "A";

                if (!string.IsNullOrEmpty(uLvl))
                {
                    if (uLvl == "A")
                    {
                        btnApprove.Visible = true;
                        btnCheck.Visible = false;
                        btnEnter.Visible = false;
                        txtFromDate.Visible = false;
                        cmbJourneleTy.Visible = false;
                        txtJnlNo.Visible = false;
                        txtComment.Visible = false;
                        txtAccountNo.Visible = false;
                        txtRefNo.Visible = false;
                        grdSearchFromCorrection.Columns[0].Visible = false;
                        //grdSearchFromCorrection.Columns[1].Visible = false;
                        grdSearchFromCorrection.Columns[19].Visible = true;
                        grdSearchFromCorrection.Columns[20].Visible = true;
                        grdSearchFromCorrection.Columns[21].Visible = false;

                    }
                    else if (uLvl == "C")
                    {
                        btnCheck.Visible = true;
                        btnApprove.Visible = false;
                        btnEnter.Visible = false;
                        txtFromDate.Visible = false;
                        cmbJourneleTy.Visible = false;
                        txtJnlNo.Visible = false;
                        txtComment.Visible = false;
                        txtAccountNo.Visible = false;
                        txtRefNo.Visible = false;
                        grdSearchFromCorrection.Columns[0].Visible = false;
                        //grdSearchFromCorrection.Columns[1].Visible = false;
                        grdSearchFromCorrection.Columns[19].Visible = true;
                        grdSearchFromCorrection.Columns[20].Visible = true;
                        grdSearchFromCorrection.Columns[21].Visible = false;
                    }
                    else if (uLvl == "E")
                    {
                        btnEnter.Visible = true;
                        //btnNotChecked.Visible = true;
                        btnApprove.Visible = false;
                        btnCheck.Visible = false;
                        txtFromDate.Visible = true;
                        cmbJourneleTy.Visible = true;
                        txtJnlNo.Visible = true;
                        txtComment.Visible = true;
                        txtAccountNo.Visible = true;
                        txtRefNo.Visible = true;
                        
                        grdSearchFromCorrection.Columns[18].Visible = false;
                        grdSearchFromCorrection.Columns[19].Visible = false;
                        grdSearchFromCorrection.Columns[20].Visible = false;
                        grdSearchFromCorrection.Columns[21].Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Access denied for this user/ Invalid User');", true);
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

        private void gridClear()
        {
            grdSearchDetailsC.DataSource = null;
            grdSearchDetailsC.DataBind();

            grdSearchDetailsP.DataSource = null;
            grdSearchDetailsP.DataBind();

            grdSearchDetailsOff.DataSource = null;
            grdSearchDetailsOff.DataBind();

            grdSearchDetailsOn.DataSource = null;
            grdSearchDetailsOn.DataBind();

            txtRefNo.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtJnlNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            cmbJourneleTy.SelectedIndex= 0;

            grdSearchFromCorrection.DataSource = null;
            grdSearchFromCorrection.DataBind();

            btnApprove.Visible = false;
            btnCheck.Visible = false;
            btnEnter.Visible = false;
        }


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
                string st = dbCon.GetStatus(dtJnl);
                //Response.Write(st);
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];
                if (uLvl == "C")
                {
                    if (st == "E")
                    {

                        dbCon.UpdateCheckedDetail(dtJnl, dtInqDet);
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('you cant check at this moment" + "');", true);
                    }
                }
                else if (uLvl == "A")
                {
                    if (st == "C")
                    {
                        dbCon.UpdateApprovedDetail(dtJnl, dtInqDet);
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);

                    }
                    else
                    {

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('you cant Approve at this moment" + "');", true);
                    }
                }
                //Load_getcheck(dtJnl);
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
                //get selected ro4w id
                string ID = (sender as ImageButton).CommandArgument;
                dtJnl.ID = ID;
                string st = dbCon.GetStatus(dtJnl);
                Response.Write(st);
                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];
                if (uLvl == "C")
                {
                    if (st == "E")
                    {
                        dbCon.Reject_C(dtJnl, dtInqDet);
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                    }
                    //lblErrMessage.Text = "Sucessfully Deleted";
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('you cant reject at this moment" + "');", true);
                        //Load_grdSearchFromCorrectionBulk(dtJnl);
                    }

                }
                else if (uLvl == "A")
                {
                    if (st == "C")
                    {
                        dbCon.Reject_A(dtJnl, dtInqDet);
                        dtJnl = (DataToJournal)Session["InquireDetails"];
                        Load_grdSearchFromCorrection(dtJnl);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('you cant reject at this moment" + "');", true);
                        //Load_grdSearchFromCorrectionBulk(dtJnl);
                    }
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


        private void Load_grdSearchFromCorrection(DataToJournal dtJnl)
        {
            DbConnection dbcon = new DbConnection();

            try
            {
                DataSet dt = dbcon.Load_grdSearchFromCorrection(dtJnl);

                if (dt.Tables[0].Rows.Count != 0)
                {
                    grdSearchFromCorrection.DataSource = dt;
                    grdSearchFromCorrection.DataBind();
                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Text = "There is no settlements for this payment";
                    lblMessage.Visible = true;
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

        protected void grdSearchFromCorrection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblHidden.Text = grdSearchFromCorrection.SelectedDataKey.Values[0].ToString();
                lblStatus.Text = grdSearchFromCorrection.SelectedDataKey.Values[1].ToString();
                txtRefNo.Text = grdSearchFromCorrection.SelectedRow.Cells[12].Text.Trim();
                txtComment.Text = grdSearchFromCorrection.SelectedRow.Cells[11].Text.Trim();
                cmbJourneleTy.SelectedItem.Text = grdSearchFromCorrection.SelectedRow.Cells[14].Text.Trim();
                txtAccountNo.Text = grdSearchFromCorrection.SelectedRow.Cells[16].Text.Trim();
                txtJnlNo.Text = grdSearchFromCorrection.SelectedRow.Cells[13].Text.Trim();
                if(grdSearchFromCorrection.SelectedRow.Cells[15].Text.Trim() != "&nbsp;")
                { txtFromDate.Text = grdSearchFromCorrection.SelectedRow.Cells[15].Text.Trim(); }
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }
        }

        private void clear()
        {
            lblHidden.Text = string.Empty;
            lblStatus.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtJnlNo.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            cmbJourneleTy.Text = string.Empty;
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtFromDate.Text))
            {
                if (DateTime.Now.Date < DateTime.Parse(txtFromDate.Text))
                {
                    txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
           
        }
    }
}