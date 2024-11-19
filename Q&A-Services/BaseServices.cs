using Microsoft.Extensions.Configuration;

namespace Q_A_Services
{
    public abstract class BaseService
    {
        protected readonly IConfiguration Configuration;

        protected BaseService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // Properties to access shared configuration values
        protected string Endpoint => Configuration["AzureSettings:Endpoint"];
        protected string ApiKey => Configuration["AzureSettings:ApiKey"];
        protected string ProjectName => Configuration["AzureSettings:ProjectName"];
        protected string DeploymentName => Configuration["AzureSettings:DeploymentName"];
        protected string ApiVersion => Configuration["AzureSettings:ApiVersion"];
    }
}
