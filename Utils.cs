using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
namespace Azure_Core_API_CRUD;

public static class Utils
{
    public static void SetupWebApplication(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
            options.DocumentTitle = "My Swagger";
        });
    }

    public static WebApplication BuildWebApplication(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddStudentRepository();

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
            options.SupportedCultures = new[] { new CultureInfo("en-US") };
            options.SupportedUICultures = new[] { new CultureInfo("en-US") };
        });

        builder.Services.AddDbContext<SchoolDbContext>(options =>
        options.UseSqlServer("Server=tcp:learning-token-prafful.database.windows.net,1433;Initial Catalog=db_Learnings;Persist Security Info=False;User ID=azure_pks;Password=Mind@4321!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
        b => b.MigrationsAssembly("Azure_Core_API_CRUD")));

        return builder.Build();
    }
}
