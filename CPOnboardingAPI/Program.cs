using CPOnboardingAPI.Data;
using CPOnboardingAPI.Mappers;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Capital Placement Onboarding API",
        Version = "v1",

    });

});
builder.Services.AddSingleton<IRepository, Repository>((provider) =>
{
    var cosmosClient = new CosmosClient(builder.Configuration.GetConnectionString("CosmosDbConnection"));
    return new Repository(cosmosClient, builder.Configuration["DbConfig:DatabaseName"], builder.Configuration["DbConfig:ContainerName"]);

});
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
