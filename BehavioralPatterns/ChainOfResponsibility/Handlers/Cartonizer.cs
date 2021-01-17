using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class Cartonizer : AbstractHandler {
        public override KombuchaSale Handle(KombuchaSale request) {
            Console.ForegroundColor = ConsoleColor.Green;
            if (request.SaleType == SaleType.InHouse) {
                return base.Handle(request);
            }

            if (request.SaleType != SaleType.Online) return base.Handle(request);

            Console.WriteLine("Cartonizing online order.");
            Console.ResetColor();

            return base.Handle(request);

        }
    }
}
