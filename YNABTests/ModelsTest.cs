using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ynab;

namespace YNABTests
{
    [TestClass]
    public class ModelsTest
    {
        private object _testObject;

        [TestInitialize]
        public void TestReset()
        {
            _testObject = null;
        }

        [TestMethod]
        public void User()
        {
            User user;
            if (_testObject == null)
            {
                var json = MockJsonData.User;
                user = JsonConvert.DeserializeObject<User>(json);
            }
            else
                user = _testObject as User;

            Assert.IsNotNull(user);
            Assert.AreEqual("user-id-1", user.Id);
        }

        [TestMethod]
        public void UserResponse()
        {
            var json = MockJsonData.UserResponse;
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(json);

            Assert.IsNotNull(userResponse);
            Assert.IsNotNull(userResponse.Data);
            Assert.IsNotNull(userResponse.Data.User);
            _testObject = userResponse.Data.User; this.User();
        }

        [TestMethod]
        public void BudgetSettings()
        {
            BudgetSettings budgetSettings;
            if (_testObject == null)
            {
                var json = MockJsonData.BudgetSettings;
                budgetSettings = JsonConvert.DeserializeObject<BudgetSettings>(json);
            }
            else
                budgetSettings = _testObject as BudgetSettings;

            Assert.IsNotNull(budgetSettings);
            Assert.IsNotNull(budgetSettings.DateFormat);
            Assert.AreEqual("DD/MM/YYYY", budgetSettings.DateFormat.Format);
            Assert.IsNotNull(budgetSettings.CurrencyFormat);
            Assert.AreEqual("EUR", budgetSettings.CurrencyFormat.IsoCode);
            Assert.AreEqual("123 456,78", budgetSettings.CurrencyFormat.ExampleFormat);
            Assert.AreEqual(2, budgetSettings.CurrencyFormat.DecimalDigits);
            Assert.AreEqual(",", budgetSettings.CurrencyFormat.DecimalSeparator);
            Assert.AreEqual(false, budgetSettings.CurrencyFormat.SymbolFirst);
            Assert.AreEqual(" ", budgetSettings.CurrencyFormat.GroupSeparator);
            Assert.AreEqual(true, budgetSettings.CurrencyFormat.DisplaySymbol);
            Assert.AreEqual("€", budgetSettings.CurrencyFormat.CurrencySymbol);
        }

        [TestMethod]
        public void BudgetSettingsResponse()
        {
            var json = MockJsonData.BudgetSettingsResponse;
            var budgetSettingsResponse = JsonConvert.DeserializeObject<BudgetSettingsResponse>(json);

            Assert.IsNotNull(budgetSettingsResponse);
            Assert.IsNotNull(budgetSettingsResponse.Data);
            Assert.IsNotNull(budgetSettingsResponse.Data.Settings);
            _testObject = budgetSettingsResponse.Data.Settings; this.BudgetSettings();
        }

        [TestMethod]
        public void BudgetSummary()
        {
            BudgetSummary budgetSummary;
            if (_testObject == null)
            {
                var json = MockJsonData.BudgetSummary;
                budgetSummary = JsonConvert.DeserializeObject<BudgetSummary>(json);
            }
            else
                budgetSummary = _testObject as BudgetSummary;

            Assert.IsNotNull(budgetSummary);
            Assert.AreEqual("budget-id-1", budgetSummary.Id);
            Assert.AreEqual("Budget Name 1", budgetSummary.Name);
            Assert.AreEqual("2019-01-01T23:59:59+00:00", budgetSummary.LastModifiedOn);
            Assert.AreEqual("2018-12-01", budgetSummary.FirstMonth);
            Assert.AreEqual("2019-06-01", budgetSummary.LastMonth);

            _testObject = budgetSummary; this.BudgetSettings();
        }

        [TestMethod]
        public void BudgetSummaryResponse()
        {
            var json = MockJsonData.BudgetSummaryResponse;
            var budgetsResponse = JsonConvert.DeserializeObject<BudgetSummaryResponse>(json);

            Assert.IsNotNull(budgetsResponse);
            Assert.IsNotNull(budgetsResponse.Data);
            Assert.IsNotNull(budgetsResponse.Data.Budgets);
            Assert.AreEqual(3, budgetsResponse.Data.Budgets.Count);
            budgetsResponse.Data.Budgets.ForEach(budget =>
            {
                Assert.IsNotNull(budget);
                _testObject = budget; this.BudgetSummary();
            });
        }

