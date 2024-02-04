using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersCompanies.DAL.EF;
using UsersCompanies.DAL.Interfaces;
using UsersCompanies.DAL.Repositories;
using UsersCompanies.Web.MapppingProfiles;
using UsersCompany.BLL.Interfaces;
using UsersCompany.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// DbContext
builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

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
