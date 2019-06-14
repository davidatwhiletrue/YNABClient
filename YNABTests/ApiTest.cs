using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using ynab;

namespace YNABTests
{     
    [TestClass]
    public class UnitTest1
    {
        static YNABClient _client;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            string baseAddress = "https://api.youneedabudget.com/v1/";

            var mockHttp = new MockHttpMessageHandler();

            var tokenMatcher = new RichardSzalay.MockHttp.Matchers.HeadersMatcher("Authorization: Bearer aabbccddeeff");

            // Setup a respond for the user api (including a wildcard in the URL)
            mockHttp.When(baseAddress + "user")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")    
                    .Respond("application/json", "{'data' : {'user': {'id': '1'} } }"); // Respond with JSON

            mockHttp.When(baseAddress + "budgets")
                    .WithHeaders("Authorization: Bearer aabbccddeeff")
                    .Respond("application/json", "{'data' : {'budgets': [] } }"); // Respond with JSON

            mockHttp
                    .Fallback
                    .Respond("application/json", "{'error' : {'id':'401', 'name':'unauthorized', 'detail':'Unauthorized' } }");

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
            Assert.AreEqual(0, r.Data.Budgets.Count);
        }
    }
}
