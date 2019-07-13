using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ynab
{
    public class YNABClient : IDisposable
    {
        readonly HttpClient _client;

        public YNABClient(HttpClient client)
        {
            _client = client;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<UserResponse> GetUser()
        {
            var response = await _client.GetAsync("user");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var userResponse = JsonConvert.DeserializeObject<UserResponse>(json);

            return userResponse;
        }

        public async Task<BudgetSummaryResponse> GetBudgets()
        {
            var response = await _client.GetAsync("budgets");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var budgetSummaryResponse = JsonConvert.DeserializeObject<BudgetSummaryResponse>(json);

            return budgetSummaryResponse;
        }

        public async Task<BudgetDetailResponse> GetBudgetById(string budgetId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var budgetDetailResponse = JsonConvert.DeserializeObject<BudgetDetailResponse>(json);

            return budgetDetailResponse;
        }

        public async Task<BudgetSettingsResponse> GetBudgetSettingsById(string budgetId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/settings");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var budgetSettingsResponse = JsonConvert.DeserializeObject<BudgetSettingsResponse>(json);

            return budgetSettingsResponse;
        }

        public async Task<AccountsResponse> GetAccounts(string budgetId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/accounts");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var accountsResponse = JsonConvert.DeserializeObject<AccountsResponse>(json);

            return accountsResponse;
        }

        public async Task<AccountResponse> GetAccountById(string budgetId, string accountId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/accounts/{accountId}");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var accountResponse = JsonConvert.DeserializeObject<AccountResponse>(json);

            return accountResponse;
        }

        public async Task<CategoriesResponse> GetCategories(string budgetId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/categories");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var categoriesResponse = JsonConvert.DeserializeObject<CategoriesResponse>(json);

            return categoriesResponse;
        }

        public async Task<CategoryResponse> GetCategoryById(string budgetId, string categoryId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/categories/{categoryId}");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(json);

            return categoryResponse;
        }


        public async Task<CategoryResponse> GetMonthCategoryById(string budgetId, string month, string categoryId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/months/{month}/categories/{categoryId}");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(json);

            return categoryResponse;
        }

        public async Task<MonthSummaryResponse> GetBudgetMonths(string budgetId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/months");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var monthsResponse = JsonConvert.DeserializeObject<MonthSummaryResponse>(json);

            return monthsResponse;
        }

        public async Task<MonthDetailResponse> GetBudgetMonth(string budgetId, string month)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/months/{month}");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var monthResponse = JsonConvert.DeserializeObject<MonthDetailResponse>(json);

            return monthResponse;
        }

        public async Task<PayeesResponse> GetPayees(string budgetId, string last_knowledge_of_server = null)
        {
            var query = $"budgets/{budgetId}/payees";
            if (last_knowledge_of_server != null)
                query += $"?last_knowledge_of_server={last_knowledge_of_server}";

            var response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var payeesResponse = JsonConvert.DeserializeObject<PayeesResponse>(json);

            return payeesResponse;
        }

        public async Task<PayeeResponse> GetPayeeById(string budgetId, string payeeId)
        {
            var response = await _client.GetAsync($"budgets/{budgetId}/payees/{payeeId}");

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var payeeResponse = JsonConvert.DeserializeObject<PayeeResponse>(json);

            return payeeResponse;
        }

        public async Task<TransactionsResponse> GetTransactions(string budgetId, string last_knowledge_of_server = null)
        {
            var query = $"budgets/{budgetId}/transactions";
            if (last_knowledge_of_server != null)
                query += $"?last_knowledge_of_server={last_knowledge_of_server}";

            var response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var transactionsResponse = JsonConvert.DeserializeObject<TransactionsResponse>(json);

            return transactionsResponse;
        }

        public async Task<TransactionResponse> GetTransactionById(string budgetId, string transactionId)
        {
            var query = $"budgets/{budgetId}/transactions/{transactionId}";

            var response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(json);

            return transactionResponse;
        }

        private async Task<TransactionsResponse> GetTransactionsBy(string model, string budgetId, string modelId, string since_date, string type, string last_knowledge_of_server = null)
        {
            UriBuilder baseUri = new UriBuilder($"{_client.BaseAddress}budgets/{budgetId}/{model}/{modelId}/transactions");

            if (since_date != null)
            {
                if (baseUri.Query != null && baseUri.Query.Length > 1)
                    baseUri.Query = baseUri.Query.Substring(1) + "&" + $"since_date={since_date}";
                else
                    baseUri.Query = $"since_date={since_date}";
            }

            if (type != null)
            {
                if (baseUri.Query != null && baseUri.Query.Length > 1)
                    baseUri.Query = baseUri.Query.Substring(1) + "&" + $"type={type}";
                else
                    baseUri.Query = $"type={type}";
            }

            if (last_knowledge_of_server != null)
            {
                if (baseUri.Query != null && baseUri.Query.Length > 1)
                    baseUri.Query = baseUri.Query.Substring(1) + "&" + $"last_knowledge_of_server={last_knowledge_of_server}";
                else
                    baseUri.Query = $"last_knowledge_of_server={last_knowledge_of_server}";
            }

            var response = await _client.GetAsync(baseUri.Uri);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var transactionsResponse = JsonConvert.DeserializeObject<TransactionsResponse>(json);

            return transactionsResponse;
        }

        public async Task<TransactionsResponse> GetTransactionsByAccount(string budgetId, string accountId, string since_date, string type, string last_knowledge_of_server = null)
        {
            return await GetTransactionsBy("accounts", budgetId, accountId, since_date, type, last_knowledge_of_server);
        }

        public async Task<TransactionsResponse> GetTransactionsByCategory(string budgetId, string categoryId, string since_date, string type, string last_knowledge_of_server = null)
        {
            return await GetTransactionsBy("categories", budgetId, categoryId, since_date, type, last_knowledge_of_server);
        }

        public async Task<TransactionsResponse> GetTransactionsByPayee(string budgetId, string payeeId, string since_date, string type, string last_knowledge_of_server = null)
        {
            return await GetTransactionsBy("payees", budgetId, payeeId, since_date, type, last_knowledge_of_server);
        }

        public async Task<ScheduledTransactionsResponse> GetScheduledTransactions(string budgetId)
        {
            var query = $"budgets/{budgetId}/scheduled_transactions";

            var response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var transactionsResponse = JsonConvert.DeserializeObject<ScheduledTransactionsResponse>(json);

            return transactionsResponse;
        }

        public async Task<ScheduledTransactionResponse> GetScheduledTransactionById(string budgetId, string scheduledTransactionId)
        {
            var query = $"budgets/{budgetId}/scheduled_transactions/{scheduledTransactionId}";

            var response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                var j = await response.Content.ReadAsStringAsync();
                throw new YNABClientException(j);
            }

            var json = await response.Content.ReadAsStringAsync();

            var transactionResponse = JsonConvert.DeserializeObject<ScheduledTransactionResponse>(json);

            return transactionResponse;
        }
    }
}

// curl -H "Authorization: Bearer 878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff" https://api.youneedabudget.com/v1/budgets