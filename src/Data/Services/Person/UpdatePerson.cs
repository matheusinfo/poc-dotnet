using csharp_crud.Models;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class UpdatePersonService : IUpdatePerson { 
    private readonly ILoadPersonByIdRepository _loadPersonByIdRepository;
    private readonly IUpdatePersonRepository _updatePersonRepository;

    public UpdatePersonService (

        ILoadPersonByIdRepository loadPersonByIdRepository,
        IUpdatePersonRepository updatePersonRepository
    ) {
        _loadPersonByIdRepository = loadPersonByIdRepository;
        _updatePersonRepository = updatePersonRepository;
    }

    public PersonResponse updatePerson(int id, PersonRequest personRequest) {
        var person = _loadPersonByIdRepository.loadPersonById(id);

        if (person == null) {
            throw new Exception("Person not found");
        }

        return _updatePersonRepository.updatePerson(id, personRequest);
    }
}
