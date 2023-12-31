
namespace MongoDBManager
{
    public class Program
    {
        // Solution archiviata su Git, nel mio repository personale/aziendale
        // https://github.com/claudioorlandi/MongoDBManager
        // Tenere d'occhio le eventuali modifiche successive da gestire su branch

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<CarConfig>(builder.Configuration.GetSection("CarsMongoDb"));

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
