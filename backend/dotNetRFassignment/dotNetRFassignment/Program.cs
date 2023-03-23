using dotNetRFassignment.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Scan(selector => selector
    .FromAssemblies(
        dotNetRFassignment.Persistence.AssemblyReference.Assembly,
        dotNetRFassignment.Infrastructure.AssemblyReference.Assembly)
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(dotNetRFassignment.Application.AssemblyReference.Assembly);
});

builder.Services.AddControllers()
    .AddApplicationPart(dotNetRFassignment.Presentation.AssemblyReference.Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<JsonWebTokenOptionsSetup>();
builder.Services.ConfigureOptions<JsonWebTokenBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
