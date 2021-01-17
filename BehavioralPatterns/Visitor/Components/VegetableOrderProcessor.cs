using System;
using RealisticDependencies;
using RealisticDependencies.Models;

namespace BehavioralPatterns.Visitor.Components {
    public class VegetableOrderProcessor : IVisitable {

        private readonly ISendsEmails _emailer;
        public decimal OrderTotal { get; set; }
        public Person Customer { get; set; }
        public int GetCustomerAge() => Customer.Age;
        public string GetCustomerName() => Customer.Name;
        public VegetableOrderProcessor(ISendsEmails emailer) {
            _emailer = emailer;
        }
        public void Checkout() {
            Console.WriteLine($"Completing order for customer: {Customer.Name}. Total: {OrderTotal}");
        }
        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
