using Application.EF.Context;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Base.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var Configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices(Configuration);

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var unitOfWork = services.GetRequiredService<IUnitOfWork<BloggingContext>>();
    var migrations = unitOfWork.DbContext.Database.GetAppliedMigrations();
    unitOfWork.DbContext.Database.Migrate();
}

//app.Services.GetRequiredService<IUnitOfWork<BloggingContext>>().DbContext.Database.GetAppliedMigrations();
//app.Services.GetRequiredService<IUnitOfWork<BloggingContext>>().DbContext.Database.Migrate();

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
