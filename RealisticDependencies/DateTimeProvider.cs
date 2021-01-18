using System;

namespace RealisticDependencies {
    public class DateTimeProvider : IDateTimeProvider {
        public DateTimeProvider() { }
        public DateTime GetCurrentTimeUtc() => DateTime.UtcNow;
    }

    public interface IDateTimeProvider {
        public DateTime GetCurrentTimeUtc();
    }
}
