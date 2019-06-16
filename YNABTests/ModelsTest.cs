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
    }
}
