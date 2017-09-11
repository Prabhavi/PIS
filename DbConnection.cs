using PaymentInquiry.Beans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PaymentInquiry
{
    public class DbConnection
    {
        //Suspense
        private OleDbConnection GetConnectionConsolidate()
        {

            string connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='pmnt_consld@hqinfdb10'";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            return connection;
        }

        public DataSet GetDataSet(string sql)
        {

            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionConsolidate())
                {
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                }
            }

            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet GetOfflinePayments(Request req)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionConsolidate())
                {
                    sql = "SELECT acc_no, count_no, stub_no, trans_amt, pay_mode, agent, center,prov_code,area_code, trans_date FROM  offline_payments WHERE   ";

                    if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }

                    if (req.status_from_date.Equals(true))
                    {
                        sql = sql + " trans_date >= ?  and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        sql = sql + " trans_date <= ?  and ";
                    }

                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " trans_amt = " + req.amount + "  and ";
                    }

                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter_no = '" + req.counter_number + "' and ";
                    }

                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }

                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acc_no = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by trans_date desc ";

                    OleDbCommand cmd = new OleDbCommand(sql, connection);

                    cmd.Parameters.AddWithValue("trans_date", req.from_date);
                    cmd.Parameters.AddWithValue("trans_date", req.to_date);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        public DataSet GetOnlinePayments(Request req)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionConsolidate())
                {

                    sql = "SELECT acc_no, count_no, stub_no, trans_amt, pay_mode, agent, center,prov_code,area_code, trans_date FROM  dbadmin.online_payments WHERE   ";

                    if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }

                    if (req.status_from_date.Equals(true))
                    {
                        sql = sql + " trans_date >= ?  and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        sql = sql + " trans_date <= ?  and ";
                    }

                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " trans_amt = " + req.amount + "  and ";
                    }

                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter_no = '" + req.counter_number + "' and ";
                    }

                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }

                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acc_no = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by trans_date desc ";

                    OleDbCommand cmd = new OleDbCommand(sql, connection);

                    cmd.Parameters.AddWithValue("trans_date", req.from_date);
                    cmd.Parameters.AddWithValue("trans_date", req.to_date);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");

                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }
        //End of Suspense       

        //Provincial Summery
        public OleDbConnection GetConnectionProvince(string prov_code)
        {
            string connectionstring = "";
            //string Province = "OTHER";


            switch (prov_code)
            {
                case "1":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd ;Data Source='billing@wpninfdb1'";

                    break;
                case "2":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd ;Data Source='billing@wps1infdb2'";

                    break;
                case "3":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@ccinfdb1'";

                    break;
                case "4":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@hqinfdb5'";

                    break;
                case "5":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@cebcpdb2'";

                    break;
                case "6":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@uvainfdb1'";

                    break;
                case "7":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd ;Data Source='billing@cebcpdb1'";

                    break;
                case "8":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@nwpinfdb1'";

                    break;
                case "9":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@sabinfdb1'";

                    break;
                case "A":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@nwpinfdb1'";

                    break;
                case "B":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@spinfdb1'";

                    break;
                case "C":

                    connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billing@wps2infdb1'";

                    break;
                default:
                    connectionstring = "";

                    break;


            }

            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            return connection;
        }

        public DataSet GetSuspenseProvinceServers(Request req, string province)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionProvince(province))
                {
                    string fromDt = req.from_date.ToString("dd/MM/yyyy");
                    string toDate = req.to_date.ToString("dd/MM/yyyy");

                    sql = "SELECT acct_number, area_code,bill_cycle,crdt_code,susp_amount,trnsac_code,pmnt_date,lot_no,stub_no,counter_no FROM  suspense WHERE   ";


                    if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }

                    if (req.status_from_date.Equals(true))
                    {
                        //sql = sql + " pmnt_date <= ?  and ";
                        sql = sql + " pmnt_date >= '" + fromDt + "' and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        //sql = sql + " pmnt_date <= ?  and ";
                        sql = sql + " pmnt_date <= '" + toDate + "' and ";
                    }


                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " susp_amount = " + req.amount + "  and ";
                    }


                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter_no = '" + req.counter_number + "' and ";
                    }


                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }


                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acct_number = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by transac_date desc ";

                    // sql = sql.Trim();

                    ds = GetDataSetSuspenseProvinceServers(sql, province);

                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public DataSet GetDataSetSuspenseProvinceServers(string sql, string province)
        {

            DataSet ds = new DataSet();
            try
            {

                using (OleDbConnection connection = GetConnectionProvince(province))
                {
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                }

            }

            catch (Exception ex)
            {
            }

            return ds;
        }
        //End Provincial Summery

        //Bill Summery
        private OleDbConnection GetConnectionBillSmry()
        {
            OleDbConnection connection = new OleDbConnection();
            try
            {
               // string connectionstring = "Provider='Ifxoledbc.2';password=;User ID=;Data Source='billsmry@hqinfdb10'";
                connection.ConnectionString= "Provider='Ifxoledbc.2';password='mgrisd';User ID='mgrisd';Data Source='billsmry@hqinfdb10'";
                connection.Open();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connection;
        }

        public DataSet GetSuspensePaymentsBillSmry(Request req)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionBillSmry())
                {
                    string fromDt = req.from_date.ToString("dd/MM/yyyy");
                    string toDate = req.to_date.ToString("dd/MM/yyyy");

                    sql = "SELECT acct_number, area_code,bill_cycle,crdt_code,susp_amount,trnsac_code,pmnt_date,lot_no,stub_no,counter_no FROM  suspense WHERE   ";

                    if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }

                    if (req.status_from_date.Equals(true))
                    {
                        //sql = sql + " pmnt_date <= ?  and ";
                        sql = sql + " pmnt_date >= '" + fromDt + "' and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        //sql = sql + " pmnt_date <= ?  and ";
                        sql = sql + " pmnt_date <= '" + toDate + "' and ";
                    }

                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " susp_amount = " + req.amount + "  and ";
                    }

                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter_no = '" + req.counter_number + "' and ";
                    }

                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }

                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acct_number = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by transac_date desc ";

                    ds = GetDataSetBillSummery(sql);

                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        public string UserLevel(string uid)
        {
            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DataTable dataTable;
            try
            {
                   sql = "SELECT ulevel_code FROM appadm1.usermapping WHERE user_id = '" + uid + "'";
                    dataSet = GetDataSetBillSummery(sql);


                    if (dataSet != null)
                    {
                        if (dataSet.Tables.Count > 0)
                        {
                            dataTable = dataSet.Tables[0];
                            if (dataTable != null)
                            {
                                if (dataTable.Rows.Count > 0)
                                {
                                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                                    ualvl = dataRow["ulevel_code"].ToString().Trim();

                                }
                            }
                        
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ualvl;
        }

        public DataSet GetDataSetBillSummery(string sql)
        {

            DataSet ds = new DataSet();
            try
            {

                using (OleDbConnection connection = GetConnectionBillSmry())
                {
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public DataSet Load_grdSearchFromCorrection(DataToJournal dtJnl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");
            try
            {

                sql = "SELECT id, acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, " +
                      "tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, entered_by, " +
                      "entered_date,checked_by, checked_date, approved_by, approved_date FROM appadm1.sus_hsty " +
                      "WHERE acct_number like '" + dtJnl.AccNo + "%' AND counter_num like '" + dtJnl.CounterNo + "' AND " +
                      "stub_num = " + dtJnl.StubNo + " AND amount =" + Convert.ToDecimal(dtJnl.Amount) + " AND paydate='" + toDate + "'";
                dataSet = GetDataSetBillSummery(sql);
             }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        public DataSet get_Status(DataToJournal dtJnl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");
            try
            {

                sql = "SELECT id ,status1 FROM appadm1.sus_hsty " +
                      "WHERE acct_number like '" + dtJnl.AccNo + "%' AND counter_num like '" + dtJnl.CounterNo + "' AND " +
                      "stub_num = " + dtJnl.StubNo + " AND amount =" + Convert.ToDecimal(dtJnl.Amount) + " AND paydate='" + toDate + "'";
                dataSet = GetDataSetBillSummery(sql);
            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        public DataSet Load_grdSearchFromCorrectionA(DataToJournal dtJnl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DateTime dateTo;

       ////     if (DateTime.TryParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
         //   {
           //     dateTo = DateTime.ParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          ////  }
            //string toDate = dateTo.ToString("dd/MM/yyyy");
            try
            {
                   sql = "SELECT id, acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, " +
                          "tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, entered_by, " +
                          "entered_date,checked_by, checked_date, approved_by, approved_date FROM appadm1.sus_hsty " +
                          "WHERE (status1='NA') or (status1='NC') ";
                    dataSet = GetDataSetBillSummery(sql);

                    
            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        public DataSet Get_Check(string usl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
           // DateTime dateTo;
            string st = "";
            try
            {
                //using (OleDbConnection connection = GetConnectionBillSmry())
                
                    if (usl == "C")
                    {
                        st = "E";

                    }
                    else if (usl == "A")
                    {
                        st = "C";
                    }


                    sql = "SELECT id, acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, " +
                                                 "tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, entered_by, " +
                                                 "entered_date,checked_by, checked_date, approved_by, approved_date FROM appadm1.sus_hsty " +
                                                 "WHERE status1= '" + st + "'";

                    dataSet = GetDataSetBillSummery(sql);

                    //connection.Close();
                    return dataSet;
                

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet Delete_Row(DataToJournal dtJnl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");
            try
            {
               
                    sql = "Delete appadm1.sus_hsty " +
                          "WHERE id='" + dtJnl.ID + "'";
                dataSet = GetDataSetBillSummery(sql);                
            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        public string GetStatus(DataToJournal dtJnl)
        {
            string sts = "";
            string sql = "";
            DataSet dataSet;
            DataTable dataTable;

            try
            {
                
                    //OleDbCommand cmd = new OleDbCommand();
                    sql = "SELECT status1 FROM appadm1.sus_hsty WHERE id= '" + dtJnl.ID + "'";
                    dataSet = GetDataSetBillSummery(sql);

                    if (dataSet != null)
                    {
                        if (dataSet.Tables.Count > 0)
                        {
                            dataTable = dataSet.Tables[0];
                            if (dataTable != null)
                            {
                                if (dataTable.Rows.Count > 0)
                                {
                                    DataRow dataRow = dataSet.Tables[0].Rows[0];
                                    sts = dataRow["status1"].ToString().Trim();

                                }
                            }
                        }
                
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return sts;
        }

        public bool InsertEnteredDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");


            try
            {
                if ((!string.IsNullOrEmpty(dtJnl.RefNo)) && (!string.IsNullOrEmpty(dtJnl.cmbJourneleType)) && (!string.IsNullOrEmpty(dtJnl.AccNo)) && (!string.IsNullOrEmpty(dtJnl.txtJnlNo))  && (!string.IsNullOrEmpty(dtJnl.PayDate)))
                {

                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Insert INTO appadm1.sus_hsty(acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, entered_by, entered_date) " +
                              "Values ('" + dtInqDet.AccNo + "','" + dtInqDet.CounterNo + "'," + dtInqDet.StubNo + "," + Convert.ToDecimal(dtInqDet.Amount) + ",'" + toDate + "','" + dtInqDet.PayMode + "','" + dtInqDet.Agent + "','" + dtInqDet.Center + "','" + dtInqDet.AreaCode + "','" + dtInqDet.TransactionCode + "','" + dtJnl.Comment + "','" + dtJnl.RefNo + "','" + dtJnl.txtJnlNo + "','" + dtJnl.PayDate + "','" + dtJnl.AccNo + "','" + dtJnl.cmbJourneleType + "','" + dtJnl.JnlDate + "','E','" + dtJnl.Uname + "','" + dtJnl.Udate + "')";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        public bool UpdateEnteredDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;            
            string sql = string.Empty;
            try
            {
                using (OleDbConnection connection = GetConnectionBillSmry())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    sql = "Update appadm1.sus_hsty  SET comment='" + dtJnl.Comment + "', ref_no='" + dtJnl.RefNo + "', jnl_no='" + dtJnl.txtJnlNo + "', jnl_date='" + dtJnl.PayDate + "', set_off_to='" + dtJnl.AccNo + "', jnl_type='" + dtJnl.cmbJourneleType + "', jnl_post='" + dtJnl.JnlDate + "', status1='E', entered_by='" + dtJnl.Uname + "', entered_date='" + dtJnl.Udate + "' "+
                          "WHERE id='"+ dtJnl.ID+ "'";
                    cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }
        public bool UpdateReEnteredDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            try
            {
                using (OleDbConnection connection = GetConnectionBillSmry())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    sql = "Update appadm1.sus_hsty  SET comment='" + dtJnl.Comment + "', ref_no='" + dtJnl.RefNo + "', jnl_no='" + dtJnl.txtJnlNo + "', jnl_date='" + dtJnl.PayDate + "', set_off_to='" + dtJnl.AccNo + "', jnl_type='" + dtJnl.cmbJourneleType + "', jnl_post='" + dtJnl.JnlDate + "', status1='E', entered_by='" + dtJnl.Uname + "', entered_date='" + dtJnl.Udate + "' " +
                          "WHERE id='" + dtJnl.ID + "'";
                    cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        public bool InsertCheckedDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");


            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "E")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Insert INTO appadm1.sus_hsty(acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, checked_by, checked_date) " +
                              "Values ('" + dtInqDet.AccNo + "','" + dtInqDet.CounterNo + "'," + dtInqDet.StubNo + "," + Convert.ToDecimal(dtJnl.Amount) + ",'" + toDate + "','" + dtInqDet.PayMode + "','" + dtInqDet.Agent + "','" + dtInqDet.Center + "','" + dtInqDet.AreaCode + "','" + dtInqDet.TransactionCode + "','" + dtJnl.Comment + "','" + dtJnl.RefNo + "','" + dtJnl.txtJnlNo + "','" + dtJnl.PayDate + "','" + dtJnl.AccNo + "','" + dtJnl.cmbJourneleType + "','" + dtJnl.JnlDate + "','C','" + dtJnl.Uname + "','" + dtJnl.Udate + "')";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

       
        public bool UpdateCheckedDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "E")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Update appadm1.sus_hsty  SET  jnl_post='" + dtJnl.JnlDate + "', status1='C', checked_by='" + dtJnl.Uname + "', checked_date='" + dtJnl.Udate + "' " +
                            "WHERE id='" + dtJnl.ID + "'";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        public bool InsertApprovedDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtInqDet.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");

            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "C")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Insert INTO appadm1.sus_hsty(acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, approved_by, approved_date) " +
                              "Values ('" + dtInqDet.AccNo + "','" + dtInqDet.CounterNo + "'," + dtInqDet.StubNo + "," + Convert.ToDecimal(dtJnl.Amount) + ",'" + toDate + "','" + dtInqDet.PayMode + "','" + dtInqDet.Agent + "','" + dtInqDet.Center + "','" + dtInqDet.AreaCode + "','" + dtInqDet.TransactionCode + "','" + dtJnl.Comment + "','" + dtJnl.RefNo + "','" + dtJnl.txtJnlNo + "','" + dtJnl.PayDate + "','" + dtJnl.AccNo + "','" + dtJnl.cmbJourneleType + "','" + dtJnl.JnlDate + "','A','" + dtJnl.Uname + "','" + dtJnl.Udate + "')";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }


        public bool UpdateApprovedDetail(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "C")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Update appadm1.sus_hsty  SET   jnl_post='" + dtJnl.JnlDate + "', status1='A', approved_by='" + dtJnl.Uname + "', approved_date='" + dtJnl.Udate + "' " +
                            "WHERE id='" + dtJnl.ID + "'";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }


        public bool Reject_A(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "C")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Update appadm1.sus_hsty  SET   jnl_post='" + dtJnl.JnlDate + "', status1='NA', approved_by='" + dtJnl.Uname + "', approved_date='" + dtJnl.Udate + "' " +
                            "WHERE id='" + dtJnl.ID + "'";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;

        }

        //End Of Bill Summery

        //BUlk DB

        private OleDbConnection GetConnectionBulk()
        {

            string connectionstring = "Provider='Ifxoledbc.2';password=mgrisd ;User ID=mgrisd;Data Source='billhsbhq@hqinfdb5'";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            return connection;
        }

        public DataSet GetDataSetBulk(string sql)
        {

            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionBulk())
                {
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                }
            }

            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet GetBulkPayments(Request req)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionBulk())
                {
                    sql = "SELECT acc_nbr, counter, stub_no, paid_amt, pay_mode, agent_code, cent_code, actl_pay_date,post_blcy,cleared FROM  suspense WHERE   ";
                    /*if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }
                    */
                    if (req.status_from_date.Equals(true))
                    {
                        sql = sql + " actl_pay_date >= ?  and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        sql = sql + " actl_pay_date <= ?  and ";
                    }

                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " paid_amt = " + req.amount + "  and ";
                    }

                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter = '" + req.counter_number + "' and ";
                    }

                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }

                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acc_nbr = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by actl_pay_date desc ";

                    OleDbCommand cmd = new OleDbCommand(sql, connection);

                    cmd.Parameters.AddWithValue("actl_pay_date", req.from_date);
                    cmd.Parameters.AddWithValue("actl_pay_date", req.to_date);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        public bool Reject_C(DataToJournal dtJnl, DataToJournal dtInqDet)
        {
            bool success = false;
            string sql = string.Empty;
            try
            {
                DbConnection dbCon = new DbConnection();
                string sts = dbCon.GetStatus(dtJnl);
                if (sts == "E")
                {
                    using (OleDbConnection connection = GetConnectionBillSmry())
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        sql = "Update appadm1.sus_hsty  SET   jnl_post='" + dtJnl.JnlDate + "', status1='NC', checked_by='" + dtJnl.Uname + "', checked_date='" + dtJnl.Udate + "' " +
                            "WHERE id='" + dtJnl.ID + "'";
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        success = true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;

        }

        public DataSet GetRunningBulkPayments(Request req)
        {
            string sql = "";
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection connection = GetConnectionBulk())
                {
                    sql = "SELECT acc_nbr, counter, stub_no, paid_amt, pay_mode, agent_code, cent_code, actl_pay_date, pro_blcy FROM  dbadmin.payment WHERE   ";
                    /*if (req.status_area.Equals(true))
                    {
                        sql = sql + " area_code = '" + req.area + "' and ";
                    }
                    */
                    if (req.status_from_date.Equals(true))
                    {
                        sql = sql + " actl_pay_date >= ?  and ";
                    }

                    if (req.status_to_date.Equals(true))
                    {
                        sql = sql + " actl_pay_date <= ?  and ";
                    }

                    if (req.status_amount.Equals(true))
                    {
                        sql = sql + " paid_amt = " + req.amount + "  and ";
                    }

                    if (req.status_counter_number.Equals(true))
                    {
                        sql = sql + " counter = '" + req.counter_number + "' and ";
                    }

                    if (req.status_stub_number.Equals(true))
                    {
                        sql = sql + " stub_no = '" + req.stub_number + "' and ";
                    }

                    if (req.status_account_number.Equals(true))
                    {
                        sql = sql + " acc_nbr = '" + req.account_number + "' and ";
                    }

                    sql = sql.Trim().Remove(sql.Length - 4);

                    sql = sql + " order by actl_pay_date desc ";

                    OleDbCommand cmd = new OleDbCommand(sql, connection);

                    cmd.Parameters.AddWithValue("actl_pay_date", req.from_date);
                    cmd.Parameters.AddWithValue("actl_pay_date", req.to_date);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(cmd);
                    ad2.Fill(ds, "dataset");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        public DataSet Load_grdSearchFromCorrectionBulk(DataToJournal dtJnl)
        {

            string ualvl = string.Empty;
            string sql = "";
            DataSet dataSet;
            DateTime dateTo;

            if (DateTime.TryParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
            {
                dateTo = DateTime.ParseExact(dtJnl.PayDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string toDate = dateTo.ToString("dd/MM/yyyy");
            try
            {

                sql = "SELECT id, acct_number, counter_num, stub_num, amount, paydate, paymode, agent, center, area_code, " +
                      "tans_code, comment, ref_no, jnl_no, jnl_date, set_off_to, jnl_type, jnl_post, status1, entered_by, " +
                      "entered_date,checked_by, checked_date, approved_by, approved_date FROM appadm1.sus_hsty " +
                      "WHERE acct_number like '" + dtJnl.AccNo + "%' AND counter_num like '" + dtJnl.CounterNo + "' AND " +
                      "stub_num = " + dtJnl.StubNo + " AND amount =" + Convert.ToDecimal(dtJnl.Amount) + " AND paydate='" + toDate + "'";
                dataSet = GetDataSetBillSummery(sql);


            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

       
       


        //Bulk DB coonecting with journal

        //END BUlk DB

    }
}