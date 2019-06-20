using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class TransactionSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("cleared")]
        public string Cleared { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

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

        [JsonProperty("transfer_transaction_id")]
        public string TransferTransactionId { get; set; }

        [JsonProperty("matched_transaction_id")]
        public string MatchedTransactionId { get; set; }

        [JsonProperty("import_id")]
        public string ImportId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class TransactionDetail : TransactionSummary
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("payee_name")]
        public string PayeeName { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("subtransactions")]
        public List<SubTransaction> SubTransactions { get; set; }
    }

    public class TransactionWrapper
    {
        [JsonProperty("transaction")]
        public TransactionDetail Transaction { get; set; }
    }

    public class TransactionResponse
    {
        [JsonProperty("data")]
        public TransactionWrapper Data { get; set; }
    }

    public class TransactionsWrapper
    {
        [JsonProperty("transactions")]
        public List<TransactionDetail> Transactions { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }

    public class TransactionsResponse
    {
        [JsonProperty("data")]
        public TransactionsWrapper Data { get; set; }
    }

    public class SubTransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

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
