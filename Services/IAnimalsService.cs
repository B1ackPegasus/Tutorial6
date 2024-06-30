using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Services;

public interface IAnimalsService
{
    public IOrderedEnumerable<Animal> GetAnimals(string orderBy);
    public void AddAnimal(AddAnimal animal);
    public void UpdateAnimal(int id, AddAnimal animal);
    public void DeleteAnimal(int id);
}