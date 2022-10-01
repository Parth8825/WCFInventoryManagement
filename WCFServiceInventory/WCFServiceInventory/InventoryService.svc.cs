using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceInventory
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryService.svc or InventoryService.svc.cs at the Solution Explorer and start debugging.
    public class InventoryService : ISalesmanService, ICustomerService, IOrderService
    {

        // Salesman
        public int InsertNewSalesman(SalesmanBO newSalesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.InsertSalesman(newSalesman);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateSalesman(SalesmanBO salesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.UpdateSalesman(salesman);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteSalesman(SalesmanBO salesman)
        {
            try
            {
                SalesmanDA dataAccess = new SalesmanDA();
                return dataAccess.DeleteSalesman(salesman);
            }
            catch
            {
                return 0;
            }
        }

        //Customer
        public int InsertNewCustomer(CustomerBO newCustomer)
        {
            try
            {
                CustomerDA dataAccess = new CustomerDA();
                return dataAccess.InsertCustomer(newCustomer);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateCustomer(CustomerBO customer)
        {
            try
            {
                CustomerDA dataAccess = new CustomerDA();
                return dataAccess.UpdateCustomer(customer);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteCustomer(CustomerBO customer)
        {
            try
            {
                CustomerDA dataAccess = new CustomerDA();
                return dataAccess.DeleteCustomer(customer);
            }
            catch
            {
                return 0;
            }
        }

        //Order
        public int InsertNewOrder(OrderBO newOrder)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.InsertOrder(newOrder);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateOrder(OrderBO order)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.UpdateOrder(order);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteOrder(OrderBO order)
        {
            try
            {
                OrderDA dataAccess = new OrderDA();
                return dataAccess.DeleteOrder(order);
            }
            catch
            {
                return 0;
            }
        }
    }
}
