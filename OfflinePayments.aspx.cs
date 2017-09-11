using beans.exceptions.db;
using PaymentInquiry.Beans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentInquiry
{
    public partial class OfflinePayments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadArea();
                    Session["OnLine"] = null;
                    Session["OffLine"] = null;
                    Session["SuspensePaymentsBillSmry"] = null;
                    Session["SuspenseProvincePaymentsBillSmry"] = null;
                    Session["Bulk"] = null;
                    Session["BulkRunning"] = null;
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

        private void LoadArea()
        {
            try
            {
                Suspense.WebServiceSoapClient a = new Suspense.WebServiceSoapClient();
                cmbArea.DataSource = a.GetAreas();
                cmbArea.DataTextField = "area";
                cmbArea.DataValueField = "area_code";
                cmbArea.DataBind();

                cmbArea.Items.Insert(0, new ListItem("-SELECT-", String.Empty));
                cmbArea.SelectedIndex = 0;
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

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            LoadArea();
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCounterNum.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtStubNo.Text = string.Empty;
            grdSearchDetails.DataSource = null;
            grdSearchDetails.DataBind();
        }

        protected void btnSearch__Click(object sender, ImageClickEventArgs e)
        {
            int selectedItem = 0;
            grdSearchDetails.DataSource = null;
            grdSearchDetails.DataBind();
            try
            {
                DateTime datefrom;
                DateTime dateTo;


                Request rqtS = new Request();

                if (!string.IsNullOrEmpty(txtAccountNo.Text))
                {
                    rqtS.account_number = txtAccountNo.Text;
                    rqtS.status_account_number = true;
                    selectedItem = selectedItem + 1;
                }

                if (!string.IsNullOrEmpty(txtAmount.Text))
                {
                    rqtS.amount = decimal.Parse(txtAmount.Text);
                    rqtS.status_amount = true;
                    selectedItem = selectedItem + 1;
                }

                if (cmbArea.SelectedItem.Text != "-SELECT-")
                {
                    rqtS.area = cmbArea.SelectedItem.Value;
                    rqtS.status_area = true;
                    selectedItem = selectedItem + 1;
                }

                if (!string.IsNullOrEmpty(txtFromDate.Text))
                {
                    if (DateTime.TryParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datefrom))
                    {
                        datefrom = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        rqtS.from_date = datefrom;
                        rqtS.status_from_date = true;
                        selectedItem = selectedItem + 1;
                    }
                }

                if (!string.IsNullOrEmpty(txtToDate.Text))
                {
                    if (DateTime.TryParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                    {
                        dateTo = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        rqtS.to_date = dateTo;
                        rqtS.status_to_date = true;
                        selectedItem = selectedItem + 1;
                    }
                }

                if (!string.IsNullOrEmpty(txtCounterNum.Text))
                {
                    rqtS.counter_number = txtCounterNum.Text;
                    rqtS.status_counter_number = true;
                    selectedItem = selectedItem + 1;
                }

                if (!string.IsNullOrEmpty(txtStubNo.Text))
                {
                    rqtS.stub_number = txtStubNo.Text;
                    rqtS.status_stub_number = true;
                    selectedItem = selectedItem + 1;
                }

                if (selectedItem > 0)
                {
                    DbConnection dbCon = new PaymentInquiry.DbConnection();
                    DataSet dt = dbCon.GetOfflinePayments(rqtS);

                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        Session["OffLine"] = dt;
                        grdSearchDetails.DataSource = dt;
                        grdSearchDetails.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('No data for this search');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert !!!", "alert('Select Atleast one Search Criteria');", true);
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

        protected void grdSearchDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }

            DataSet ds = (DataSet)Session["OffLine"];


            DataView sortedView = new DataView(ds.Tables[0]);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            Session["SortedView"] = sortedView;
            grdSearchDetails.DataSource = sortedView;
            grdSearchDetails.DataBind();
        }

        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }

        protected void grdSearchDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserName"] != null)
                {
                    DataToJournal dtJnl = new DataToJournal();
                    dtJnl.AccNo = grdSearchDetails.SelectedRow.Cells[1].Text.Trim();
                    dtJnl.CounterNo = grdSearchDetails.SelectedRow.Cells[2].Text.Trim();
                    dtJnl.StubNo = grdSearchDetails.SelectedRow.Cells[3].Text.Trim();
                    dtJnl.Amount = grdSearchDetails.SelectedRow.Cells[4].Text.Trim();
                    dtJnl.PayDate = grdSearchDetails.SelectedRow.Cells[5].Text.Trim();
                    dtJnl.PayMode = grdSearchDetails.SelectedRow.Cells[6].Text.Trim();
                    dtJnl.Agent = grdSearchDetails.SelectedRow.Cells[7].Text.Trim();
                    dtJnl.Center = grdSearchDetails.SelectedRow.Cells[7].Text.Trim();

                    Session["DataToJournalOffline"] = dtJnl;
                    Session["DataToJournalConsolidated"] = null;
                    Response.Redirect("~/SendToledger.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert('Sign into system before proceed'); ", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error !!!", "alert(" + ex.Message + ");", true);
            }
        }
    }
}