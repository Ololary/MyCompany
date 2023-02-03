using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.Bind("Project", new Config());
// ���������� ������ ��������� � �������� ��������
builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();
//���������� �������� � ���� ������
builder.Services.AddDbContext<AppDbContext>(el=>el.UseSqlServer(Config.ConnectionString));

//��������� Identity �������
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}
).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//��������� authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MyCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;

});

//����������� �������� ����������� ��� Admin area
builder.Services.AddAuthorization(el =>
{
    el.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//��������� ������� ��� ������������ � ������������� (MVC)
builder.Services.AddControllersWithViews(el =>
{
    el.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   
}
app.UseHsts();
//��������� ������� �������������
app.UseRouting();
app.UseStaticFiles();

//��������� �������������� � �����������.
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//��������� ��������
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
