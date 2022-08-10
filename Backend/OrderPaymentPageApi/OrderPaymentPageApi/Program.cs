using Microsoft.EntityFrameworkCore;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Repositories;
using OrderPaymentPageApi.Models;
using OrderPaymentPageApi.ViewModels;

string corsstr = "";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderPaymentDbContext>(n => n
                .UseSqlServer(builder.Configuration
                .GetConnectionString("OrderPaymentConnectionString")));
builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Payment>, PaymentRepository>();
builder.Services.AddScoped<IOrderUpdateRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentUpdateRepository, PaymentRepository>();
builder.Services.AddScoped<WalletRepository, WalletRepository>();
builder.Services.AddScoped<WalletViewModel, WalletViewModel>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsstr,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
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

app.UseCors(corsstr);

app.MapControllers();

app.Run();
