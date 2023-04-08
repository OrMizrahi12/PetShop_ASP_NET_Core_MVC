using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Responses;
using System.Net;

namespace PetShopClientServise.Servises.AnimalServise
{
    public interface IAnimalApiService
    {
        public Task<ClientResponse<Animals>> GetAnimalById(int id);
        public Task<HttpStatusCode> AddAnimal(Animals animal);
        public Task<HttpStatusCode> UpdateAnimal(Animals animal);
        public Task<HttpStatusCode> DeleteAnimalById(int animalId);
        public Task<ClientResponse<List<Animals>>> GetAllAnimals();
        public Task<ClientResponse<List<Animals>>> GetAnimalsByCategory(int id);
    }
}
