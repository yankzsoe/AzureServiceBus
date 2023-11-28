using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.Consumer {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ISubscriptionClient>(sc =>
                new SubscriptionClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                    builder.Configuration.GetValue<string>("ServiceBus:TopicName"),
                    builder.Configuration.GetValue<string>("ServiceBus:SubscriptionName")));

            builder.Services.AddControllers();
            builder.Services.AddHostedService<CustomerConsumerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
