using JokeApp.Mapper;

namespace JokeApp.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new JokeProfile());

            });
            return services;
        }
    }
}
