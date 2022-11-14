using csharp_crud.Models;

namespace csharp_crud.src.Data.Usecases.Person;

public interface IUpdatePerson {
    PersonResponse updatePerson(int id, PersonRequest personRequest);
}
