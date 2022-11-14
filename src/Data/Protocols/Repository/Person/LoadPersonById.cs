using csharp_crud.Models;

public interface LoadPersonByIdRepository { 
    Task<PersonResponse> loadPersonById(int id);
}
