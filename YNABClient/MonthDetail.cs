using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class MonthDetail : MonthSummary
    {
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
