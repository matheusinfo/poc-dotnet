using csharp_crud.Models;

namespace csharp_crud.src.Data.Usecases.Person;

public interface IUpdatePerson {
    Task<PersonResponse> updatePerson(int id, PersonRequest personRequest);
}
