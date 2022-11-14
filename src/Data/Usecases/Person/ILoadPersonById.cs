using csharp_crud.Models;

namespace csharp_crud.src.Data.Usecases.Person;

public interface ILoadPersonById {
    Task<PersonResponse> loadPersonById(int id);
}
