using PetShopApiServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Serialization;
using System.Net.Http.Json;


namespace PetShopClientServise.Servises.AnimalServise
{
    public class AnimalApiServise : IAnimalApiServise
    {


        public async Task<int> AddAnimal(Animals animals)
        {
            if (animals.ImageFile != null)
            {
                animals.Image = ImageSerialization.ImageToByteArray(animals.ImageFile);
                animals.ImageFile = null;
            }
            var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Animal", animals);
            return res.IsSuccessStatusCode ? 0 : 1;
        }

        public async Task<int> DeleteAnimalById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Animal/{id}");

            return response.IsSuccessStatusCode ? 0 : 1;
        }

        public async Task<Animals?> GetAnimalById(int id)
        {
            var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<Animals?>($"api/Animal/{id}");
            return res;
        }

        public async Task<int> UpdateAnimal(Animals animal)
        {
            if (animal.ImageFile != null)
            {
                animal.Image = ImageSerialization.ImageToByteArray(animal.ImageFile);
                animal.ImageFile = null;
            }
            var res = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Animal", animal);
            return res.IsSuccessStatusCode ? 0 : 1;
        }

        public async Task<IEnumerable<Animals>> GetAllAnimals()
        {
            var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<List<Animals>?>("api/Animal");



            return res!;
        }
    }
}
