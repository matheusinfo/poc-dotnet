using csharp_crud.Models;

public interface UpdatePersonRepository { 
    Task<PersonResponse> updatePerson(int id, PersonRequest personRequest);
}