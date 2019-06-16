using System;
namespace YNABTests
{
    public static class MockJsonData
    {
        public static string BudgetSettingsResponse = @"{
            ""data"": {
                ""settings"": {
                    ""date_format"": {
                        ""format"": ""DD/MM/YYYY""
                    },
                    ""currency_format"": {
                        ""iso_code"": ""EUR"",
                        ""example_format"": ""123 456,78"",
                        ""decimal_digits"": 2,
                        ""decimal_separator"": "","",
                        ""symbol_first"": false,
                        ""group_separator"": "" "",
                        ""currency_symbol"": ""€"",
                        ""display_symbol"": true
                    }
                }
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
            ""id"": ""eee-fff-ggg"",
            ""category_group_id"": ""bbb-ccc-ddd"",
            ""name"": ""Family leisure"",
            ""hidden"": false,
            ""original_category_group_id"": null,
            ""note"": null,
            ""budgeted"": 0,
            ""activity"": 0,
            ""balance"": 0,
            ""goal_type"": null,
            ""goal_creation_month"": null,
            ""goal_target"": 0,
            ""goal_target_month"": null,
            ""goal_percentage_complete"": null,
            ""deleted"": false
        }";

        public static string CategoryResponse = @"{
            ""data"" : { ""category"" : " + Category + @" }
        }";

        public static string CategoryGroupWithCategories = @"{
                ""id"": ""eee-eee-eee"",
                ""name"": ""Group Category"",
                ""hidden"": false,
                ""deleted"": false,
                ""categories"": [" + Category + ", " + Category + ", " + Category + @"]
        }";

        public static string CategoriesResponse = @"{
            ""data"" : { ""category_groups"" : [ " +
                CategoryGroupWithCategories + ", " +
                CategoryGroupWithCategories + @"]
            }
        }";

        public static string MonthDetail = @"{
            ""month"": ""2019-06-01"",
            ""note"": null,
            ""income"": 0,
            ""budgeted"": 150000,
            ""activity"": -1483490,
            ""to_be_budgeted"": 5619740,
            ""age_of_money"": 152,
            ""deleted"": false,
            ""categories"": [" + Category + ", " + Category + ", " + Category + @"]
        }";

        public static string BudgetMonthResponse = @"{
            ""data"" : { ""month"" : " + MonthDetail + @" }
        }";

        public static string MonthSummary = @"{
            ""month"": ""2019-06-01"",
            ""note"": null,
            ""income"": 0,
            ""budgeted"": 150000,
            ""activity"": -1483490,
            ""to_be_budgeted"": 5619740,
            ""age_of_money"": 152,
            ""deleted"": false
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
    }
}
