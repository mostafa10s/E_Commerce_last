using E_Commerce;
using E_Commerce.Application.Services.Implementation;
using E_Commerce.Application.Services.Interface;
using E_Commerce.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongSettings>(builder.Configuration.GetSection("Mongo"));
builder.Services.AddSingleton<MongoDbContext>();


builder.Services.AddScoped< IProductServices,ProductServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
