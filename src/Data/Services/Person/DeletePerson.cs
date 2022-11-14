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

    public async Task<bool> deletePerson(int id) {
        var person = await _loadPersonByIdRepository.loadPersonById(id);

        if (person == null) {
            return false;
        }

        return await _deletePersonRepository.deletePerson(person);
    }
}
