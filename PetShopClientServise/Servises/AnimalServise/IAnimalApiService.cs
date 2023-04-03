using PetShopClientServise.DtoModels;
using System.Net;

namespace PetShopClientServise.Servises.AnimalServise
{
    public interface IAnimalApiService
    {
        public Task<(Animals? animal, HttpStatusCode statusCode)> GetAnimalById(int id);
        public Task<HttpStatusCode> AddAnimal(Animals animal);
        public Task<HttpStatusCode> UpdateAnimal(Animals animal);
        public Task<HttpStatusCode> DeleteAnimalById(int animalId);
        public Task<(List<Animals> animals, HttpStatusCode statusCode)> GetAllAnimals();
    }
}
