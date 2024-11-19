
namespace Q_A_Services
{ 
        public class Program
        {
            static async Task Main(string[] arg)
            {
                // Initialize NLP and QnA services 
                var nlpService = new NLPService();
                var qnaService = new QnAService();

                bool askAgain = true;

                while (askAgain)
                {
                    Console.WriteLine("Enter your AI related question:\n");
                    string inputText = Console.ReadLine();

                    // Detect language using NLP
                    string language = nlpService.DetectLanguage(inputText);
                    Console.WriteLine($"Detected Language: {language}\n");

                    // Query the QnA knowledge base
                    string answer = await qnaService.GetAnswerAsync(inputText);
                    Console.WriteLine($"Answer: {answer}\n");

                    Console.WriteLine("Do you want to ask another question? y/n");
                    string response = Console.ReadLine()?.Trim().ToLower();

                    askAgain = response == "y";
                    Console.Clear();
                }
                Console.WriteLine("Thank you for using the QnA Service. Goodbye!");
            }
        }
}
