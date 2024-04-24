using ImageAnalyzer.Data.Repository;
using ImageAnalyzer.Models;
using ImageAnalyzer.Repository;
using ImageAnalyzer.Services;
using ImageAnalyzer.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IImageAnalyzerService, ImageAnalyzerService>();
builder.Services.AddDbContext<ImageAnalyzerContext>(opt => opt
                                                     .UseSqlServer("Server=tcp:imageanalyzerserver01.database.windows.net,1433;Initial Catalog=DBImageAnalyzer01;Persist Security Info=False;User ID=sysadmin;Password=Welcome@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                                                     .AddUnitOfWork<ImageAnalyzerContext>();


                                                    
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
