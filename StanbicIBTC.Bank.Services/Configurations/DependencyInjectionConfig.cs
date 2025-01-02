namespace StanbicIBTC.Bank.Services.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            // Add other services like CardService, TransactionService, etc.
        }
    }
}
