using System;
using Newtonsoft.Json;

namespace ynab
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class UserResponse
    {
        [JsonProperty("data")]
        public UserWrapper Data { get; set; }
    }

    public class UserWrapper
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
