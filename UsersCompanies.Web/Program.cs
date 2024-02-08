using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersCompanies.DAL.Data;
using UsersCompanies.Domain.Repositories;
using UsersCompanies.DAL.Repositories;
using UsersCompanies.Web.MapppingProfiles;
using UsersCompanies.Domain.Services;
using UsersCompanies.BLL.Services;
using NLog.Web;
using NLog;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // AutoMapper
    builder.Services.AddAutoMapper(typeof(MappingProfiles));

    // DbContext
    builder.Services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Dependency Injection
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<ICompanyService, CompanyService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IJobService, JobService>();
    builder.Services.AddScoped<IDbInitializer, DbInitializer>();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Company}/{action=GetCompanies}/{id?}");

    // Initialize database
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    initializer.Initialize();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit 
    NLog.LogManager.Shutdown();
}
