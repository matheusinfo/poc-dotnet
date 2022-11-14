using csharp_crud.Models;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.src.Data.Services.Person;

public class LoadPersonsService : ILoadPersons { 
    private readonly ILoadPersonsRepository _loadPersonsRepository;

    public LoadPersonsService (
        ILoadPersonsRepository loadPersonsRepository
    ) {
        _loadPersonsRepository = loadPersonsRepository;
    }

    public List<PersonResponse> loadPersons() {
        return _loadPersonsRepository.loadPersons();
    }
}
