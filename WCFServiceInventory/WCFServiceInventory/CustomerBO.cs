using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class CustomerBO
    {
        //Declaring Customer variables
        private int _CustomerId;
        private string _CustomerName;
        private string _City;
        private double _Grade;
        private int _SalesId;

        //Get Set values
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
            }
        }

        public double Grade
        {
            get { return _Grade; }
            set
            {
                _Grade = value;
            }
        }

        public int SalesId
        {
            get { return _SalesId; }
            set
            {
                _SalesId = value;
            }
        }
    }
}