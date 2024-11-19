using Azure;
using Azure.AI.TextAnalytics;


namespace Q_A_Services
{
    public class NLPService : BaseService
    {
        private readonly TextAnalyticsClient _client;

        public NLPService()
        {
            // Initialize Text Analytics Client using values from BaseService
            _client = new TextAnalyticsClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
        }

        public string DetectLanguage(string inputText)
        {
            var language = _client.DetectLanguage(inputText).Value;
            return language.Name;
        }

        public string AnalyzeSentiment(string inputText)
        {
            var response = _client.AnalyzeSentiment(inputText);
            return response.Value.Sentiment.ToString();
        }
    }
}
