using System;
using System.Net.Http.Headers;
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

            mockHttp.When(baseAddress + "budgets/budget-id-1")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetDetailResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/settings")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetSettingsResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/accounts")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.AccountsResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/accounts/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.AccountResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/categories")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoriesResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/categories/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoryResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/months/current/categories/aaa-bbb-ccc")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.CategoryResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/months")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetMonthsResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/months/current")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.BudgetMonthResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/payees?last_knowledge_of_server=3000")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeesResponseWithLastKnowledgeOfServer);

            mockHttp.When(baseAddress + "budgets/budget-id-1/payees")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeesResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/payees/hhh-iii-jjj")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.PayeeResponse2);

            mockHttp.When(baseAddress + "budgets/budget-id-1/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.TransactionsResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/transactions/transaction-id-1")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", MockJsonData.TransactionResponse);

            mockHttp.When(baseAddress + "budgets/budget-id-1/accounts/account-id-1/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .WithQueryString("since_date=2019-06-01&type=approved")
                    .Respond("application/json", MockJsonData.TransactionsResponseForAccounts);

            mockHttp.When(baseAddress + "budgets/budget-id-1/categories/category-id-1/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .WithQueryString("since_date=2019-06-01&type=approved")
                    .Respond("application/json", MockJsonData.TransactionsResponseForCategories);

            mockHttp.When(baseAddress + "budgets/budget-id-1/payees/payee-id-1/transactions")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .WithQueryString("since_date=2019-06-01&type=approved")
                    .Respond("application/json", MockJsonData.TransactionsResponseForPayees);

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
        public async Task GetBudgetByIdTest()
        {
            var r = await _client.GetBudgetById("budget-id-1");

            Assert.IsNotNull(r.Data.Budget);
            Assert.AreEqual("budget-id-1", r.Data.Budget.Id);
        }

        [TestMethod]
        public async Task GetBudgetSettingsTest()
        {
            var r = await _client.GetBudgetSettingsById("budget-id-1");

            Assert.IsNotNull(r.Data.Settings);
            Assert.AreEqual("123 456,78", r.Data.Settings.CurrencyFormat.ExampleFormat);
        }


        [TestMethod]
        public async Task GetAccountsTest()
        {
            var r = await _client.GetAccounts("budget-id-1");

            Assert.IsNotNull(r.Data.Accounts);
            Assert.AreEqual(3, r.Data.Accounts.Count);
            Assert.AreEqual("aaa-bbb-ccc", r.Data.Accounts[0].Id);
        }

        [TestMethod]
        public async Task GetAccountTest()
        {
            var r = await _client.GetAccountById("budget-id-1", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Account);
            Assert.AreEqual("aaa-bbb-ccc", r.Data.Account.Id);
        }

        [TestMethod]
        public async Task GetCategoriesTest()
        {
            var r = await _client.GetCategories("budget-id-1");

            Assert.IsNotNull(r.Data.CategoryGroups);
            Assert.AreEqual(1, r.Data.CategoryGroups.Count);
            Assert.AreEqual("category-group-id-1", r.Data.CategoryGroups[0].Id);
        }

        [TestMethod]
        public async Task GetCategoryTest()
        {
            var r = await _client.GetCategoryById("budget-id-1", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Category);
            Assert.AreEqual("category-id-1", r.Data.Category.Id);
            Assert.AreEqual("category-group-id-1", r.Data.Category.CategoryGroupId);
            Assert.AreEqual("Family leisure", r.Data.Category.Name);
        }

        [TestMethod]
        public async Task GetMonthCategoryTest()
        {
            var r = await _client.GetMonthCategoryById("budget-id-1", "current", "aaa-bbb-ccc");

            Assert.IsNotNull(r.Data.Category);
            Assert.AreEqual("category-id-1", r.Data.Category.Id);
            Assert.AreEqual("category-group-id-1", r.Data.Category.CategoryGroupId);
            Assert.AreEqual("Family leisure", r.Data.Category.Name);
        }

        [TestMethod]
        public async Task GetBudgetMonthsTest()
        {
            var r = await _client.GetBudgetMonths("budget-id-1");

            Assert.IsNotNull(r.Data.Months);
            Assert.AreEqual(2, r.Data.Months.Count);
            Assert.AreEqual("2019-06-01", r.Data.Months[0].Month);
            Assert.AreEqual(150000, r.Data.Months[0].Budgeted);
        }

        [TestMethod]
        public async Task GetBudgetMonthTest()
        {
            var r = await _client.GetBudgetMonth("budget-id-1", "current");

            Assert.IsNotNull(r.Data.Month);
            Assert.AreEqual("2019-06-01", r.Data.Month.Month);
            Assert.AreEqual(150000, r.Data.Month.Budgeted);
        }

        [TestMethod]
        public async Task GetPayeesTest()
        {
            var r = await _client.GetPayees("budget-id-1");

            Assert.IsNotNull(r.Data.Payees);
            Assert.AreEqual(2, r.Data.Payees.Count);
            Assert.AreEqual("hhh-iii-iii", r.Data.Payees[0].Id);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payees[1].Id);
            Assert.AreEqual(3000, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetPayeesWithLastKnowledgeOfServerTest()
        {
            var r = await _client.GetPayees("budget-id-1", "3000");

            Assert.IsNotNull(r.Data.Payees);
            Assert.AreEqual(1, r.Data.Payees.Count);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payees[0].Id);
            Assert.AreEqual(4000, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetPayeeTest()
        {
            var r = await _client.GetPayeeById("budget-id-1", "hhh-iii-jjj");

            Assert.IsNotNull(r.Data.Payee);
            Assert.AreEqual("hhh-iii-jjj", r.Data.Payee.Id);
        }

        [TestMethod]
        public async Task GetTransactionsTest()
        {
            var r = await _client.GetTransactions("budget-id-1", "3000");

            Assert.IsNotNull(r.Data.Transactions);
            Assert.AreEqual(1, r.Data.Transactions.Count);
            Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
            Assert.AreEqual(2000, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetTransactionTest()
        {
            var r = await _client.GetTransactionById("budget-id-1", "transaction-id-1");

            Assert.IsNotNull(r.Data.Transaction);
            Assert.AreEqual("transaction-id-1", r.Data.Transaction.Id);
        }

        [TestMethod]
        public async Task GetTransactionsByAccountTest()
        {
            var r = await _client.GetTransactionsByAccount("budget-id-1", "account-id-1", "2019-06-01", "approved");

            Assert.IsNotNull(r.Data.Transactions);
            Assert.AreEqual(1, r.Data.Transactions.Count);
            Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
            Assert.AreEqual(2011, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetTransactionsByCategoryTest()
        {
            var r = await _client.GetTransactionsByCategory("budget-id-1", "category-id-1", "2019-06-01", "approved");

            Assert.IsNotNull(r.Data.Transactions);
            Assert.AreEqual(1, r.Data.Transactions.Count);
            Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
            Assert.AreEqual(2022, r.Data.ServerKnowledge);
        }

        [TestMethod]
        public async Task GetTransactionsByPayeeTest()
        {
                var r = await _client.GetTransactionsByPayee("budget-id-1", "payee-id-1", "2019-06-01", "approved");

                Assert.IsNotNull(r.Data.Transactions);
                Assert.AreEqual(1, r.Data.Transactions.Count);
                Assert.AreEqual("transaction-id-1", r.Data.Transactions[0].Id);
                Assert.AreEqual(2033, r.Data.ServerKnowledge);
        }
    }
}
