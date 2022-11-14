using csharp_crud.Models;
using MySql.Data.MySqlClient;

namespace csharp_crud.Repository;

public class PersonRepository
    : ICreatePersonRepository,
        IDeletePersonRepository,
        ILoadPersonByIdRepository,
        ILoadPersonsRepository,
        IUpdatePersonRepository
{
    private static readonly List<PersonResponse> _personss = new List<PersonResponse>();

    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public PersonRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DEFAULT");
    }

    public void createPerson(PersonRequest personRequest)
    {
        List<PersonResponse> _person = new List<PersonResponse>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try {
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO person (name, age) VALUES (@name, @age)", connection);
            command.Parameters.AddWithValue("@name", personRequest.name);
            command.Parameters.AddWithValue("@age", personRequest.age);
            command.ExecuteNonQuery();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        } finally {
            connection.Close();
        }
    }

    public void deletePerson(PersonResponse person)
    {
        List<PersonResponse> _person = new List<PersonResponse>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(
                "DELETE FROM person WHERE id = @id",
                connection
            );
            command.Parameters.AddWithValue("@id", person.id);
            command.ExecuteReader(); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public PersonResponse? loadPersonById(int id)
    {
        List<PersonResponse> _person = new List<PersonResponse>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM person WHERE id = @id",
                connection
            );
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                _person.Add(
                    new PersonResponse
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        age = reader.GetInt32("age")
                    }
                );
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }

        return _person.FirstOrDefault();
    }

    public List<PersonResponse> loadPersons()
    {
        List<PersonResponse> _persons = new List<PersonResponse>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM person", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PersonResponse person = new PersonResponse();
                person.id = reader.GetInt32("id");
                person.name = reader.GetString("name");
                person.age = reader.GetInt32("age");
                _persons.Add(person);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }

        return _persons;
    }

    public PersonResponse updatePerson(int id, PersonRequest personRequest)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(
                "UPDATE person SET name = @name, age = @age WHERE id = @id",
                connection
            );
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", personRequest.name);
            command.Parameters.AddWithValue("@age", personRequest.age);
            command.ExecuteNonQuery();


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }

        return new PersonResponse
        {
            id = id,
            name = personRequest.name,
            age = personRequest.age
        };
    }
}
