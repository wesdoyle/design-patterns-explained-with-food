using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;
using RealisticDependencies;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class Cartonizer : AbstractHandler {
        private readonly IApplicationLogger _logger;

        public Cartonizer(IApplicationLogger logger) {
            _logger = logger;
        }
        
        public override KombuchaSale Handle(KombuchaSale request) {
            if (request.SaleType == SaleType.InHouse) {
                return base.Handle(request);
            }

            if (request.SaleType != SaleType.Online) return base.Handle(request);

            _logger.LogInfo("Cartonizing online order.", ConsoleColor.Green);

            return base.Handle(request);
        }
    }
}
