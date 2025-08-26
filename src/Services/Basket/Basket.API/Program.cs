var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddHealthChecks();

var app = builder.Build();

//Configure the HTTP request pipeline.

app.UseHealthChecks("/health");

app.Run();