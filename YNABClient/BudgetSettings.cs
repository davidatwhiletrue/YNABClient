using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class BudgetSettings
    {
        [JsonProperty("date_format")]
        public DateFormat DateFormat { get; set; }

        [JsonProperty("currency_format")]
        public CurrencyFormat CurrencyFormat { get; set; }
    }

    public class BudgetSettingsResponse
    {
        [JsonProperty("data")]
        public BudgetSettingsWrapper Data { get; set; }
    }

    public class BudgetSettingsWrapper
    {
        [JsonProperty("settings")]
        public BudgetSettings Settings { get; set; }
    }
}
