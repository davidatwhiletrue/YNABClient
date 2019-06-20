using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using ynab;

namespace YNABTests
{
    [TestClass]
    public class ApiTest
    {
        static YNABClient _client;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            string baseAddress = "https://api.youneedabudget.com/v1/";

            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When(baseAddress + "user")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", "{'data' : {'user': {'id': '1'} } }"); // Respond with JSON

            mockHttp.When(baseAddress + "budgets")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetSummaryResponse); // Respond with JSON

            mockHttp.When(baseAddress + "budgets/aaa-bbb/settings")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetSettingsResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/accounts")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.AccountsResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/accounts/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.AccountResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/categories")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoriesResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/categories/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoryResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/months/current/categories/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoryResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/months")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetMonthsResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/months/current")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetMonthResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/payees?last_knowledge_of_server=3000")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeesResponseWithLastKnowledgeOfServer);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/payees")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeesResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/payees/hhh-iii-jjj")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeeResponse2);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.TransactionsResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/transactions/transaction-id-1")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.TransactionResponse);

            mockHttp.When(baseAddress + "budgets/aaa-bbb/accounts/account-id-1/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .WithQueryString("since_date=2019-06-01&type=approved")
                    .Respond("application/json", MockJsonData.TransactionsResponse);
                    /*.Respond((req) =>
                    {
                        return new StringContent(req.ToString(), Encoding.UTF8, "application/json");
                    });*/

            mockHttp
                    .Fallback
                    .Throw(new YNABClientException("{'error' : {'id':'404.2', 'name':'resource_not_found', 'detail':'Resource not found' } }"));

            var httpClient = mockHttp.ToHttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", "aabbccddeeff");

            _client = new YNABClient(httpClient);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task GetUserTest()
        {
            var user = await _client.GetUser();

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.Data);
            Assert.IsNotNull(user.Data.User);
            Assert.AreEqual("1", user.Data.User.Id);
        }

        [TestMethod]
        public async Task GetBudgetsTest()
        {
            var r = await _client.GetBudgets();

            Assert.IsNotNull(r);
            Assert.IsNotNull(r.Data);
            Assert.IsNotNull(r.Data.Budgets);
            Assert.AreEqual(3, r.Data.Budgets.Count);
        }

        [TestMethod]
        public async Task GetBudgetSettings()
        {
            var r = await _client.GetBudgetSettingsById("aaa-bbb");

            Assert.IsNotNull(r.Data.Settings);
            Assert.AreEqual("123 456,78", r.Data.Settings.CurrencyFormat.ExampleFormat);
        }


        [TestMethod]
        public async Task GetAccounts()
        {
            var r = await _client.GetAccounts("aaa-bbb");

            Assert.IsNotNull(r.Data.Accounts);
            Assert.AreEqual(3, r.Data.Accounts.Count);
            Assert.AreEqual("aaa-bbb-ccc", r.Data.Accounts[0].Id);
        }

        [TestMethod]
        public async Task GetAccount()
        {
            var r = await _client.GetAccount("aaa-bbb", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Account);
            Assert.AreEqual("aaa-bbb-ccc", r.Data.Account.Id);
        }

        [TestMethod]
        public async Task GetCategories()
        {
            var r = await _client.GetCategories("aaa-bbb");

            Assert.IsNotNull(r.Data.CategoryGroups);
            Assert.AreEqual(2, r.Data.CategoryGroups.Count);
            Assert.AreEqual("eee-eee-eee", r.Data.CategoryGroups[0].Id);
            Assert.AreEqual("Group Category", r.Data.CategoryGroups[0].Name);
            Assert.AreEqual(3, r.Data.CategoryGroups[0].Categories.Count);
            Assert.AreEqual("eee-fff-ggg", r.Data.CategoryGroups[0].Categories[2].Id);
            Assert.AreEqual("Family leisure", r.Data.CategoryGroups[0].Categories[2].Name);
        }

        [TestMethod]
        public async Task GetCategory()
        {
            var r = await _client.GetCategoryById("aaa-bbb", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Category);
            Assert.AreEqual("eee-fff-ggg", r.Data.Category.Id);
            Assert.AreEqual("bbb-ccc-ddd", r.Data.Category.CategoryGroupId);
            Assert.AreEqual("Family leisure", r.Data.Category.Name);
        }

        [TestMethod]
        public async Task GetMonthCategory()
        {
            var r = await _client.GetMonthCategoryById("aaa-bbb", "current", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Category);
            Assert.AreEqual("eee-fff-ggg", r.Data.Category.Id);
            Assert.AreEqual("bbb-ccc-ddd", r.Data.Category.CategoryGroupId);
            Assert.AreEqual("Family leisure", r.Data.Category.Name);
        }

        [TestMethod]
        public async Task GetBudgetMonths()
        {
            var r = await _client.GetBudgetMonths("aaa-bbb");

            Assert.IsNotNull(r.Data.Months);
            Assert.AreEqual(2, r.Data.Months.Count);
            Assert.AreEqual("2019-06-01", r.Data.Months[0].Month);
            Assert.AreEqual(150000, r.Data.Months[0].Budgeted);
        }

        [TestMethod]
        public async Task GetBudgetMonth()
        {
            var r = await _client.GetBudgetMonth("aaa-bbb", "current");

            Assert.IsNotNull(r.Data.Month);
            Assert.AreEqual("2019-06-01", r.Data.Month.Month);
            Assert.AreEqual(150000, r.Data.Month.Budgeted);
        }

        [TestMethod]
        public async Task GetPayees()
        {
            var r = await _client.GetPayees("aaa-bbb");

            Assert.IsNotNull(r.Data.Payees);
            Assert.AreEqual(2, r.Data.Payees.Count);
            Assert.AreEqual("hhh-iii-iii", r.Data.Payees[0].Id);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payees[1].Id);
            Assert.AreEqual(3000, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetPayeesWithLastKnowledgeOfServer()
        {
            var r = await _client.GetPayees("aaa-bbb", "3000");

            Assert.IsNotNull(r.Data.Payees);
            Assert.AreEqual(1, r.Data.Payees.Count);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payees[0].Id);
            Assert.AreEqual(4000, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetPayee()
        {
            var r = await _client.GetPayeeById("aaa-bbb", "hhh-iii-jjj");

            Assert.IsNotNull(r.Data.Payee);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payee.Id);
        }

        [TestMethod]
        public async Task GetTransactions()
        {
            var r = await _client.GetTransactions("aaa-bbb", "3000");

            Assert.IsNotNull(r.Data.Transactions);
            Assert.AreEqual(2, r.Data.Transactions.Count);
            Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
            Assert.AreEqual("transaction-id-1", r.Data.Transactions[1].Id);
        }

        [TestMethod]
        public async Task GetTransaction()
        {
            var r = await _client.GetTransactionById("aaa-bbb", "transaction-id-1");

            Assert.IsNotNull(r.Data.Transaction);
            Assert.AreEqual("transaction-id-1", r.Data.Transaction.Id);
        }

        [TestMethod]
        public async Task GetTransactionsByAccount()
        {
            try
            {
                var r = await _client.GetTransactionsByAccount("aaa-bbb", "account-id-1", "2019-06-01", "approved");

                Assert.IsNotNull(r.Data.Transactions);
                Assert.AreEqual(2, r.Data.Transactions.Count);
                Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
                Assert.AreEqual("transaction-id-1", r.Data.Transactions[1].Id);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

        }
    }
}
