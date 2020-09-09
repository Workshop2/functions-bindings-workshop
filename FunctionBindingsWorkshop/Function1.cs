using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionBindingsWorkshop
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [QueueTrigger("person-registered", Connection = "AzureWebJobsStorage")] Person person,
            [CosmosDB(
                databaseName: "OurProduct",
                collectionName: "People",
                ConnectionStringSetting = "CosmosDBConnection")]out dynamic document,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {person.Name}");

            document = person;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
