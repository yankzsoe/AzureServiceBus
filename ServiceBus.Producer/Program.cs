using Microsoft.Azure.ServiceBus;
using ServiceBus.Producer.Services;

namespace ServiceBus.Producer {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ITopicClient>(tc =>
                new TopicClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                builder.Configuration.GetValue<string>("ServiceBus:TopicName")));
            builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
