var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Redirect home page to Register page
app.MapGet("/", context =>
{
    context.Response.Redirect("/Register");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
