using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class DeletePersonService : IDeletePerson { 
    private readonly IDeletePersonRepository _deletePersonRepository;

    public DeletePersonService (
        IDeletePersonRepository deletePersonRepository
    ) {
        _deletePersonRepository = deletePersonRepository;
    }

    public async Task<bool> deletePerson(int id) {
        return await _deletePersonRepository.deletePerson(id);
    }
}