        [TestMethod]
        public void BudgetDetail()
        {
            BudgetDetail budgetDetail;
            if (_testObject == null)
            {
                var json = MockJsonData.BudgetDetail;
                budgetDetail = JsonConvert.DeserializeObject<BudgetDetail>(json);
            }
            else
                budgetDetail = _testObject as BudgetDetail;

            Assert.IsNotNull(budgetDetail);
            _testObject = budgetDetail; this.BudgetSummary();
        }

        [TestMethod]
        public void Account()
        {
            Account account;
            if (_testObject == null)
            {
                var json = MockJsonData.Account;
                account = JsonConvert.DeserializeObject<Account>(json);
            }
            else
                account = _testObject as Account;

            Assert.IsNotNull(account);
            Assert.AreEqual("aaa-bbb-ccc", account.Id);
            Assert.AreEqual("Payroll account", account.Name);
            Assert.AreEqual("savings", account.Type);
            Assert.AreEqual(true, account.OnBudget);
            Assert.AreEqual(false, account.Closed);
            Assert.AreEqual(1234560, account.Balance);
            Assert.AreEqual(1230000, account.ClearedBalance);
            Assert.AreEqual(-4560, account.UnclearedBalance);
            Assert.AreEqual("aaa-bbb-ccc-ddd", account.TransferPayeeId);
            Assert.AreEqual(false, account.Deleted);
        }

        [TestMethod]
        public void AccountResponse()
        {
            var json = MockJsonData.AccountResponse;
            var accountResponse = JsonConvert.DeserializeObject<AccountResponse>(json);

            Assert.IsNotNull(accountResponse);
            Assert.IsNotNull(accountResponse.Data);
            Assert.IsNotNull(accountResponse.Data.Account);
            _testObject = accountResponse.Data.Account; this.Account();
        }

        [TestMethod]
        public void Category()
        {
            Category category;
            if (_testObject == null)
            {
                var json = MockJsonData.Category;
                category = JsonConvert.DeserializeObject<Category>(json);
            }
            else
                category = _testObject as Category;

            Assert.IsNotNull(category);
            Assert.AreEqual("eee-fff-ggg", category.Id);
            //TODO: Add missing assertions
        }

        [TestMethod]
        public void CategoryResponse()
        {
            var json = MockJsonData.CategoryResponse;
            var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(json);

            Assert.IsNotNull(categoryResponse);
            Assert.IsNotNull(categoryResponse.Data);
            Assert.IsNotNull(categoryResponse.Data.Category);
            _testObject = categoryResponse.Data.Category; this.Category();
        }

        [TestMethod]
        public void CategoryGroup()
        {
            // TODO: complete test
        }

        [TestMethod]
        public void CategoryGroupWithCategories()
        {
            CategoryGroupWithCategories categoryGroupWithCategories;
            if (_testObject == null)
            {
                var json = MockJsonData.CategoryGroupWithCategories;
                categoryGroupWithCategories = JsonConvert.DeserializeObject<CategoryGroupWithCategories>(json);
            }
            else
                categoryGroupWithCategories = _testObject as CategoryGroupWithCategories;

            Assert.IsNotNull(categoryGroupWithCategories);
            _testObject = categoryGroupWithCategories; this.CategoryGroup();
            categoryGroupWithCategories.Categories.ForEach(cg =>
            {
                Assert.IsNotNull(cg);
                _testObject = cg as Category; this.Category();
            });
        }

        [TestMethod]
        public void MonthDetail()
        {
            MonthDetail month;
            if (_testObject == null)
            {
                var json = MockJsonData.MonthDetail;
                month = JsonConvert.DeserializeObject<MonthDetail>(json);
            }
            else
                month = _testObject as MonthDetail;

            Assert.IsNotNull(month);
            // TODO: add missing assertions
        }

        [TestMethod]
        public void BudgetMonthResponse()
        {
            var json = MockJsonData.BudgetMonthResponse;
            var monthResponse = JsonConvert.DeserializeObject<MonthDetailResponse>(json);

            Assert.IsNotNull(monthResponse);
            Assert.IsNotNull(monthResponse.Data);
            Assert.IsNotNull(monthResponse.Data.Month);
            _testObject = monthResponse.Data.Month as MonthDetail; this.MonthDetail();
        }

        [TestMethod]
        public void MonthSummary()
        {
            MonthSummary month;
            if (_testObject == null)
            {
                var json = MockJsonData.MonthSummary;
                month = JsonConvert.DeserializeObject<MonthSummary>(json);
            }
            else
                month = _testObject as MonthSummary;

            Assert.IsNotNull(month);
            // TODO: add missing assertions
        }

