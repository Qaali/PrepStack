using Microsoft.EntityFrameworkCore;
using PrepStack.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Register the Database (Dependency Injection)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add Controller support
builder.Services.AddControllers();

// 3. Add Swagger Services (This is what was missing/different)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // These two lines turn on the Swagger website
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 5. Tell the app to look for your QuestionsController
app.MapControllers();

app.Run();