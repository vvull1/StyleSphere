using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StyleSphereDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CORE_WEB_APIContext") ?? throw new InvalidOperationException("Connection string 'CORE_WEB_APIContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //checks if the application is running in the Development environment, and if so, configures Swagger and SwaggerUI.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();  //It is the middleware in the pipeline, which catches any unhandled exceptions and returns an HTTP 500 response.
