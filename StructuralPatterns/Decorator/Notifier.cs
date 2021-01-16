using System.Threading.Tasks;

namespace StructuralPatterns.Decorator {
    public abstract class Notifier {
        public abstract Task HandleTableReadyMessage();
    }
}
