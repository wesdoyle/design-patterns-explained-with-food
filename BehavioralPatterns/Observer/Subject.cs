using System;
using System.Collections.Generic;
using System.Threading;

namespace BehavioralPatterns.Observer {
    public class Subject : ISubject {
        public ObserverState State { get; set; } = new(); 

        // Basic list of subscribers
        private readonly List<IObserver> _observers = new();

        // The subscription management methods.
        public void Attach(IObserver observer) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
            Console.ResetColor();
        }

        public void Detach(IObserver observer) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            _observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
            Console.ResetColor();
        }

        // Trigger an update in each subscriber.
        public void Notify() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Subject: notifying all observers");
            foreach (var observer in _observers) {
                observer.Update(this);
            }
            Console.ResetColor();
        }

        public void UpdateEmailAddress() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Updating email");
            State = new ObserverState {
                LastUpdated = DateTime.UtcNow, 
                Message = "EmailUpdate"
            };
            Console.WriteLine($"Subject: State has just changed: {State}");
            Thread.Sleep(500);
            Notify();
            Console.ResetColor();
        }
    }
}
