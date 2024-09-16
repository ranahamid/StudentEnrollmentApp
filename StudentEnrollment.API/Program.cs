using EnrollmentEnrollment.API.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentEnrollment.API.Configurations;
using StudentEnrollment.API.Endpoints;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection");

 builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
 {
     options.UseSqlServer(conn
         ,b => b.MigrationsAssembly("StudentEnrollment.API")
         );
 });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddAutoMapper(typeof(MapperConfig));



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",x =>
    {
        x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");


app.MapStudentEndPoints();
app.MapEnrollmentEndPoints();
app.MapCourseEndPoints();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();



//app.MapGet("/getscore", () =>
//{
//    return 0;
//})
//.WithName("getscoreresult")
//.WithOpenApi();




app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
