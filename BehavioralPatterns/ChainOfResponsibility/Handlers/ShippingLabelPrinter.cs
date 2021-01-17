using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class ShippingLabelPrinter : AbstractHandler {
        public override KombuchaSale Handle(KombuchaSale request) {
            Console.ForegroundColor = ConsoleColor.Green;
            if (request.SaleType == SaleType.InHouse) {
                return base.Handle(request);
            }

            if (request.SaleType == SaleType.Online) {
                Console.WriteLine("Printing shipping label for online order.");
                return base.Handle(request);
            }

            Console.ResetColor();
            return base.Handle(request);
        }
    }
}
