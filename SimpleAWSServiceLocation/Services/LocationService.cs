using Amazon;
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace SimpleAWSServiceLocation.Services
{
    public class LocationService
    {
        private readonly IAmazonLocationService _client;

        public string IndexName { get; private set; }

        public LocationService(IAmazonLocationService amazonLocationService)
        {
            IndexName = "MyIndex"; 
            _client = amazonLocationService;
        }

        public async Task<SearchPlaceIndexForTextResponse> SearchPlace(string text)
        {
            var location1Request = new SearchPlaceIndexForTextRequest()
            {
                IndexName = IndexName,
                Text = text
            };
            return await _client.SearchPlaceIndexForTextAsync(location1Request);
        }

    }
}
