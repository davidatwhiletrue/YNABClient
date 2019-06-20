using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class BudgetSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_modified_on")]
        public string LastModifiedOn { get; set; }

        [JsonProperty("first_month")]
        public string FirstMonth { get; set; }

        [JsonProperty("last_month")]
        public string LastMonth { get; set; }

        [JsonProperty("date_format")]
        public DateFormat DateFormat { get; set; }

        [JsonProperty("currency_format")]
        public CurrencyFormat CurrencyFormat { get; set; } 
    }

    public class BudgetSummaryResponse
    {
        [JsonProperty("data")]
        public BudgetSummaryWrapper Data { get; set; }
    }

    public class BudgetSummaryWrapper
    {
        [JsonProperty("budgets")]
        public List<BudgetSummary> Budgets { get; set; }
    }
}
