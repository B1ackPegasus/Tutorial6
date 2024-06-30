using Tutorial5.Models;
using Tutorial5.Models.DTOs;
using Tutorial5.Repositories;

namespace Tutorial5.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _repository;

    public AnimalsService(IAnimalsRepository repository)
    {
        _repository = repository;
    }

    public IOrderedEnumerable<Animal> GetAnimals(string orderBy)
    {
        var animals = _repository.GetAnimals();
        if (orderBy.Equals("name"))
        {
            return animals.OrderBy(a => a.Name);
        }
        else if (orderBy.Equals("area"))
        {
            return animals.OrderBy(a => a.Area);
        }
        else if (orderBy.Equals("category"))
        {
            return animals.OrderBy(a => a.Category);
        }
        else
        {
            return animals.OrderBy(a => a.Description);
        }
        
    }

    public void AddAnimal(AddAnimal animal)
    {
        _repository.AddAnimal(animal);
    }

    public void UpdateAnimal(int id, AddAnimal animal)
    {
        _repository.UpdateAnimal(id, animal);
    }

    public void DeleteAnimal(int id)
    {
        _repository.DeleteAnimal(id);
    }
}