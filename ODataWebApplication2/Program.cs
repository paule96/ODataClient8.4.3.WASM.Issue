using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ODataWebApplication2;

// Learn more about configuring OData at https://learn.microsoft.com/odata/webapi-8/getting-started
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(opt =>
{
    opt.AddRouteComponents("odata", EdmModelBuilder.GetEdmModel())
           .EnableQueryFeatures(100);

    opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
    opt.RouteOptions.EnableActionNameCaseInsensitive = true;
    opt.RouteOptions.EnablePropertyNameCaseInsensitive = true;
    opt.RouteOptions.EnableNonParenthesisForEmptyParameterFunction = true;
});

// Learn more about configuring Swagger/OpenAPI at https://github.com/OData/AspNetCoreOData/tree/main/sample/ODataRoutingSample
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ODataWebApplication2", Version = "v1" });
});

// OpenAPI
builder.Services.AddOpenApi();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseODataRouteDebug();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ODataWebApplication2 V1"));

    // OpenAPI
    app.MapOpenApi();
}

app.UseRouting();

app.MapControllers();

app.Run();