        [TestMethod]
        public void BudgetMonthsResponse()
        {
            var json = MockJsonData.BudgetMonthsResponse;
            var months = JsonConvert.DeserializeObject<MonthSummaryResponse>(json);

            Assert.IsNotNull(months);
            Assert.IsNotNull(months.Data);
            Assert.IsNotNull(months.Data.Months);
            months.Data.Months.ForEach((month) =>
            {
                Assert.IsNotNull(month);
                _testObject = month; this.MonthSummary();
            });
        }

        [TestMethod]
        public void PayeeResponse()
        {
            var json1 = MockJsonData.PayeeResponse1;
            var payee1 = JsonConvert.DeserializeObject<PayeeResponse>(json1);

            Assert.IsNotNull(payee1);
            Assert.AreEqual("hhh-iii-iii", payee1.Data.Payee.Id);
            Assert.AreEqual("English language school", payee1.Data.Payee.Name);
            Assert.IsNull(payee1.Data.Payee.TransferAccountId);

            var json2 = MockJsonData.PayeeResponse2;
            var payee2 = JsonConvert.DeserializeObject<PayeeResponse>(json2);

            Assert.IsNotNull(payee2);
            Assert.AreEqual("hhh-iii-jjj", payee2.Data.Payee.Id);
            Assert.AreEqual("Transfer : Payroll account", payee2.Data.Payee.Name);
            Assert.AreEqual("aaa-bbb-ccc", payee2.Data.Payee.TransferAccountId);
        }

        [TestMethod]
        public void PayeesResponse()
        {
            var json = MockJsonData.PayeesResponse;
            var payees = JsonConvert.DeserializeObject<PayeesResponse>(json);

            Assert.IsNotNull(payees);
            Assert.AreEqual(2, payees.Data.Payees.Count);
            Assert.AreEqual("hhh-iii-iii", payees.Data.Payees[0].Id);
            Assert.AreEqual("English language school", payees.Data.Payees[0].Name);
            Assert.IsNull(payees.Data.Payees[0].TransferAccountId);

            Assert.AreEqual("hhh-iii-jjj", payees.Data.Payees[1].Id);
            Assert.AreEqual("Transfer : Payroll account", payees.Data.Payees[1].Name);
            Assert.AreEqual("aaa-bbb-ccc", payees.Data.Payees[1].TransferAccountId);
        }

        [TestMethod]
        public void SubTransaction()
        {
            var json1 = MockJsonData.SubTransaction1;
            var subtransaction1 = JsonConvert.DeserializeObject<SubTransaction>(json1);

            Assert.IsNotNull(subtransaction1);
            Assert.AreEqual("subtransaction-id-1", subtransaction1.Id);
            Assert.AreEqual("transaction-id-1", subtransaction1.TransactionId);
            Assert.AreEqual(-76600, subtransaction1.Amount);
            Assert.AreEqual("memo subtransaction-1", subtransaction1.Memo);
            Assert.AreEqual("payee-id-1", subtransaction1.PayeeId);
            Assert.AreEqual("category-id-1", subtransaction1.CategoryId);
            Assert.IsNull(subtransaction1.TransferAccountId);
            Assert.IsFalse(subtransaction1.Deleted);

            var json2 = MockJsonData.SubTransaction2;
            var subtransaction2 = JsonConvert.DeserializeObject<SubTransaction>(json2);

            Assert.IsNotNull(subtransaction2);
            Assert.AreEqual("subtransaction-id-2", subtransaction2.Id);
            Assert.AreEqual("transaction-id-1", subtransaction2.TransactionId);
            Assert.AreEqual(-6000, subtransaction2.Amount);
            Assert.AreEqual("memo subtransaction-2", subtransaction2.Memo);
            Assert.AreEqual("payee-id-2", subtransaction2.PayeeId);
            Assert.AreEqual("category-id-2", subtransaction2.CategoryId);
            Assert.IsNull(subtransaction2.TransferAccountId);
            Assert.IsFalse(subtransaction2.Deleted);
        }

        [TestMethod]
        public void Transaction()
        {
            var json1 = MockJsonData.Transaction1;
            var transaction1 = JsonConvert.DeserializeObject<TransactionDetail>(json1);

            Assert.IsNotNull(transaction1);
            Assert.AreEqual("transaction-id-1", transaction1.Id);
            Assert.AreEqual(2, transaction1.SubTransactions.Count);
            Assert.AreEqual("subtransaction-id-1", transaction1.SubTransactions[0].Id);
            Assert.AreEqual("subtransaction-id-2", transaction1.SubTransactions[1].Id);
        }
    }
}
