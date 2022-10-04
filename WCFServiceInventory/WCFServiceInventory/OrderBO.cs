using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class OrderBO
    {
        // Declaring Order variables
        private int _orderNo;
        private double _purchAmt;
        private DateTime _orderDate;
        private int _customerId;
        private int _salesmanId;

        // Get Set values
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        public double PurchAmt
        {
            get { return _purchAmt; }
            set { _purchAmt = value; }
        }
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
            }
        }
        public int SalesmanId
        {
            get { return _salesmanId; }
            set
            {
                _salesmanId = value;
            }
        }
    }
}