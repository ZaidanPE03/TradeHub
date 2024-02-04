namespace TradeHub.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string TradeOrdersEndpoint = $"{Prefix}/tradeorders";
        public static readonly string SellOrdersEndpoint = $"{Prefix}/sellorders";
        public static readonly string ProductsEndpoint = $"{Prefix}/Products";
    }
}
