using System.Threading.Tasks;
using RealisticDependencies;
using RealisticDependencies.Models;

namespace BehavioralPatterns.Visitor.Components {
    public class BakeryOrderProcessor : IVisitable {
        private readonly ISendsEmails _emailer;
        public decimal OrderTotal { get; set; }
        public Person Customer { get; set; }
        public int GetCustomerAge() => Customer.Age;
        public string GetCustomerName() => Customer.Name;

        public BakeryOrderProcessor(ISendsEmails emailer) {
            _emailer = emailer;
        }

        public async Task EmailReceipt() {
            var email = new EmailMessage(Customer.Email, "Thank you for your Bakery order. Here is your receipt.");
            await _emailer.SendMessage(email);
        }

        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
