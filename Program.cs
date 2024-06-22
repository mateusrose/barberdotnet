using barberdotnet.model.persistence;
using barberdotnet.services; // Add this using directive
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers; // Add this using directive
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity; // Add this using directive
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using barberdotnet.controllers.middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c=>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddDbContext<BarberContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  

});
builder.Services.AddIdentityCore<MyUser>()
    .AddEntityFrameworkStores<AuthContext>()
    .AddApiEndpoints();

builder.Services.AddServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()   // Change to specific origin in production
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<BlockRegisterMiddleware>();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<MyUser>();
using (var scope =  app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BarberContext>();
    var initializer = new DataBaseInit(context);
    initializer.Initialize();
    
}
app.MapControllers();


app.Run();

class MyUser : IdentityUser{}
class AuthContext : IdentityDbContext<MyUser>
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options) {}
}