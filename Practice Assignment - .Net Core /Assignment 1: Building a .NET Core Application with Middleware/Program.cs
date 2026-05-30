var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();


// Global Error Handling Middleware
app.UseExceptionHandler("/Error");


// HTTPS Redirection
app.UseHttpsRedirection();


// Custom Request Logging Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    await next();

    Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
});


// Content Security Policy Middleware
app.Use(async (context, next) =>
{
    context.Response.Headers.Add(
        "Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self';");

    await next();
});


// Serve Static Files
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
