var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LoggingFilter>();

builder.Services.AddSingleton<
    ILoggingService,
    LoggingService>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern:
    "{controller=Account}/{action=Login}/{id?}");

app.Run();
