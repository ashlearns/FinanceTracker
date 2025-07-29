namespace FinanceTracker.Helpers
{
    // This static class acts as a utility to provide symbols for various currencies.
    // It is used to convert standardized currency codes into their respective display symbols.
    public static class CurrencyHelper
    {
        // This method takes a string parameter 'code' representing a currency code (like "USD", "INR").
        // It returns a human-readable symbol for that currency to be displayed in the UI.
        // The method uses a 'switch expression' to match known codes.
        // If the currency code doesn't match any case, it defaults to "$" for USD.

        public static string GetCurrencySymbol(string code)
        {
            return code switch
            {
                "USD" => "$",    // United States Dollar
                "INR" => "₹",    // Indian Rupee
                "EUR" => "€",    // Euro 
                "NPR" => " रु",  // Nepalese Rupee
                _ => "$"         // Default fallback to USD if no match is found
            };
        }
    }
}
