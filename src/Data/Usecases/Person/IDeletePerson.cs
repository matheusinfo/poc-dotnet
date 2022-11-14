namespace csharp_crud.src.Data.Usecases.Person;

public interface IDeletePerson {
    Task<bool> deletePerson(int id);
}
