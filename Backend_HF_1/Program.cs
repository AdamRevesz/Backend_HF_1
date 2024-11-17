
using Backend_HF_1.Database;
using Backend_HF_1.Logic;
using Backend_HF_1.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Backend_HF_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IWaterLevelLogic,WaterLevelLogic>();
            builder.Services.AddScoped<IDunaLevelRepository, DunaLevelRepository>();
            builder.Services.AddDbContext<DunaLevelDbContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DunaLevels;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                options.UseLazyLoadingProxies();
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WaterLevel Api", Version = "v1" });
            });

            var app = builder.Build();

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
        }
    }
}
