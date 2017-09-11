using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentInquiry.Beans
{
    public class DataToJournal
    {
        public string ID { get; set; }
        public string AccNo { get; set; }
        public string CounterNo { get; set; }
        public string StubNo { get; set; }
        public string Amount { get; set; }
        public string PayDate { get; set; }
        public string PayMode { get; set; }
        public string Agent { get; set; }
        public string Center { get; set; }
        public string AreaCode { get; set; }
        public string TransactionCode { get; set; }
        public string RefNo { get; set; }
        public string Comment { get; set; }
        public string cmbJourneleType { get; set; }
        public string  txtJnlNo { get; set; }
        public string Uname { get; set; }
        public string Udate { get; set; }
        public string JnlDate { get; set; }
        public string bill_cycle { get; set; }
    }
}