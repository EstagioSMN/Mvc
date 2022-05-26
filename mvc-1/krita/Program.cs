var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

IConfiguration configurations = builder.Configuration;

var appSettings = configurations.Get<AppSettings>();

builder.Services.AddSingleton(appSettings);
builder.Services.AddScoped<IEmailHandler, EmailHandler>();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
