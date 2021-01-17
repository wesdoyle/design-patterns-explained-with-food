namespace BehavioralPatterns.State {
    public abstract class ApplicationState {
        protected Context Context;

        public void SetContext(Context context) {
            Context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }
}
