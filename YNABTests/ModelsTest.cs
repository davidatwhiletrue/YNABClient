using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ynab;

namespace YNABTests
{
    [TestClass]
    public class ModelsTest
    {
        [TestMethod]
        public void User()
        {
            var json = MockJsonData.User;
            var user = JsonConvert.DeserializeObject<User>(json);

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
            Assert.AreEqual("user-id-1", userResponse.Data.User.Id);
        }

        [TestMethod]
        public void BudgetSettings()
        {
            var json = MockJsonData.BudgetSettings;
            var budgetSettings = JsonConvert.DeserializeObject<BudgetSettings>(json);

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
        }

        [TestMethod]
        public void BudgetSummary()
        {
            var json = MockJsonData.BudgetSummary;
            var budgetSummary = JsonConvert.DeserializeObject<BudgetSummary>(json);

            Assert.IsNotNull(budgetSummary);
            Assert.AreEqual("budget-id-1", budgetSummary.Id);
            Assert.AreEqual("Budget Name 1", budgetSummary.Name);
            Assert.AreEqual("2019-01-01T23:59:59+00:00", budgetSummary.LastModifiedOn);
            Assert.AreEqual("2018-12-01", budgetSummary.FirstMonth);
            Assert.AreEqual("2019-06-01", budgetSummary.LastMonth);
            Assert.IsNotNull(budgetSummary.DateFormat);
            Assert.AreEqual("DD/MM/YYYY", budgetSummary.DateFormat.Format);
            Assert.IsNotNull(budgetSummary.CurrencyFormat);
            Assert.AreEqual("EUR", budgetSummary.CurrencyFormat.IsoCode);
            Assert.AreEqual("123 456,78", budgetSummary.CurrencyFormat.ExampleFormat);
            Assert.AreEqual(2, budgetSummary.CurrencyFormat.DecimalDigits);
            Assert.AreEqual(",", budgetSummary.CurrencyFormat.DecimalSeparator);
            Assert.AreEqual(false, budgetSummary.CurrencyFormat.SymbolFirst);
            Assert.AreEqual(" ", budgetSummary.CurrencyFormat.GroupSeparator);
            Assert.AreEqual(true, budgetSummary.CurrencyFormat.DisplaySymbol);
            Assert.AreEqual("€", budgetSummary.CurrencyFormat.CurrencySymbol);
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
            Assert.AreEqual("budget-id-1", budgetsResponse.Data.Budgets[0].Id);
            Assert.AreEqual("budget-id-1", budgetsResponse.Data.Budgets[1].Id);
            Assert.AreEqual("budget-id-1", budgetsResponse.Data.Budgets[2].Id);
        }

        [TestMethod]
        public void Account()
        {
            var json = MockJsonData.Account;
            var account = JsonConvert.DeserializeObject<Account>(json);

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
        }

        [TestMethod]
        public void Category()
        {
            var json = MockJsonData.Category;
            var category = JsonConvert.DeserializeObject<Category>(json);

            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void CategoryResponse()
        {
            var json = MockJsonData.CategoryResponse;
            var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(json);

            Assert.IsNotNull(categoryResponse);
        }

        [TestMethod]
        public void CategoryGroupWithCategories()
        {
            var json = MockJsonData.CategoryGroupWithCategories;
            var categoryGroupResponse = JsonConvert.DeserializeObject<CategoryGroupWithCategories>(json);

            Assert.IsNotNull(categoryGroupResponse);
        }

        [TestMethod]
        public void MonthDetail()
        {
            var json = MockJsonData.MonthDetail;
            var month = JsonConvert.DeserializeObject<MonthDetail>(json);

            Assert.IsNotNull(month);
        }

        [TestMethod]
        public void BudgetMonthResponse()
        {
            var json = MockJsonData.BudgetMonthResponse;
            var month = JsonConvert.DeserializeObject<MonthDetailResponse>(json);

            Assert.IsNotNull(month);
        }

        [TestMethod]
        public void MonthSummary()
        {
            var json = MockJsonData.MonthSummary;
            var month = JsonConvert.DeserializeObject<MonthSummary>(json);

            Assert.IsNotNull(month);
        }

        [TestMethod]
        public void BudgetMonthsResponse()
        {
            var json = MockJsonData.BudgetMonthsResponse;
            var months = JsonConvert.DeserializeObject<MonthSummaryResponse>(json);

            Assert.IsNotNull(months);
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
