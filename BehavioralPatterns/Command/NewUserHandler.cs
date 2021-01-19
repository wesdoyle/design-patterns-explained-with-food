using System;
using RealisticDependencies;

namespace BehavioralPatterns.Command {
    public class NewUserHandler {
        private readonly IApplicationLogger _logger;
        private ICommand _onStart;
        private ICommand _onFinish;

        public NewUserHandler(IApplicationLogger logger) {
            _logger = logger;
        }

        public void SetOnStart(ICommand command) {
            _onStart = command;
        }

        public void SetOnFinish(ICommand command) {
            _onFinish = command;
        }

        public void SignUpUser() {
            if (_onStart != null) {
                _logger.LogInfo("Running pre-process hook.", ConsoleColor.DarkMagenta);
                _onStart.Execute();
            }

            _logger.LogInfo("New user is signed up.", ConsoleColor.DarkMagenta);

            if (_onFinish == null) return;
            _logger.LogInfo("Running post-process hook.", ConsoleColor.DarkMagenta);
            _onFinish.Execute();
        }
    }
}
