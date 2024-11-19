using System.Net;
using System.Text.Json;

namespace Q_A_Services
{
    public class QnAService : BaseService
    {
        public async Task<string> GetAnswerAsync(string question)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);

            // Prepare the request
            var requestContent = new { question = question, top = 1 };
            var content = new StringContent(JsonSerializer.Serialize(requestContent), System.Text.Encoding.UTF8, "application/json");

            var url = $"{Endpoint}/language/:query-knowledgebases?projectName={ProjectName}&api-version={ApiVersion}&deploymentName={DeploymentName}";

            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var answer = JsonDocument.Parse(jsonResponse).RootElement
                    .GetProperty("answers")[0]
                    .GetProperty("answer").GetString();

                return answer ?? "No relevant answer found.";
            }
            else
            {
                return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
        }
    }
}
