using System;
namespace YNABTests
{
    public static class MockJsonData
    { 
        public static string GetFields(this string jsonObject)
        {
            return jsonObject.Trim().Substring(1, jsonObject.Length - 2);
        }

        public static string User = @"{
            ""id"" : ""user-id-1""
        }";

        public static string UserResponse = @"{
            ""data"" : {
                ""user"" : " + User + @"
            }
        }";

        public static string BudgetSettings = @"{
            ""date_format"": {
                ""format"": ""DD/MM/YYYY""
            },
            ""currency_format"": {
                ""iso_code"": ""EUR"",
                ""example_format"": ""123 456,78"",
                ""decimal_digits"": 2,
                ""decimal_separator"": "","",
                ""symbol_first"": false,
                ""group_separator"": "" "",
                ""currency_symbol"": ""€"",
                ""display_symbol"": true
            }
        }";

        public static string BudgetSettingsResponse = @"{
            ""data"": {
                ""settings"": " + BudgetSettings + @"
            }
        }";

        public static string BudgetSummary = @"{
            ""id"": ""budget-id-1"",
            ""name"": ""Budget Name 1"",
            ""last_modified_on"": ""2019-01-01T23:59:59+00:00"",
            ""first_month"": ""2018-12-01"",
            ""last_month"": ""2019-06-01"", " +
            BudgetSettings.GetFields() + @"
        }";

        public static string BudgetSummaryResponse = @"{
            ""data"": {
                ""budgets"": [" + BudgetSummary + ", " + BudgetSummary + ", " + BudgetSummary + @"]
            }
        }";
        
        public static string Account = @"{
            ""id"": ""aaa-bbb-ccc"",
            ""name"": ""Payroll account"",
            ""type"": ""savings"",
            ""on_budget"": true,
            ""closed"": false,
            ""note"": null,
            ""balance"": 1234560,
            ""cleared_balance"": 1230000,
            ""uncleared_balance"": -4560,
            ""transfer_payee_id"": ""aaa-bbb-ccc-ddd"",
            ""deleted"": false
        }";

        public static string AccountResponse = @"{
            ""data"": { ""account"" : " + Account + @" }
        }";

        public static string AccountsResponse = @"{
            ""data"": { ""accounts"" : [" + Account + ", " + Account + ", " + Account + @"], ""server_knowledge"": 3000 }
        }";

        public static string Category = @"{
            ""id"": ""category-id-1"",
            ""category_group_id"": ""category-group-id-1"",
            ""name"": ""Family leisure"",
            ""hidden"": true,
            ""original_category_group_id"": null,
            ""note"": ""category note 1"",
            ""budgeted"": 1000,
            ""activity"": 2000,
            ""balance"": -1000,
            ""goal_type"": null,
            ""goal_creation_month"": null,
            ""goal_target"": 0,
            ""goal_target_month"": null,
            ""goal_percentage_complete"": null,
            ""deleted"": true
        }";

        public static string CategoryResponse = @"{
            ""data"" : { ""category"" : " + Category + @" }
        }";

        public static string CategoryGroup = @"{
                ""id"": ""category-group-id-1"",
                ""name"": ""Category Group 1"",
                ""hidden"": true,
                ""deleted"": true
        }";

        public static string CategoryGroupWithCategories = @"{
                " + CategoryGroup.GetFields() + @",
                ""categories"": [" + Category + ", " + Category + ", " + Category + @"]
        }";

        public static string CategoriesResponse = @"{
            ""data"" : { ""category_groups"" : [ " +
                CategoryGroupWithCategories + @"]
            }
        }";

        public static string MonthSummary = @"{
            ""month"": ""2019-06-01"",
            ""note"": ""month note"",
            ""income"": 1000,
            ""budgeted"": 150000,
            ""activity"": -148340,
            ""to_be_budgeted"": 561970,
            ""age_of_money"": 152,
            ""deleted"": true
        }";

        public static string MonthDetail = @"{
            " + MonthSummary.GetFields() + @",
            ""categories"": [" + Category + @"]
        }";

        public static string BudgetMonthResponse = @"{
            ""data"" : { ""month"" : " + MonthDetail + @" }
        }";

        public static string BudgetMonthsResponse = @"{
            ""data"" : {
                ""months"" : [" + MonthSummary + ", " + MonthSummary + @"]
            }
        }";

        public static string Payee = @"{
            ""id"": ""hhh-iii-iii"",
            ""name"": ""English language school"",
            ""transfer_account_id"": null,
            ""deleted"": false
        }";

        public static string PayeeWithTransferAccount = @"{
            ""id"": ""hhh-iii-jjj"",
            ""name"": ""Transfer : Payroll account"",
            ""transfer_account_id"": ""aaa-bbb-ccc"",
            ""deleted"": false
        }";

        public static string PayeeResponse1 = @"{
            ""data"" : { ""payee"" : " + Payee + @" }
        }";

        public static string PayeeResponse2 = @"{
            ""data"" : { ""payee"" : " + PayeeWithTransferAccount + @" }
        }";

        public static string PayeesResponse = @"{
            ""data"" : { ""payees"" : [" + Payee + ", " + PayeeWithTransferAccount + @"],
                         ""server_knowledge"": 3000
            }
        }";

        public static string PayeesResponseWithLastKnowledgeOfServer = @"{
            ""data"" : { ""payees"" : [" +  PayeeWithTransferAccount + @"],
                         ""server_knowledge"": 4000
            }
        }";

        public static string SubTransaction1 = @"{
            ""id"": ""subtransaction-id-1"",
            ""transaction_id"": ""transaction-id-1"",
            ""amount"": -76600,
            ""memo"": ""memo subtransaction-1"",
            ""payee_id"": ""payee-id-1"",
            ""category_id"": ""category-id-1"",
            ""transfer_account_id"": null,
            ""transfer_transaction_id"": null,
            ""deleted"": false
        }";

        public static string SubTransaction2 = @"{
            ""id"": ""subtransaction-id-2"",
            ""transaction_id"": ""transaction-id-1"",
            ""amount"": -6000,
            ""memo"": ""memo subtransaction-2"",
            ""payee_id"": ""payee-id-2"",
            ""category_id"": ""category-id-2"",
            ""transfer_account_id"": null,
            ""transfer_transaction_id"": null,
            ""deleted"": false
        }";

        public static string TransactionSummary = @"{
            ""id"": ""transaction-id-1"",
            ""date"": ""2019-06-04"",
            ""amount"": -92600,
            ""memo"": ""memo transaction 1"",
            ""cleared"": ""reconciled"",
            ""approved"": true,
            ""flag_color"": ""yellow"",
            ""account_id"": ""account-id-1"",
            ""payee_id"": ""payee-id-1"",
            ""category_id"": ""category-split-id-1"",
            ""transfer_account_id"": null,
            ""transfer_transaction_id"": null,
            ""matched_transaction_id"": null,
            ""import_id"": null,
            ""deleted"": true
        }";

        public static string TransactionDetail = @"{
            " + TransactionSummary.GetFields() + @",
            ""account_name"": ""Payroll account"",
            ""payee_name"": ""Payee 1"",
            ""category_name"": ""Split (Multiple Categories)..."",
            ""subtransactions"": [" + SubTransaction1 + ", " + SubTransaction2 + @"]
        }";

        public static string TransactionsResponse = @"{
            ""data"": { ""transactions"" : [" + TransactionDetail + @"],
                ""server_knowledge"": 2000
            }
        }";

        public static string TransactionResponse = @"{
            ""data"" : { ""transaction"" : " + TransactionDetail + @"}
        }";

        public static string TransactionsResponseForAccounts = @"{
            ""data"": { ""transactions"" : [" + TransactionDetail + @"],
                ""server_knowledge"": 2011
            }
        }";

        public static string TransactionsResponseForCategories = @"{
            ""data"": { ""transactions"" : [" + TransactionDetail + @"],
                ""server_knowledge"": 2022
            }
        }";

        public static string TransactionsResponseForPayees = @"{
            ""data"": { ""transactions"" : [" + TransactionDetail + @"],
                ""server_knowledge"": 2033
            }
        }";

        public static string ScheduledSubTransaction = @"{
            ""id"": ""scheduled-subtransaction-id-1"",
            ""scheduled_transaction_id"": ""scheduled-tranaction-id-1"",
            ""amount"": -13640,
            ""memo"": ""subtransaction memo"",
            ""payee_id"": ""payee-id-1"",
            ""category_id"": ""category-id-1"",
            ""transfer_account_id"": ""transfer-account-id-1"",
            ""deleted"": true
        }";

        public static string ScheduledTransactionSummary = @"{
            ""id"": ""scheduled-transaction-id-1"",
            ""date_first"": ""2019-02-01"",
            ""date_next"": ""2019-07-01"",
            ""frequency"": ""monthly"",
            ""amount"": -46640,
            ""memo"": ""scheduled transaction memo"",
            ""flag_color"": ""yellow"",
            ""account_id"": ""account-id-1"",
            ""payee_id"": ""payee-id-1"",
            ""category_id"": ""category-id-1"",
            ""transfer_account_id"": ""transfer-account-id-1"",
            ""deleted"": true
        }";

        public static string ScheduledTransactionDetail = @"{
            " + ScheduledTransactionSummary.GetFields() + @",
            ""account_name"": ""account name 1"",
            ""payee_name"": ""payee name 1"",
            ""category_name"": ""category name 1"",
            ""subtransactions"": [ " + ScheduledSubTransaction + @" ]
        }";

        public static string ScheduledTransactionResponse = @"{
            ""data"" : {
                ""scheduled_transaction"" : " + ScheduledTransactionDetail + @"
            }
        }";

        public static string ScheduledTransactionsResponse = @"{
            ""data"" : {
                ""scheduled_transactions"" : [" + ScheduledTransactionDetail + @" ]
            }
        }";

        public static string BudgetDetail = @"{ " +
            BudgetSummary.GetFields() + @",
            ""accounts"" : [ " + Account + @" ],
            ""payees"" : [ " + Payee + @" ],
            ""payee_locations"" : [ ],
            ""category_groups"" : [ " + CategoryGroup + @" ],
            ""categories"" : [ " + Category + @" ],
            ""months"" : [ " + MonthDetail + @" ],
            ""transactions"" : [ " + TransactionSummary + @" ],
            ""subtransactions"" : [ " + SubTransaction1 + ", " + SubTransaction2 + @" ],
            ""scheduled_transactions"" : [ " + ScheduledTransactionSummary + @" ],
            ""scheduled_subtransactions"" : [ " + ScheduledSubTransaction + @"],
        }";

        public static string BudgetDetailResponse = @"{
            ""data"" : {
                ""budget"" : " + BudgetDetail + @"
            }
        }";
    }
}
