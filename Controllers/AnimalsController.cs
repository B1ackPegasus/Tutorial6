using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;
using Tutorial5.Services;

namespace Tutorial5.Controllers;

[ApiController]

[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals(string? orderBy = "name")
    {
        var animals = _animalsService.GetAnimals(orderBy);
        
        return Ok(animals);
    }


    [HttpPost]
    public IActionResult AddAnimal(AddAnimal animal)
    {

        _animalsService.AddAnimal(animal);

        return Created();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, AddAnimal animal)
    {
        _animalsService.UpdateAnimal(id, animal);

        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalsService.DeleteAnimal(id);

        return NoContent();
    }
}