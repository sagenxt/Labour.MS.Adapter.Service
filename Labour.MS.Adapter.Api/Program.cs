using Core.Middleware;
using Core.MSSQL.DataAccess.CustomTypeHandlers;
using Dapper;
using Labour.MS.Adapter.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

// Register services
builder.Services.AddSingleton(new HttpClient());
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", policy =>
    {
        policy.WithOrigins("*") // Replace "*" with specific origins in production
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5001); // change from 5000 to 5001
});

var app = builder.Build();

// Middleware pipeline
//if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())  // Optional: adjust based on your need
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())  // Optional: adjust based on your need
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = ""; // Set to "" to serve at root (http://localhost/swagger/index.html)
    });
}


app.UseHttpsRedirection();
app.UseCors("corsapp");

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<SessionIdMiddleware>();

//app.UseAuthentication(); // Enable if authentication is configured
app.UseAuthorization();

app.MapControllers();
app.Run();
