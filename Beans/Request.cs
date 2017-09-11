using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentInquiry.Beans
{
    public class Request
    {
        public string area { get; set; }
        public bool status_area { get; set; }

        public DateTime from_date { get; set; }
        public bool status_from_date { get; set; }

        public DateTime to_date { get; set; }
        public bool status_to_date { get; set; }

        public decimal amount { get; set; }
        public bool status_amount { get; set; }

        public string account_number { get; set; }
        public bool status_account_number { get; set; }

        public string counter_number { get; set; }
        public bool status_counter_number { get; set; }

        public string stub_number { get; set; }
        public bool status_stub_number { get; set; }

    }
}