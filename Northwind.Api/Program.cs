using Northwind.Infrastructure;

namespace Northwind.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddMcpServer()
                .WithHttpTransport()
                .WithToolsFromAssembly();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();
            app.MapMcp();
            app.Run();
        }
    }
}
