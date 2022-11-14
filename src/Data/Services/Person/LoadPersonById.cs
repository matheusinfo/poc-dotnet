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

    public async Task<PersonResponse> loadPersonById(int id) {
        return await _loadPersonByIdRepository.loadPersonById(id);
    }
}
