using csharp_crud.Models;

namespace csharp_crud.Repository;

public class PersonRepository : 
    ICreatePersonRepository, 
    IDeletePersonRepository,
    ILoadPersonByIdRepository,
    ILoadPersonsRepository,
    IUpdatePersonRepository 
{
    private readonly List<PersonResponse> _persons;

    public PersonRepository()
    {
        _persons = new List<PersonResponse>();  
    }

    public Task<PersonResponse> createPerson(PersonRequest personRequest) 
    {
        var person = new PersonResponse { id = this._persons.Count + 1, name = personRequest.name, age = personRequest.age };
        _persons.Add(person);
        return Task.FromResult(person);
    }

    public Task<bool> deletePerson(int id)
    {
        var person = _persons.FirstOrDefault(person => person.id == id);
        
        if (person == null) {
            return Task.FromResult(false);
        }

        _persons.Remove(person);
        return Task.FromResult(true);
    }

    public Task<PersonResponse> loadPersonById(int id) 
    {
        var person = _persons.FirstOrDefault(person => person.id == id);
        
        if (person == null) {
            throw new Exception("Person not found");
        }

        return Task.FromResult(person);
    }

    public Task<List<PersonResponse>> loadPersons()
    {
        return Task.FromResult(this._persons);
    }

    public Task<PersonResponse> updatePerson(int id, PersonRequest personRequest)
    {
        var person = _persons.FirstOrDefault(person => person.id == id);
        
        if (person == null) {
            throw new Exception("Person not found");
        }

        person.name = personRequest.name;
        person.age = personRequest.age;

        return Task.FromResult(person);
    }
}
