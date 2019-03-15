using Microsoft.Extensions.DependencyInjection;
using DAL.Context;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<DALContext>();          
        }
    }
}
