using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ynab
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("category_group_id")]
        public string CategoryGroupId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("original_category_group_id")]
        public string OriginalCategoryGroupId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("budgeted")]
        public long Budgeted { get; set; }

        [JsonProperty("activity")]
        public long Activity { get; set; }

        [JsonProperty("balance")]
        public long Balance{ get; set; }

        [JsonProperty("goal_type")]
        public string GoalType { get; set; }

        [JsonProperty("goal_creation_month")]
        public string GoalCreationMonth { get; set; }

        [JsonProperty("goal_target")]
        public long GoalTarget { get; set; }

        [JsonProperty("goal_target_month")]
        public string GoalTargetMonth { get; set; }

        [JsonProperty("goal_percentage_complete")]
        public long? GoalPercentageComplete { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class CategoryWrapper
    {
        [JsonProperty("category")]
        public Category Category { get; set; }
    }

    public class CategoryResponse
    {
        [JsonProperty("data")]
        public CategoryWrapper Data { get; set; }
    }

    public class CategoryGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }

    public class CategoryGroupWithCategories
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }

    public class CategoryGroupsWrapper
    {
        [JsonProperty("category_groups")]
        public List<CategoryGroupWithCategories> CategoryGroups { get; set; }

        [JsonProperty("server_knowledge")]
        public long ServerKnowledge { get; set; }
    }

    public class CategoriesResponse
    {
        [JsonProperty("data")]
        public CategoryGroupsWrapper Data { get; set; }
    }
}
