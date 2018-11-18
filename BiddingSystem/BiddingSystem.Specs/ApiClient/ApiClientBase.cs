namespace BiddingSystem.Specs.ApiClient
{
    public class ApiClientBase
    {
        protected MyRestClient RestClient { get; }

        public ApiClientBase(MyRestClient restClient)
        {
            RestClient = restClient;
        }
    }
}