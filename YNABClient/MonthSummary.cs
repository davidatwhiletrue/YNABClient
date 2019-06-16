using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class MonthSummary
    {
        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("income")]
        public long Income { get; set; }

        [JsonProperty("budgeted")]
        public long Budgeted { get; set; }

        [JsonProperty("activity")]
        public long Activity { get; set; }

        [JsonProperty("to_be_budgeted")]
        public long ToBeBudgeted { get; set; }

        [JsonProperty("age_of_money")]
        public long AgeOfMoney { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class MonthSummaryWrapper
    {
        [JsonProperty("months")]
        public List<MonthSummary> Months { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }

    public class MonthSummaryResponse
    {
        [JsonProperty("data")]
        public MonthSummaryWrapper Data { get; set; }
    }
}
