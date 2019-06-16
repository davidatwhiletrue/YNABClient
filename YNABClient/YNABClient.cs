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

            if(!response.IsSuccessStatusCode)
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

        public async Task<AccountResponse> GetAccount(string budgetId, string accountId)
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

        public async Task<PayeesResponse> GetPayees(string budgetId, string last_knowledge_of_server=null)
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
    }
}


// curl -H "Authorization: Bearer 878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff" https://api.youneedabudget.com/v1/budgets