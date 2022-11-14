using csharp_crud.Models;

namespace csharp_crud.src.Data.Usecases.Person;

public interface ILoadPersonById {
    PersonResponse loadPersonById(int id);
}
