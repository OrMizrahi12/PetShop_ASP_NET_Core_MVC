using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Serialization;
using System.Net;
using System.Net.Http.Json;

namespace PetShopClientServise.Servises.AnimalServise
{
    public class AnimalApiService : IAnimalApiService
    {

        public async Task<HttpStatusCode> AddAnimal(Animals animal)
        {
            if (animal.ImageFile != null)
            {
                animal.Picture = ImageSerialization.ImageToByteArray(animal.ImageFile);
                animal.ImageFile = null;
            }

            var response = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Animal", animal);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAnimalById(int animalId)
        {
            var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Animal/{animalId}");

            return response.StatusCode;
        }

        public async Task<(Animals? animal, HttpStatusCode statusCode)> GetAnimalById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Animal/{id}");

            if (response.IsSuccessStatusCode)
            {
                var animal = await response.Content.ReadFromJsonAsync<Animals>();
                return (animal, HttpStatusCode.OK);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return (null, HttpStatusCode.NotFound);
            }
            else
            {
                return (null, response.StatusCode);
            }
        }

        public async Task<HttpStatusCode> UpdateAnimal(Animals animal)
        {
            if (animal.ImageFile != null)
            {
                animal.Picture = ImageSerialization.ImageToByteArray(animal.ImageFile);
                animal.ImageFile = null;
            }

            var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Animal", animal);

            return response.StatusCode;
        }

        public async Task<(List<Animals> animals, HttpStatusCode statusCode)> GetAllAnimals()
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Animal");

            if (response.IsSuccessStatusCode)
            {
                var animals = await response.Content.ReadFromJsonAsync<List<Animals>>();
                return (animals!, HttpStatusCode.OK);
            }
            else
            {
                return (null!, response.StatusCode);
            }
        }


    }
}
