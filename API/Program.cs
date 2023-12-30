using API.DTO_s.Output;
using API.Mappers.input;
using API.Mappers.output;
using API.Middleware;
using BL.Interfaces;
using BL.Managers;
using DL;
using DL.Mappers.FromEntity;
using DL.Mappers.ToEntity;
using DL.Repositories;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Logging
             builder.Logging.ClearProviders();
             builder.Logging.AddConsole();
             builder.Logging.AddDebug();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<DatabaseContext>();

            //Client
            builder.Services.AddSingleton<IClientRepository, ClientRepository>();
            builder.Services.AddSingleton<ClientManager>();
            builder.Services.AddSingleton<ClientOutputMapper>();
            builder.Services.AddSingleton<ClientInputMapper>();
            builder.Services.AddSingleton<MapClientFromEntity>();
            builder.Services.AddSingleton<MapClientToEntity>();
            
            //Restaurant
            builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddSingleton<RestaurantManager>();
            builder.Services.AddSingleton<RestaurantOutputMapper>();
            builder.Services.AddSingleton<RestaurantInputMapper>();
            builder.Services.AddSingleton<MapRestaurantFromEntity>();
            builder.Services.AddSingleton<MapRestaurantToEntity>();

            //Reservation
            builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();
            builder.Services.AddSingleton<ReservationManager>();
            builder.Services.AddSingleton<ReservationOutputMapper>();
            builder.Services.AddSingleton<ReservationInputMapper>();
            builder.Services.AddSingleton<MapReservationFromEntity>();
            builder.Services.AddSingleton<MapReservationToEntity>();

            //Table
            builder.Services.AddSingleton<ITableRepository, TableRepository>();
            builder.Services.AddSingleton<TableManager>();
            builder.Services.AddSingleton<TableOutputMapper>();
            builder.Services.AddSingleton<TableInputMapper>();
            builder.Services.AddSingleton<MapTableFromEntity>();
            builder.Services.AddSingleton<MapTableToEntity>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseResponseServiceMiddleware();         //Zelf gemaakte methode


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}