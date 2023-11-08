using AutoMapper;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Config;
using GeekShopping.CartAPI.Repository.Intrefaces;
using GeekShopping.CartAPI.Repository;
using GeekShopping.CartAPI.RabbitMQSender;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSqlServer<SQLServerContext>(builder.Configuration["ConnectionStrings:Database"]);

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICupomRepository, CupomRepository>();
builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICupomRepository, CupomRepository>(s =>
{
    s.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CupomAPI"]);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
