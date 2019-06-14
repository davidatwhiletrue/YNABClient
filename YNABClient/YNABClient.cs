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
        HttpClient _client;

        public YNABClient(string accessToken)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.youneedabudget.com/v1/");
            _client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", accessToken);

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

            response.EnsureSuccessStatusCode();

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
    }
}


// curl -H "Authorization: Bearer 878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff" https://api.youneedabudget.com/v1/budgets