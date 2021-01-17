namespace BehavioralPatterns.Mediator {
    public abstract class FoodCart {
        protected IMediator Mediator;

        protected FoodCart(IMediator mediator = null) {
            Mediator = mediator;
        }

        public void SetMediator(IMediator mediator) {
            Mediator = mediator;
        }
    }
}
