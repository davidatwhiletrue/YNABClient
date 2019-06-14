using System;
using Newtonsoft.Json;

namespace ynab
{
    public class DateFormat
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
