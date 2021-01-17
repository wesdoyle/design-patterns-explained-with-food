using System;

namespace BehavioralPatterns.Memento {
    public class ConcreteMemento : IMemento {

        private readonly string _state;
        private readonly DateTime _date;

        public ConcreteMemento(string state) {
            _state = state;
            _date = DateTime.Now;
        }

        public string GetState() => _state;

        public string GetName() => $"{_date} / ({_state.Substring(0, 9)})...";

        public DateTime GetDate() => _date;
    }
}
