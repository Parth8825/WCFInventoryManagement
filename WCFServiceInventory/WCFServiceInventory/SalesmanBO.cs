using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceInventory
{
    public class SalesmanBO
    {
        //Declaring Salesman Variables
        private int _SalesmanId;
        private string _SalesmanName;
        private string _City;
        private float _Commision;

        // Get Set values
        public int SalesmanId
        {
            get { return _SalesmanId; }
            set { _SalesmanId = value; }
        }
        public string SalesmanName
        {
            get { return _SalesmanName; }
            set { _SalesmanName = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public float Commision
        {
            get { return _Commision; }
            set { _Commision = value; }
        }
    }
}