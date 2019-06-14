using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using ynab;

namespace YNABTests
{
    [TestClass]
    public class UnauthorizedTest
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
                    .Throw(new YNABClientException("{'error' : {'id':'401', 'name':'unauthorized', 'detail':'Unauthorized' } }"));

            var httpClient = mockHttp.ToHttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", "wrong_token");

            _client = new YNABClient(httpClient);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task UnauthorizedErrorTest()
        {
            try
            {
                await _client.GetUser();

                Assert.Fail("Expected an exception because of unauthorized request.");
            }
            catch (YNABClientException e)
            {
                Assert.AreEqual("401", e.Error.Id);
                Assert.AreEqual("unauthorized", e.Error.Name);
                Assert.AreEqual("Unauthorized", e.Error.Detail);
            }
            catch (Exception)
            {
                Assert.Fail("Expected exception of type YNABClientException");
            }
        }

    }
}
