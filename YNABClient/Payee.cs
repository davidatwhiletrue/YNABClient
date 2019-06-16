using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class Payee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("transfer_account_id")]
        public string TransferAccountId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class PayeeWrapper
    {
        [JsonProperty("payee")]
        public Payee Payee { get; set; }
    }

    public class PayeeResponse
    {
        [JsonProperty("data")]
        public PayeeWrapper Data { get; set; }
    }

    public class PayeesWrapper
    {
        [JsonProperty("payees")]
        public List<Payee> Payees { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }

    public class PayeesResponse
    {
        [JsonProperty("data")]
        public PayeesWrapper Data { get; set; }
    }
}
