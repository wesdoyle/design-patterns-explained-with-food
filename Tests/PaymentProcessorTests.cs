using FluentAssertions;
using RealisticDependencies.PaymentProcessing;
using Xunit;

namespace Tests {
    public class PaymentProcessorTests {
        [Theory]
        [InlineData(1d)]
        [InlineData(-23d)]
        [InlineData(3498d)]
        public void GiftCardProcessor_HandlePayment_Returns_Amount_in_Some_String(decimal amount) {
            var gcProcessor = new GiftCardProcessor();
            var response = gcProcessor.HandlePayment(amount);
            response.Should().Contain(amount.ToString());
            response.ToLower().Should().Contain("gift card");
        }

        [Theory]
        [InlineData(1d)]
        [InlineData(-23d)]
        [InlineData(3498d)]
        public void CreditCardProcessor_HandlePayment_Returns_Amount_in_Some_String(decimal amount) {
            var gcProcessor = new CreditCardProcessor();
            var response = gcProcessor.HandlePayment(amount);
            response.Should().Contain(amount.ToString());
            response.ToLower().Should().Contain("credit card");
        }
    }
}
