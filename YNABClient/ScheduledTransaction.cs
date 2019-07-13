using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class ScheduledTransactionSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date_first")]
        public string DateFirst { get; set; }

        [JsonProperty("date_next")]
        public string DateNext { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("flag_color")]
        public string FlagColor { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("payee_id")]
        public string PayeeId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("transfer_account_id")]
        public string TransferAccountId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class ScheduledTransactionDetail : ScheduledTransactionSummary
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("payee_name")]
        public string PayeeName { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("subtransactions")]
        public List<ScheduledSubTransaction> SubTransactions { get; set; }
    }

    public class ScheduledTransactionWrapper
    {
        [JsonProperty("scheduled_transaction")]
        public ScheduledTransactionDetail ScheduledTransaction { get; set; }
    }

    public class ScheduledTransactionResponse
    {
        [JsonProperty("data")]
        public ScheduledTransactionWrapper Data { get; set; }
    }

    public class ScheduledTransactionsWrapper
    {
        [JsonProperty("scheduled_transactions")]
        public List<ScheduledTransactionDetail> ScheduledTransactions { get; set; }
    }

    public class ScheduledTransactionsResponse
    {
        [JsonProperty("data")]
        public ScheduledTransactionsWrapper Data { get; set; }
    }

    public class ScheduledSubTransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scheduled_transaction_id")]
        public string ScheduledTransactionId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("payee_id")]
        public string PayeeId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("transfer_account_id")]
        public string TransferAccountId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}