using Blazorise;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Symbiotiq_Balzor_Ui.Data_Access;
using Symbiotiq_Balzor_Ui.MongoDB;

namespace Symbiotiq_Balzor_Ui;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
        builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

        builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddSingleton<IMongoUserData, MongoUserData>();
        builder.Services.AddSingleton<IMongoShopData, MongoShopData>();
        builder.Services.AddSingleton<IMongoNonFoodItemData, MongoNonFoodItemData>();
        builder.Services.AddSingleton<IMongoFoodItemData, MongoFoodItemData>();

        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).
            AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
            {
                policy.RequireClaim("jobTitle", "Admin");

            }

            );
        });

    }

}
