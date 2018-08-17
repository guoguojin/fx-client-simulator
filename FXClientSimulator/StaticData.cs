using System.Collections.Generic;

namespace FXClientSimulator {
    public class StaticData {
        public static string[] Symbols = new[] { "", "AUD/USD", "EUR/CHF", "EUR/GBP", "EUR/NOK", "EUR/PLN", "EUR/SEK", "EUR/USD", "EUR/JPY", "GBP/USD", "USD/CAD", "USD/CHF", "USD/DKK", "USD/NOK", "USD/SEK", "USD/JPY", "USD/ZAR" };

        public static string[] Currencies = new[] { "", "AUD", "DKK", "EUR", "CHF", "GBP", "NOK", "PLN", "SEK", "USD", "JPY", "CAD", "DKK", "ZAR" };

        public static string[] Tiers = new[] { "TIER1", "TIER2" };

        public static string[] RFQTypes = new[] { "SPOT", "FORWARD", "SWAP" };

        public static string[] SwapLegs = new[] { "NEAR", "FAR" };

        public static string[] Tenors = new[] {"SP", "ON", "TN", "SN", "1W", "2W", "3W", "1M", "2M", "3M", "4M", "5M", "6M", "7M", "8M", "9M", "10M", "11M", "12M", "15M", "18M", "21M", "24M", "36M", "48M", "60M"};

        public enum Side {
            Buy,
            Sell
        }

        public static Dictionary<string, string> OrderTypes = new Dictionary<string, string> {
                                                                                                 {"Market", "1"},
                                                                                                 {"Stop Loss", "3"},
                                                                                                 {"Take Profit", "T"},
                                                                                                 {"Benchmark", "X"},
                                                                                                 {"Call Order", "R"}
                                                                                             };

        public static Dictionary<string, string> MultiLegOrderTypes = new Dictionary<string, string> {
                                                                                                 {"If Done", "2"},
                                                                                                 {"OCO", "1"},
                                                                                                 {"If Done OCO", "9"}
                                                                                             };

        public static Dictionary<string, string> TIFs = new Dictionary<string, string> {
                                                                                                 {"GFD", "0"},
                                                                                                 {"GTC", "1"},
                                                                                                 {"GTD", "6"},                       
                                                                                                 //{"GFTD", "9"} 
                                                                                             };

        public static string[] Sides = new[] { "Buy", "Sell" };

        public static string[] TimeZones = new[] { "Europe/Madrid", "Europe/London" };       
    }
}
