using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ynab;
using MongoDB.Bson;
using MongoDB.Driver;

namespace YNABCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string accessToken = "878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff";

            Console.WriteLine("Hello World!");

            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.youneedabudget.com/v1/");
            _client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", accessToken);

            //YNABClient ynab = new YNABClient(_client);

            //ListBudgets(ynab).Wait();
            //Presup.familiar '19 (3edd94ad-1fe7-42b4-9a74-e72016722db8)
            //Budget 2019(95747a4b - b951 - 48ac - bccd - aeb95ddba42f)
            //My Budget 2018(93b9942a - 4705 - 4df3 - 8fe3 - f0e07d933fa2)

            var budgetId = "3edd94ad-1fe7-42b4-9a74-e72016722db8";

            //GetAccounts(ynab, budgetId).Wait();

            //Console.WriteLine("done!");

            //GetCategories(ynab, budgetId).Wait();

            //GetDonaciones(ynab, budgetId).Wait();
            //_client.Dispose();

            MONGO_TEST();
        }

        private static void MONGO_TEST()
        {
            var client = new MongoClient(
    "mongodb+srv://ynab-user:yn4b.us3r@cluster0-zjup2.azure.mongodb.net"
);

            //var dbList = client.ListDatabases().ToList();

            //Console.WriteLine("The list of databases are :");
            //foreach (var item in dbList)
            //{
            //    Console.WriteLine(item);
            //}

            IMongoDatabase db = client.GetDatabase("ynab");
            //var collList = db.ListCollections().ToList();
            //Console.WriteLine("The list of collections are :");
            //foreach (var item in collList)
            //{
            //    Console.WriteLine(item);
            //}

            var ynab_oauth = BsonDocument.Parse(@"{
                ""access_token"":""fca18236e2636492d3c5bc68bb7200d61d62eabb0abb6ad257d112dae89d1ce8"",
                ""token_type"":""Bearer"",
                ""expires_in"":7200,
                ""refresh_token"":""d40168559e1384d60de018d5d1123ec660aa8f7cc5fb909cf91f8699df4d5b17"",
                ""scope"":""public"",
                ""created_at"":1562011192
            }");

            var doc = new BsonDocument {
                { "user_id", Guid.NewGuid().ToString() },
                { "telegram", new BsonArray() },
                { "ynab_oauth", ynab_oauth }
            };

            var users = db.GetCollection<BsonDocument>("userCollection");
            users.InsertOne(doc);
            //var user = users.Find(new BsonDocument()).FirstOrDefault();

            //Console.WriteLine(user);

        }
        static async Task ListBudgets(YNABClient ynab)
        {
            var response = await ynab.GetBudgets();

            var budgets = response.Data.Budgets;

            foreach (var b in budgets)
                Console.WriteLine($"{b.Name} ({b.Id})");
        }

        static async Task GetAccounts(YNABClient ynab, string budgetId)
        {
            var response = await ynab.GetAccounts(budgetId);

            var accounts = response.Data.Accounts;

            foreach (var acc in accounts)
            {
                double balance = acc.Balance;
                balance /= 1000;
                Console.WriteLine($"{acc.Name} / {balance.ToString("0.00")} € ({acc.Id}");
            }
        }

        static async Task GetCategories(YNABClient ynab, string budgetId)
        {
            var response = await ynab.GetCategories(budgetId);

            var categories = response.Data.CategoryGroups;

            //var category = categories.Select(cg =>
            //    cg.Categories.Where(c => c.Name.StartsWith("Navidad", StringComparison.InvariantCultureIgnoreCase)));

            //Console.WriteLine(JsonConvert.SerializeObject(category, Formatting.Indented));

            var cats = categories.SelectMany(cg => cg.Categories).Where(c => c.GoalType == "TBD");
            foreach (var c in cats)
            {
                Console.WriteLine(c.Name + "\n" + JsonConvert.SerializeObject(c, Formatting.Indented));
            }
        }

        static async Task GetDonaciones(YNABClient ynab, string budgetId)
        {
            //var month = "2019-07-01";
            //var catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //var cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-06-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-05-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-04-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-03-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-02-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            //month = "2019-01-01";
            //catResp = await ynab.GetMonthCategoryById(budgetId, month, "d20742c8-200f-4364-9a5d-ea8c6b563233");
            //cat = catResp.Data.Category;
            //Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            try
            {
                var month = "2019-10-01";
                var catResp = await ynab.GetMonthCategoryById(budgetId, month, "7a6c08e3-7992-4fc4-b714-cb7ac758f4d8");
                var cat = catResp.Data.Category;
                Console.WriteLine(cat.Name + " " + month + "\n" + JsonConvert.SerializeObject(cat, Formatting.Indented));

            }
            catch (YNABClientException ex)
            {
                Console.WriteLine(ex.Error.Detail);
                Console.WriteLine(ex.Error.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
