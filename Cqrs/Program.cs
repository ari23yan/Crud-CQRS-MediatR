using Cqrs;
using Cqrs.Context;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ZymLabs.NSwag.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;

                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(SampleCQRSwithMediatREntrypoint).Assembly);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sample CQRS With MediatR.WebApi",
    });
});
//builder.Services.AddScoped<FluentValidationSchemaProcessor>(provider =>
//{
//    var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
//    var loggerFactory = provider.GetService<ILoggerFactory>();

//    return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
//});
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<CqrsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(CqrsDbContext).Assembly.FullName));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleCQRSwithMediatR.WebApi");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
