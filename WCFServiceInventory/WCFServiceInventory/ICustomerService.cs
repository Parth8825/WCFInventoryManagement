using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceInventory
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<CustomerBO> GetCustomer();

        [OperationContract]
        int InsertNewCustomer(CustomerBO newCustomer);

        [OperationContract]
        int UpdateCustomer(CustomerBO customer);

        [OperationContract]
        int DeleteCustomer(CustomerBO customer);
    }
}
