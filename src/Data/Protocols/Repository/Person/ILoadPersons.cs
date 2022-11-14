using csharp_crud.Models;

public interface ILoadPersonsRepository { 
    Task<List<PersonResponse>> loadPersons();
}
