using AutoRepairShop.Domain.Ports;

namespace AutoRepairShop.Web.Configuration;

public class AppConfiguration : IAppConfiguration
{
    private readonly IConfiguration _configuration;

    public AppConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration.GetValue<string>("ConnectionStrings:SQLite") ?? string.Empty;
}
