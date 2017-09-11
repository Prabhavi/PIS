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
    public partial class ReEntered : System.Web.UI.Page
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

                   
                      //  dtJnl[0] = (DataToJournal)Session["DataToJournalBulk"];
                       // Session["InquireDetails"] = dtJnl[0];
                      
                        Load_grdSearchFromCorrectionBulk(dtJnl[0]);
                        LoadButtons();
                    


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
                    if ((lblStatus.Text.Trim() == "NC") || (lblStatus.Text.Trim() == "NA"))

                    {
                        success = dbcon.UpdateReEnteredDetail(dtj, dtInqDet);
                        if (success)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Updated');", true);
                            lblErrMessage.Text = "Sucessfully Updated";
                            dtJnl = (DataToJournal)Session["InquireDetails"];
                            Load_grdSearchFromCorrectionBulk(dtJnl);
                            clear();
                            Response.Redirect("ReEntered.aspx");
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
              //  Response.Write(dtj.ID);
                //  if (!string.IsNullOrEmpty(lblHidden.Text)) { dtj.ID = lblHidden.Text; }

                DataToJournal dtInqDet = (DataToJournal)Session["InquireDetails"];

                if (!string.IsNullOrEmpty(dtj.ID))
                {
                    dbcon.Delete_Row(dtj);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Sucessfully Deleted');", true);
                    lblErrMessage.Text = "Sucessfully Deleted";
                    dtJnl = (DataToJournal)Session["InquireDetails"];
                    Load_grdSearchFromCorrectionBulk(dtJnl);
                    clear();
                    Response.Redirect("ReEntered.aspx");


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
                // uLvl = "A";

                if (!string.IsNullOrEmpty(uLvl))
                {
                     if (uLvl == "E")
                    {
                        btnEnter.Visible = true;
                      //  btnNotApproved.Visible = true;
                      //  btnNotChecked.Visible = true;
                      //  btnApprove.Visible = false;
                       // btnCheck.Visible = false;
                        txtFromDate.Visible = true;
                        cmbJourneleTy.Visible = true;
                        txtJnlNo.Visible = true;
                        txtComment.Visible = true;
                        txtAccountNo.Visible = true;
                        txtRefNo.Visible = true;
                        grdSearchFromCorrection.Columns[18].Visible = false;
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

     

            txtRefNo.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtJnlNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;

            grdSearchFromCorrection.DataSource = null;
            grdSearchFromCorrection.DataBind();

          //  btnApprove.Visible = false;
           // btnCheck.Visible = false;
            btnEnter.Visible = false;
        }

        private void Load_grdSearchFromCorrectionBulk(DataToJournal dtJnl)
        {
            DbConnection dbcon = new DbConnection();

            try
            {
                DataSet dt = dbcon.Load_grdSearchFromCorrectionA(dtJnl);

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
                if (grdSearchFromCorrection.SelectedRow.Cells[15].Text.Trim() != "&nbsp;")
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
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromDate.Text))
            {
                if (DateTime.Now.Date < DateTime.Parse(txtFromDate.Text))
                {
                    txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }

        }
    }
}