using RobotApi.Domain.Interface;
using RobotApi.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//Register Services
builder.Services.AddSingleton<Robot>();
builder.Services.AddScoped<IRobotMoveService, RobotService>();
builder.Services.AddScoped<IRobotPlaceService, RobotService>();
builder.Services.AddScoped<IRobotRotateService, RobotService>();
builder.Services.AddScoped<IRobotReportService, RobotService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Enable CORS
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
