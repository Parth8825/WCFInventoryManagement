using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFInventoryHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFServiceInventory.InventoryService)))
            {
                host.Open();
                Console.WriteLine("Host started");
                Console.ReadLine();
            }
        }
    }
}
