using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.infrustructure;
using SchoolProject.infrustructure.DbContext;
using SchoolProject.Service;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Api.Configurations.Swagger;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infrustructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependencies
builder.Services.AddInfrustructureDependencies().AddCoreDependencies().AddServiceDependencies().AddServiceRegisteration(builder.Configuration);
builder.Services.AddSwagger();
#endregion

#region Connection
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR"),
        new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

#region AllowCORS
const string cors = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion
var app = builder.Build();

#region Seeder
using (var createscope = app.Services.CreateScope())
{
    var userManger = createscope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManger = createscope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await UserSeeder.SeedAsync(userManger);
    await RolesSeeder.SeedAsync(roleManger);
}

;


#endregion




#region Update
//update database
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();//catch
try
{
    var DbContext = services.GetRequiredService<ApplicationDbContext>();
    await DbContext.Database.MigrateAsync();
    
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error during Apply migration");

}
#endregion


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
