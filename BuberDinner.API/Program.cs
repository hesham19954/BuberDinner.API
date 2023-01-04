using BuberDinner.API.MiddleWare;
using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddAppliction()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddEndpointsApiExplorer();
  //  builder.Services.AddSwaggerGen();

}

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseCustomMiddleware();
app.MapControllers();

app.Run();
