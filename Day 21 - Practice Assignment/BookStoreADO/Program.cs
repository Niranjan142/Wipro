builder.Services.AddControllersWithViews();

builder.Services.AddScoped<BookRepository>();

var app = builder.Build();
