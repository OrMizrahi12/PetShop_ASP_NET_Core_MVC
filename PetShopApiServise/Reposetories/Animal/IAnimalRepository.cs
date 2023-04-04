﻿using Microsoft.AspNetCore.Mvc;
using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Animal
{
    public interface IAnimalRepository
    {
        Task<Animals?> GetAnimalById(int id);
        Task<int> AddAnimal(Animals animal);
        Task<int> UpdateAnimal(Animals animal);
        Task<int> DeleteAnimalById(int animalId);
        Task<IEnumerable<Animals>> GetAllAnimals();

        Task<IEnumerable<Animals>> GetAnimalsByCategory(int id);
    }
}
