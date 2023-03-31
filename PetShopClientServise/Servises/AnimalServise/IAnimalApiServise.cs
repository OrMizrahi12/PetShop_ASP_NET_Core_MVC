using PetShopApiServise.DtoModels;


namespace PetShopClientServise.Servises.AnimalServise
{
     public interface IAnimalApiServise
     {
        public Task<Animals?> GetAnimalById(int id);
        public Task<int> AddAnimal(Animals animal);
        public Task<int> UpdateAnimal(Animals animal);
        public Task<int> DeleteAnimalById(int animalId);
        public Task<IEnumerable<Animals>> GetAllAnimals();



    }
}
