namespace BehavioralPatterns.Mediator {
    public abstract class FoodCart {
        protected IMediator _mediator;

        public FoodCart(IMediator mediator = null) {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator) {
            _mediator = mediator;
        }
    }
}
