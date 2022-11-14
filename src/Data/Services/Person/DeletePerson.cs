using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class DeletePersonService : IDeletePerson { 
    private readonly ILoadPersonByIdRepository _loadPersonByIdRepository;
    private readonly IDeletePersonRepository _deletePersonRepository;

    public DeletePersonService (
        ILoadPersonByIdRepository loadPersonByIdRepository,
        IDeletePersonRepository deletePersonRepository
    ) {
        _loadPersonByIdRepository = loadPersonByIdRepository;
        _deletePersonRepository = deletePersonRepository;
    }

    public void deletePerson(int id) {
        var person = _loadPersonByIdRepository.loadPersonById(id);

        if (person == null) {
            throw new Exception("Person not found");
        }

        _deletePersonRepository.deletePerson(person);
    }
}
