using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealisticDependencies;
using RealisticDependencies.Models;

namespace BehavioralPatterns.Visitor.Components {
    public class FloristDataProcessor : IVisitable<Report> {
        private readonly ISendsEmails _emailer;
        private readonly Database _database;
        private Person _customer;
        public int GetCustomerAge() => _customer.Age;
        public string GetCustomerName() => _customer.Name;

        public FloristDataProcessor(ISendsEmails emailer, Database database) {
            _emailer = emailer;
            _database = database;
            Task.Run(ConnectToDatabase).Wait();
        }

        public void SetCustomer(Person customer) {
            _customer = customer;
        }

        private async Task ConnectToDatabase() {
            await _database.Connect();
        }

        public async Task EmailReceipt(Person customer) {
            var email = new EmailMessage(customer.Email, "Thank you for your Florist order. Here is your receipt.");
            await _emailer.SendMessage(email);
        }

        public async Task RecordTransaction(Order order) {
            var orderId = Guid.NewGuid().ToString();
            await _database.WriteData(orderId, order.ToString());
        }

        public List<decimal> GetDailyOrderAmounts() {
            var rng = new Random();
            var dailyOrders = new List<decimal>();
            for (var i = 0; i < 1000; i++) {
                var orderAmount = (decimal) Math.Round(rng.NextDouble() * 100, 2);
                dailyOrders.Add(orderAmount);
            }
            return dailyOrders;
        }

        public List<Person> GetMonthlyCustomerProfiles() {
            var rng = new Random();
            var customers = new List<Person>();
            for (var i = 0; i < 1000; i++) {
                var age = rng.Next(18, 100);
                var person = new Person {Age = age, Name = "Rose", Email = "foo@example.com"};
                customers.Add(person);
            }
            return customers;
        }

        public Report Accept(IVisitor<Report> visitor) {
            return visitor.Visit(this);
        }
    }
}
