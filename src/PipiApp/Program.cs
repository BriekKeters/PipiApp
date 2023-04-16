using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PipiApp.Data;
using Microsoft.EntityFrameworkCore;
using PipiApp;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PipiAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "PipiApp.Api",
            Version = "v1",
            Description = "To piss where you want",
            Contact = new OpenApiContact
            {
                Name = "Briek",
                Email = "OpenAI@Gmail.com",
                Url = new Uri("https://chat.openai.com")
            }
        });
});
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.RegisterDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
    //FirebaseAdmin.FirebaseApp.Create(new FirebaseAdmin.AppOptions()
    //{
    //    Credential = GoogleCredential.FromFile(),
    //});
app.Run();
