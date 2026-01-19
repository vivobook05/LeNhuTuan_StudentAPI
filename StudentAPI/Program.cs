using Microsoft.EntityFrameworkCore;

using StudentAPI.Data;

namespace StudentAPI

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()

            // Optionally, configure JSON options or other formatter settings

            .AddJsonOptions(options =>

            {

                // Configure JSON serializer settings to keep the Original names in serialization and deserialization

                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            // Add DbContext with SQL Server

            builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
