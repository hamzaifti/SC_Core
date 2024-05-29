using Microsoft.Extensions.DependencyInjection;
using SC_Service.Auth;
using SC_Service.CashSummaries;
using SC_Service.IOU;
using SC_Service.Roles;
using SC_Service.Transactions;
using SC_Service.User;

namespace SC_Dependencies
{
    public static class Dependencies
    {
        public static void RegisteredDependencies(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IIouService, IouService>();
            services.AddScoped<ICashSummyService, CashSummaryService>();
        }
    }
}
