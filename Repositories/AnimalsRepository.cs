using Microsoft.Data.SqlClient;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private readonly IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Animal> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal;";
        
        var reader = command.ExecuteReader();

        var animals = new List<Animal>();

        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Area = reader["Area"].ToString(),
                Category = reader["Category"].ToString(),
                Description = reader["Description"] != null ? reader["Description"].ToString() : null
            });
        }

        return animals;
    }

    public void AddAnimal(AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        connection.Open();
        
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES (@Name,@Desc,@Cat,@Area)";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Desc", animal.Description);
        command.Parameters.AddWithValue("@Cat", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        
        
        command.ExecuteNonQuery();
    }

    public void UpdateAnimal(int id, AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        connection.Open();
        
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal " +
                              "SET Name = @Name, Description = @Desc, Category = @Cat, Area = @Area "+
                              "WHERE IdAnimal = @id ";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Desc", animal.Description);
        command.Parameters.AddWithValue("@Cat", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        command.Parameters.AddWithValue("@Id", id);
        
        
        command.ExecuteNonQuery();
    }

    public void DeleteAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        connection.Open();
        
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal " +
                              "WHERE IdAnimal = @id ";
        command.Parameters.AddWithValue("@Id", id);
        
        
        command.ExecuteNonQuery();
    }
}