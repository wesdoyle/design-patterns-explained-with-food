using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;
using RealisticDependencies;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class ShippingLabelPrinter : AbstractStep {
        private readonly IApplicationLogger _logger;

        public ShippingLabelPrinter(IApplicationLogger logger) {
            _logger = logger;
        }
        
        public override KombuchaSale Handle(KombuchaSale request) {
            if (request.SaleType == SaleType.InHouse) {
                return base.Handle(request);
            }

            if (request.SaleType == SaleType.Online) {
                _logger.LogInfo("Printing shipping label for online order.", ConsoleColor.Green);
                return base.Handle(request);
            }

            return base.Handle(request);
        }
    }
}
