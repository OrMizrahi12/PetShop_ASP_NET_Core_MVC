using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Serialization;
using System.Net;
using System.Net.Http.Json;

namespace PetShopClientServise.Servises.AnimalServise
{
    public class AnimalApiService : IAnimalApiService
    {

        [PetShopExceptionFilter]
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

        [PetShopExceptionFilter]
        public async Task<HttpStatusCode> DeleteAnimalById(int animalId)
        {
            var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Animal/{animalId}");

            return response.StatusCode;
        }

        [PetShopExceptionFilter]
        public async Task<(Animals? animal, HttpStatusCode statusCode)> GetAnimalById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Animal/{id}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var animal = await response.Content.ReadFromJsonAsync<Animals>();
                return (animal, HttpStatusCode.OK);
            }
            else
            {
                return (new Animals { }, response.StatusCode);
            }
        }

        [PetShopExceptionFilter]
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

        [PetShopExceptionFilter]
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
                return (new List<Animals> { }, response.StatusCode);
            }
        }

        [PetShopExceptionFilter]
        public async Task<(List<Animals> animals, HttpStatusCode statusCode)> GetAnimalsByCategory(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Animal/GetAnimalsByCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var animals = await response.Content.ReadFromJsonAsync<List<Animals>>();
                return (animals!, HttpStatusCode.OK);
            }
            else
            {
                return (new List<Animals> { }, response.StatusCode);
            }
        }


    }
}
