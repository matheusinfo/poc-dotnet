using csharp_crud.Models;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class CreatePersonService : ICreatePerson { 
    private readonly ICreatePersonRepository _createPersonRepository;

    public CreatePersonService (
        ICreatePersonRepository createPersonRepository
    ) {
        _createPersonRepository = createPersonRepository;
    }

    public async Task<PersonResponse> createPerson(PersonRequest personRequest) {
        return await _createPersonRepository.createPerson(personRequest);
    }
}
