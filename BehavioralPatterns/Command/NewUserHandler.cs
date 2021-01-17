using System;

namespace BehavioralPatterns.Command {
    public class NewUserHandler {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command) {
            _onStart = command;
        }

        public void SetOnFinish(ICommand command) {
            _onFinish = command;
        }

        public void SignUpUser() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (_onStart != null) {
                Console.WriteLine("Running pre-process hook.");
                _onStart.Execute();
            }

            Console.WriteLine("New user is signed up.");

            if (_onFinish == null) return;
            Console.WriteLine("Running post-process hook.");
            _onFinish.Execute();
            Console.ResetColor();
        }
    }
}
