using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Repositories;

public interface IAnimalsRepository
{
    public List<Animal> GetAnimals();
    public void AddAnimal(AddAnimal animal);
    public void UpdateAnimal(int id, AddAnimal animal);
    public void DeleteAnimal(int id);
}