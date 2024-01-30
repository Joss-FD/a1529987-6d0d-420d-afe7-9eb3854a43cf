using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SequenceFinder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200/", "https://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/FindSequence", async (HttpRequest request) =>
{
    var inputText = "";
    using (StreamReader reader
                 = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
    {
        inputText = await reader.ReadToEndAsync();
    }
  
    SequenceHandler sh = new SequenceHandler();
    var result = sh.FindLongestSequence(inputText);
    return String.Join(" ", result);
})
.WithName("FindSequence");

app.Run();

