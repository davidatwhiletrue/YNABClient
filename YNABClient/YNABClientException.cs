using System;
using Newtonsoft.Json;

namespace ynab
{
    public class ErrorDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("error")]
        public ErrorDetail error { get; set; }
    }

    public class YNABClientException : Exception
    {
        public ErrorDetail Error { get; set; }

        public YNABClientException(string json) : base("Error from YNAB API. See the Error object for the details.")
        {
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(json);

            this.Error = new ErrorDetail()
            {
                Id = errorResponse.error.Id,
                Name = errorResponse.error.Name,
                Detail = errorResponse.error.Detail
            };
        }
    }
}
