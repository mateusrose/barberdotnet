using barberdotnet.model.persistence;
using barberdotnet.services; // Add this using directive
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers; // Add this using directive
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization; // Add this using directive



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddServices();


builder.Services.AddDbContext<BarberContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

//app.UseHttpsRedirection();


using (var scope =  app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BarberContext>();
    var initializer = new DataBaseInit(context);
    initializer.Initialize();
    
}
app.MapControllers();
app.Run();

