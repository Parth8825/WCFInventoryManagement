using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceInventory
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISalesmanService" in both code and config file together.
    [ServiceContract]
    public interface ISalesmanService
    {
        [OperationContract]
        int InsertNewSalesman(SalesmanBO newSalesman);

        [OperationContract]
        int UpdateSalesman(SalesmanBO salesman);

        [OperationContract]
        int DeleteSalesman(SalesmanBO salesman);

    }
}
