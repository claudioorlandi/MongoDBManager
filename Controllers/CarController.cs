using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

// Academy dedicata alla gestione del code repository
namespace MongoDBManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private IMongoCollection<Car> cars;

        // Faccio il contrario e aggiorno il mio repo locale con il repo remoto
        public CarController(IOptions<CarConfig> carOptions)
        {
            var mongoClient = new MongoClient(carOptions.Value.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(carOptions.Value.DatabaseName);
            cars = mongoDB.GetCollection<Car>(carOptions.Value.CarsCollectionName);
        }

        [HttpGet]
        public async Task<List<Car>> GetCar()
        {
            return await cars.Find(obj => true).ToListAsync();
        }

        [HttpDelete]
        public async Task<DeleteResult> DeleteCar(string Id)
        {
            return await cars.DeleteOneAsync(obj => obj.Id == Id);
        }
    }
}
