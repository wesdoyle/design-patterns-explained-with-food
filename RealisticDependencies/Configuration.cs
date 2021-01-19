namespace RealisticDependencies {
    public static class Configuration {
        public static string ConnectionString => "tcp://foo.bar:1986";
        public static int MaxConnections => 3;
        public static int MinPremiumPointsBalance => 3;
    }
}
