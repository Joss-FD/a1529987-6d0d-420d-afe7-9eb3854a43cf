using Microsoft.AspNetCore.Mvc;
using SequenceFinder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


app.MapPost("/FindSequence", ([FromBody] string inputString) =>
{
    SequenceHandler sh = new SequenceHandler();
    var result = sh.FindLongestSequence(inputString);
    return String.Join(" ", result);
})
.WithName("FindSequence");

app.Run();

