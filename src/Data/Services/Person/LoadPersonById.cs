using csharp_crud.Models;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class LoadPersonByIdService : ILoadPersonById { 
    private readonly ILoadPersonByIdRepository _loadPersonByIdRepository;

    public LoadPersonByIdService (
        ILoadPersonByIdRepository loadPersonByIdRepository
    ) {
        _loadPersonByIdRepository = loadPersonByIdRepository;
    }

    public PersonResponse loadPersonById(int id) {
        var person = _loadPersonByIdRepository.loadPersonById(id);

        if (person == null) {
            throw new Exception("Person not found");
        }

        return person;
    }
}
