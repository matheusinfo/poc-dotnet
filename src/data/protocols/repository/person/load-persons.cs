using csharp_crud.Models;

public interface LoadPersonsRepository { 
    Task<List<PersonResponse>> loadPersons();
}
