using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Duende.IdentityServer.Api;

public class Startup
{
    private readonly HttpMessageHandler identityServerMessageHandler;

    public Startup(HttpMessageHandler identityServerMessageHandler)
    {
            this.identityServerMessageHandler = identityServerMessageHandler;
        }

    public void ConfigureServices(IServiceCollection services)
    {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost";
                    options.BackchannelHttpHandler = this.identityServerMessageHandler;
                    options.TokenValidationParameters.ValidateAudience = false;
                });
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

#pragma warning disable S2325
    public void Configure(IApplicationBuilder app)
#pragma warning restore S2325
    {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(builder => builder.MapControllers().RequireAuthorization());
    }
}