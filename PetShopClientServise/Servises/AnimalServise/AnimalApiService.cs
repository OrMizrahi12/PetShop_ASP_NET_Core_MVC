using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Responses;
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
        public async Task<ClientResponse<Animals>> GetAnimalById(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Animal/{id}");

            if (response.IsSuccessStatusCode)
            {
                var animal = await response.Content.ReadFromJsonAsync<Animals>();
                return new ClientResponse<Animals> { Data = animal, StatusCode = HttpStatusCode.OK };
            }
            else
            {
                return new ClientResponse<Animals> { Data = new Animals(), StatusCode = response.StatusCode };
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

            var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Animal/UpdateAnimal", animal);

            return response.StatusCode;
        }
        [PetShopExceptionFilter]
        public async Task<ClientResponse<List<Animals>>> GetAnimalsByCategory(int id)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Animal/GetAnimalsByCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var animals = await response.Content.ReadFromJsonAsync<List<Animals>>();
                return new ClientResponse<List<Animals>> { Data = animals, StatusCode = HttpStatusCode.OK };
            }
            else
            {
                return new ClientResponse<List<Animals>> { Data = new List<Animals>(), StatusCode = response.StatusCode };
            }
        }

        [PetShopExceptionFilter]
        public async Task<ClientResponse<List<Animals>>> GetAllAnimals()
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Animal");

            if (response.IsSuccessStatusCode)
            {
                var animals = await response.Content.ReadFromJsonAsync<List<Animals>>();
                return new ClientResponse<List<Animals>> { Data = animals, StatusCode = HttpStatusCode.OK };
            }
            else
            {
                return new ClientResponse<List<Animals>> { Data = new List<Animals>(), StatusCode = response.StatusCode };
            }
        }

    }
}
