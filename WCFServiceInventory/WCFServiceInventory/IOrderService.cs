using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceInventory
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<OrderBO> GetOrder();

        [OperationContract]
        int InsertNewOrder(OrderBO newOrder);

        [OperationContract]
        int UpdateOrder(OrderBO order);

        [OperationContract]
        int DeleteOrder(OrderBO order);
    }
}
