using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ynab;

namespace YNABTests
{
    [TestClass]
    public class UnitTest1
    {
        static YNABClient _client;
        static string _accessToken = "878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _client = new YNABClient(_accessToken);
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
            Assert.AreEqual("ddcebec8-e2ae-4624-aefd-17cb585ad39c", user.Data.User.Id);
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
        public async Task UnauthorizedErrorTest()
        {
            try
            {
                var client = new YNABClient("WRONG_TOKEN");
                await client.GetUser();

                Assert.Fail("Expected an exception because of unauthorized request.");
            }
            catch(YNABClientException e)
            {
                Assert.AreEqual("401", e.Error.Id);
                Assert.AreEqual("unauthorized", e.Error.Name);
                Assert.AreEqual("Unauthorized", e.Error.Detail);
            }
            catch(Exception)
            {
                Assert.Fail("Expected exception of type YNABClientException");
            }
        }
    }
}
