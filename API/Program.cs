using Application.Commands.Create;
using Application.Commands.Update;
using Application.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Persistence;

namespace API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfigureServices(builder);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<OrderContext>();

                    //if (context.Database.IsRelational())
                    //{
                    //    context.Database.EnsureDeleted();
                    //    context.Database.Migrate();
                    //    //DbInitializer.Initialize(context);
                    //}
                }
                catch (Exception)
                {
                    throw;
                }
            }

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

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<OrderContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetOrdersQueryHandler>());


            //FluentValidationConfig
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddScoped<IValidator<UpdateOrderCommand>, UpdateOrderCommandValidator>();
            builder.Services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            //
        }
    }
}