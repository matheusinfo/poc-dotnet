using csharp_crud.Models;

public interface ILoadPersonByIdRepository { 
    Task<PersonResponse?> loadPersonById(int id);
}
