using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class MonthDetail
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

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }

    public class MonthDetailWrapper
    {
        [JsonProperty("month")]
        public MonthDetail Month { get; set; }
    }

    public class MonthDetailResponse
    {
        [JsonProperty("data")]
        public MonthDetailWrapper Data { get; set; }
    }
}
