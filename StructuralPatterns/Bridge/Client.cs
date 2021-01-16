using System;

namespace StructuralPatterns.Bridge {
    public class Client {
        public void ClientCode(FarmersMarketVendor abstraction) {
            Console.WriteLine(abstraction.ProcessCustomerPayment());
        }
    }
}
