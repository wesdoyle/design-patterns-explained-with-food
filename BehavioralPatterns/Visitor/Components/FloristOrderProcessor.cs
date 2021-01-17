using System.Threading.Tasks;
using RealisticDependencies;
using RealisticDependencies.Models;

namespace BehavioralPatterns.Visitor.Components {
    public class FloristOrderProcessor : IVisitable {
        private readonly ISendsEmails _emailer;
        private readonly Database _database;
        public decimal OrderTotal { get; set; }
        public Person Customer { get; set; }
        public int GetCustomerAge() => Customer.Age;
        public string GetCustomerName() => Customer.Name;

        public FloristOrderProcessor(ISendsEmails emailer, Database database) {
            _emailer = emailer;
            _database = database;
            Task.Run(ConnectToDatabase).Wait();
        }

        private void ConnectToDatabase() {
            throw new System.NotImplementedException();
        }

        public async Task EmailReceipt() {
            var email = new EmailMessage(Customer.Email, "Thank you for your Florist order. Here is your receipt.");
            await _emailer.SendMessage(email);
        }

        public async Task RecordTransaction() {
            _database.WriteRecord();
        }

        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
