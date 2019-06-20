using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class BudgetDetail : BudgetSummary
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("payees")]
        public List<Payee> Payees { get; set; }

        [JsonProperty("category_groups")]
        public List<CategoryGroup> CategoryGroups { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("months")]
        public List<MonthDetail> Months { get; set; }

        [JsonProperty("transactions")]
        public List<TransactionSummary> Transactions { get; set; }

        [JsonProperty("subtransactions")]
        public List<SubTransaction> SubTransactions { get; set; }

        //scheduled_transactions

        //scheduled_subtransactions
    }

    public class BudgetDetailWrapper
    {
        [JsonProperty("budget")]
        public BudgetDetail Budget { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }

    public class BudgetDetailResponse
    {
        [JsonProperty("data")]
        public BudgetDetailWrapper Data { get; set; }
    }
}
