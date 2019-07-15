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

            Assert.IsNotNull(budgetDetail.Accounts[0]);
            _testObject = budgetDetail.Accounts[0]; this.Account();

            Assert.IsNotNull(budgetDetail.Payees[0]);
            _testObject = budgetDetail.Payees[0]; this.Payee();

            Assert.IsNotNull(budgetDetail.Transactions[0]);
            _testObject = budgetDetail.Transactions[0]; this.TransactionSummary();

            Assert.IsNotNull(budgetDetail.CategoryGroups[0]);
            _testObject = budgetDetail.CategoryGroups[0]; this.CategoryGroup();

            Assert.IsNotNull(budgetDetail.Categories[0]);
            _testObject = budgetDetail.Categories[0]; this.Category();

            Assert.IsNotNull(budgetDetail.Months[0]);
            _testObject = budgetDetail.Months[0]; this.MonthDetail();

            Assert.IsNotNull(budgetDetail.SubTransactions[0]);
            _testObject = budgetDetail.SubTransactions[0]; this.SubTransaction1();

            Assert.IsNotNull(budgetDetail.SubTransactions[1]);
            _testObject = budgetDetail.SubTransactions[1]; this.SubTransaction2();

            Assert.IsNotNull(budgetDetail.ScheduledTransactions[0]);
            _testObject = budgetDetail.ScheduledTransactions[0]; this.ScheduledTransactionSummary();

            Assert.IsNotNull(budgetDetail.ScheduledSubTransactions[0]);
            _testObject = budgetDetail.ScheduledSubTransactions[0]; this.ScheduledSubTransaction();
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
            Assert.AreEqual("category-id-1", category.Id);
            Assert.AreEqual("category-group-id-1", category.CategoryGroupId);
            Assert.AreEqual("Family leisure", category.Name);
            Assert.IsTrue(category.Hidden);
            Assert.AreEqual("category note 1", category.Note);
            Assert.AreEqual(1000, category.Budgeted);
            Assert.AreEqual(2000, category.Activity);
            Assert.AreEqual(-1000, category.Balance);
            Assert.IsNull(category.GoalType);
            Assert.IsNull(category.GoalCreationMonth);
            Assert.AreEqual(0, category.GoalTarget);
            Assert.IsNull(category.GoalTargetMonth);
            Assert.IsNull(category.GoalPercentageComplete);
            Assert.IsTrue(category.Deleted);
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
            CategoryGroup categoryGroup;
            if (_testObject == null)
            {
                var json = MockJsonData.CategoryGroup;
                categoryGroup = JsonConvert.DeserializeObject<CategoryGroup>(json);
            }
            else
                categoryGroup = _testObject as CategoryGroup;

            Assert.IsNotNull(categoryGroup);
            Assert.AreEqual("category-group-id-1", categoryGroup.Id);
            Assert.AreEqual("Category Group 1", categoryGroup.Name);
            Assert.IsTrue(categoryGroup.Hidden);
            Assert.IsTrue(categoryGroup.Deleted);
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
        public void CategoriesResponse()
        {
            var json = MockJsonData.CategoriesResponse;
            var categoriesResponse = JsonConvert.DeserializeObject<CategoriesResponse>(json);

            Assert.IsNotNull(categoriesResponse);
            Assert.IsNotNull(categoriesResponse.Data);
            Assert.IsNotNull(categoriesResponse.Data.CategoryGroups);
            Assert.AreEqual(1, categoriesResponse.Data.CategoryGroups.Count);
            Assert.IsNotNull(categoriesResponse.Data.CategoryGroups[0]);
            _testObject = categoriesResponse.Data.CategoryGroups[0]; this.CategoryGroup();
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
            _testObject = month; this.MonthSummary();
            Assert.AreEqual(1, month.Categories.Count);
            Assert.IsNotNull(month.Categories[0]);
            _testObject = month.Categories[0]; this.Category();
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
            Assert.AreEqual("2019-06-01", month.Month);
            Assert.AreEqual("month note", month.Note);
            Assert.AreEqual(1000, month.Income);
            Assert.AreEqual(150000, month.Budgeted);
            Assert.AreEqual(-148340, month.Activity);
            Assert.AreEqual(561970, month.ToBeBudgeted);
            Assert.AreEqual(152, month.AgeOfMoney);
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
            Assert.AreEqual(5000, months.Data.ServerKnowledge);
        }

        [TestMethod]
        public void Payee()
        {
            Payee payee;
            if (_testObject == null)
            {
                var json = MockJsonData.Payee;
                payee = JsonConvert.DeserializeObject<Payee>(json);
            }
            else
                payee = _testObject as Payee;

            Assert.IsNotNull(payee);
            Assert.AreEqual("hhh-iii-iii", payee.Id);
            Assert.AreEqual("English language school", payee.Name);
            Assert.IsNull(payee.TransferAccountId);
        }

        [TestMethod]
        public void PayeeWithTransferAccount()
        {
            Payee payee;
            if (_testObject == null)
            {
                var json = MockJsonData.PayeeWithTransferAccount;
                payee = JsonConvert.DeserializeObject<Payee>(json);
            }
            else
                payee = _testObject as Payee;

            Assert.IsNotNull(payee);
            Assert.AreEqual("hhh-iii-jjj", payee.Id);
            Assert.AreEqual("Transfer : Payroll account", payee.Name);
            Assert.AreEqual("aaa-bbb-ccc", payee.TransferAccountId);
        }

        [TestMethod]
        public void PayeeResponse()
        {
            var json1 = MockJsonData.PayeeResponse1;
            var payee1 = JsonConvert.DeserializeObject<PayeeResponse>(json1);

            Assert.IsNotNull(payee1);
            Assert.IsNotNull(payee1.Data);
            Assert.IsNotNull(payee1.Data.Payee);
            _testObject = payee1.Data.Payee; this.Payee();

            var json2 = MockJsonData.PayeeResponse2;
            var payee2 = JsonConvert.DeserializeObject<PayeeResponse>(json2);

            Assert.IsNotNull(payee2);
            Assert.IsNotNull(payee2.Data);
            Assert.IsNotNull(payee2.Data.Payee);
            _testObject = payee2.Data.Payee; this.PayeeWithTransferAccount();
        }

        [TestMethod]
        public void PayeesResponse()
        {
            var json = MockJsonData.PayeesResponse;
            var payees = JsonConvert.DeserializeObject<PayeesResponse>(json);

            Assert.IsNotNull(payees);
            Assert.IsNotNull(payees.Data);
            Assert.IsNotNull(payees.Data.Payees);
            Assert.AreEqual(2, payees.Data.Payees.Count);

            Assert.IsNotNull(payees.Data.Payees[0]);
            _testObject = payees.Data.Payees[0]; this.Payee();

            Assert.IsNotNull(payees.Data.Payees[1]);
            _testObject = payees.Data.Payees[1]; this.PayeeWithTransferAccount();
        }

        [TestMethod]
        public void SubTransaction1()
        {
            SubTransaction subtransaction;
            if (_testObject == null)
            {
                var json1 = MockJsonData.SubTransaction1;
                subtransaction = JsonConvert.DeserializeObject<SubTransaction>(json1);
            }
            else
                subtransaction = _testObject as SubTransaction;

            Assert.IsNotNull(subtransaction);
            Assert.AreEqual("subtransaction-id-1", subtransaction.Id);
            Assert.AreEqual("transaction-id-1", subtransaction.TransactionId);
            Assert.AreEqual(-76600, subtransaction.Amount);
            Assert.AreEqual("memo subtransaction-1", subtransaction.Memo);
            Assert.AreEqual("payee-id-1", subtransaction.PayeeId);
            Assert.AreEqual("category-id-1", subtransaction.CategoryId);
            Assert.IsNull(subtransaction.TransferAccountId);
            Assert.IsFalse(subtransaction.Deleted);
        }

        [TestMethod]
        public void SubTransaction2()
        {
            SubTransaction subtransaction;
            if (_testObject == null)
            {
                var json = MockJsonData.SubTransaction2;
                subtransaction = JsonConvert.DeserializeObject<SubTransaction>(json);
            }
            else
                subtransaction = _testObject as SubTransaction;

            Assert.IsNotNull(subtransaction);
            Assert.AreEqual("subtransaction-id-2", subtransaction.Id);
            Assert.AreEqual("transaction-id-1", subtransaction.TransactionId);
            Assert.AreEqual(-6000, subtransaction.Amount);
            Assert.AreEqual("memo subtransaction-2", subtransaction.Memo);
            Assert.AreEqual("payee-id-2", subtransaction.PayeeId);
            Assert.AreEqual("category-id-2", subtransaction.CategoryId);
            Assert.IsNull(subtransaction.TransferAccountId);
            Assert.IsFalse(subtransaction.Deleted);
        }

        [TestMethod]
        public void TransactionSummary()
        {
            TransactionSummary transaction;
            if (_testObject == null)
            {
                var json1 = MockJsonData.TransactionSummary;
                transaction = JsonConvert.DeserializeObject<TransactionSummary>(json1);
            }
            else
                transaction = _testObject as TransactionSummary;

            Assert.IsNotNull(transaction);
            Assert.AreEqual("transaction-id-1", transaction.Id);
            Assert.AreEqual("2019-06-04", transaction.Date);
            Assert.AreEqual(-92600, transaction.Amount);
            Assert.AreEqual("memo transaction 1", transaction.Memo);
            Assert.AreEqual("reconciled", transaction.Cleared);
            Assert.IsTrue(transaction.Approved);
            Assert.AreEqual("yellow", transaction.FlagColor);
            Assert.AreEqual("account-id-1", transaction.AccountId);
            Assert.AreEqual("payee-id-1", transaction.PayeeId);
            Assert.AreEqual("category-split-id-1", transaction.CategoryId);
            Assert.IsNull(transaction.TransferAccountId);
            Assert.IsNull(transaction.TransferTransactionId);
            Assert.IsNull(transaction.MatchedTransactionId);
            Assert.IsNull(transaction.ImportId);
            Assert.IsTrue(transaction.Deleted);
        }

        [TestMethod]
        public void TransactionDetail()
        {
            TransactionDetail transaction;
            if (_testObject == null)
            {
                var json1 = MockJsonData.TransactionDetail;
                transaction = JsonConvert.DeserializeObject<TransactionDetail>(json1);
            }
            else
                transaction = _testObject as TransactionDetail;

            Assert.IsNotNull(transaction);
            _testObject = transaction; this.TransactionSummary();
            Assert.AreEqual("Payroll account", transaction.AccountName);
            Assert.AreEqual("Payee 1", transaction.PayeeName);
            Assert.AreEqual("Split (Multiple Categories)...", transaction.CategoryName);
            Assert.AreEqual(2, transaction.SubTransactions.Count);
            transaction.SubTransactions.ForEach(st => Assert.IsNotNull(st));
            _testObject = transaction.SubTransactions[0]; this.SubTransaction1();
            _testObject = transaction.SubTransactions[1]; this.SubTransaction2();
        }

        [TestMethod]
        public void TransactionsResponse()
        {
            var json = MockJsonData.TransactionsResponse;
            var transactionsResponse = JsonConvert.DeserializeObject<TransactionsResponse>(json);

            Assert.IsNotNull(transactionsResponse);
            Assert.IsNotNull(transactionsResponse.Data);
            Assert.AreEqual(2000, transactionsResponse.Data.ServerKnowledge);
            Assert.IsNotNull(transactionsResponse.Data.Transactions);
            Assert.AreEqual(1, transactionsResponse.Data.Transactions.Count);
            Assert.IsNotNull(transactionsResponse.Data.Transactions[0]);
            _testObject = transactionsResponse.Data.Transactions[0]; this.TransactionDetail();
        }

        [TestMethod]
        public void TransactionResponse()
        {
            var json = MockJsonData.TransactionResponse;
            var transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(json);

            Assert.IsNotNull(transactionResponse);
            Assert.IsNotNull(transactionResponse.Data);
            Assert.IsNotNull(transactionResponse.Data.Transaction);
            _testObject = transactionResponse.Data.Transaction; this.TransactionDetail();
        }

        [TestMethod]
        public void ScheduledSubTransaction()
        {
            ScheduledSubTransaction subtransaction;
            if (_testObject == null)
            {
                var json = MockJsonData.ScheduledSubTransaction;
                subtransaction = JsonConvert.DeserializeObject<ScheduledSubTransaction>(json);
            }
            else
                subtransaction = _testObject as ScheduledSubTransaction;

            Assert.IsNotNull(subtransaction);
            Assert.AreEqual("scheduled-subtransaction-id-1", subtransaction.Id);
            Assert.AreEqual("scheduled-tranaction-id-1", subtransaction.ScheduledTransactionId);
            Assert.AreEqual(-13640, subtransaction.Amount);
            Assert.AreEqual("subtransaction memo", subtransaction.Memo);
            Assert.AreEqual("payee-id-1", subtransaction.PayeeId);
            Assert.AreEqual("category-id-1", subtransaction.CategoryId);
            Assert.AreEqual("transfer-account-id-1", subtransaction.TransferAccountId);
            Assert.IsTrue(subtransaction.Deleted);
        }

        [TestMethod]
        public void ScheduledTransactionSummary()
        {
            ScheduledTransactionSummary transaction;
            if (_testObject == null)
            {
                var json = MockJsonData.ScheduledTransactionSummary;
                transaction = JsonConvert.DeserializeObject<ScheduledTransactionSummary>(json);
            }
            else
                transaction = _testObject as ScheduledTransactionSummary;

            Assert.IsNotNull(transaction);
            Assert.AreEqual("scheduled-transaction-id-1", transaction.Id);
            Assert.AreEqual("2019-02-01", transaction.DateFirst);
            Assert.AreEqual("2019-07-01", transaction.DateNext);
            Assert.AreEqual("monthly", transaction.Frequency);
            Assert.AreEqual(-46640, transaction.Amount);
            Assert.AreEqual("scheduled transaction memo", transaction.Memo);
            Assert.AreEqual("yellow", transaction.FlagColor);
            Assert.AreEqual("account-id-1", transaction.AccountId);
            Assert.AreEqual("payee-id-1", transaction.PayeeId);
            Assert.AreEqual("category-id-1", transaction.CategoryId);
            Assert.AreEqual("transfer-account-id-1", transaction.TransferAccountId);
            Assert.IsTrue(transaction.Deleted);
        }

        [TestMethod]
        public void ScheduledTransactionDetail()
        {
            ScheduledTransactionDetail transaction;
            if (_testObject == null)
            {
                var json = MockJsonData.ScheduledTransactionDetail;
                transaction = JsonConvert.DeserializeObject<ScheduledTransactionDetail>(json);
            }
            else
                transaction = _testObject as ScheduledTransactionDetail;

            Assert.IsNotNull(transaction);
            _testObject = transaction; this.ScheduledTransactionSummary();

            Assert.AreEqual("account name 1", transaction.AccountName);
            Assert.AreEqual("category name 1", transaction.CategoryName);
            Assert.AreEqual("payee name 1", transaction.PayeeName);
            Assert.AreEqual(1, transaction.SubTransactions.Count);

            Assert.IsNotNull(transaction.SubTransactions[0]);
            _testObject = transaction.SubTransactions[0]; this.ScheduledSubTransaction();
        }

        [TestMethod]
        public void ScheduledTransactionResponse()
        {
            var json = MockJsonData.ScheduledTransactionResponse;
            var transactionResponse = JsonConvert.DeserializeObject<ScheduledTransactionResponse>(json);

            Assert.IsNotNull(transactionResponse);
            Assert.IsNotNull(transactionResponse.Data);
            Assert.IsNotNull(transactionResponse.Data.ScheduledTransaction);
            _testObject = transactionResponse.Data.ScheduledTransaction; this.ScheduledTransactionDetail();
        }

        [TestMethod]
        public void ScheduledTransactionsResponse()
        {
            var json = MockJsonData.ScheduledTransactionsResponse;
            var transactionsResponse = JsonConvert.DeserializeObject<ScheduledTransactionsResponse>(json);

            Assert.IsNotNull(transactionsResponse);
            Assert.IsNotNull(transactionsResponse.Data);
            Assert.IsNotNull(transactionsResponse.Data.ScheduledTransactions);
            Assert.IsNotNull(transactionsResponse.Data.ScheduledTransactions[0]);
            _testObject = transactionsResponse.Data.ScheduledTransactions[0]; this.ScheduledTransactionDetail();
        }
    }
}
