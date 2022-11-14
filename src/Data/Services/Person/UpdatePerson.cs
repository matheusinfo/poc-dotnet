using csharp_crud.Models;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class UpdatePersonService : IUpdatePerson { 
    private readonly IUpdatePersonRepository _updatePersonRepository;

    public UpdatePersonService (
        IUpdatePersonRepository updatePersonRepository
    ) {
        _updatePersonRepository = updatePersonRepository;
    }

    public async Task<PersonResponse> updatePerson(int id, PersonRequest personRequest) {
        return await _updatePersonRepository.updatePerson(id, personRequest);
    }
}
