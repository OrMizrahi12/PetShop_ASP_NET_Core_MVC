using PetShopApiServise.DtoModels;


namespace PetShopClientServise.Servises.AnimalServise
{
     public interface IAnimalApiServise
     {
        Task<Animals?> GetAnimalById(int id);
        Task<int> AddAnimal(Animals animal);
        Task<int> UpdateAnimal(Animals animal);
        Task<int> DeleteAnimalById(int animalId);
        Task<IEnumerable<Animals>> GetAllAnimals();



    }
}
