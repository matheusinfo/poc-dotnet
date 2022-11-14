using csharp_crud.Models;

public interface IUpdatePersonRepository { 
    Task<PersonResponse> updatePerson(int id, PersonRequest personRequest);
}
