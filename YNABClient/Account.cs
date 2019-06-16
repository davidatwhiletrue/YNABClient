using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class Account
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("on_budget")]
        public bool OnBudget { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("note")]
        public string Note{ get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("cleared_balance")]
        public long ClearedBalance { get; set; }

        [JsonProperty("uncleared_balance")]
        public long UnclearedBalance { get; set; }

        [JsonProperty("transfer_payee_id")]
        public string TransferPayeeId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class AccountResponse
    {
        [JsonProperty("data")]
        public AccountWrapper Data { get; set; }
    }

    public class AccountWrapper
    {
        [JsonProperty("account")]
        public Account Account { get; set; }
    }

    public class AccountsResponse
    {
        [JsonProperty("data")]
        public AccountsWrapper Data { get; set; }
    }

    public class AccountsWrapper
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }
}
